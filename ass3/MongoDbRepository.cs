using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace web_api
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<Player> _collection;
        private readonly IMongoCollection<LogEntry> _logCollection;

        public MongoDbRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase("game");
            _collection = database.GetCollection<Player>("players");
            _logCollection = database.GetCollection<LogEntry>("log");
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            await _collection.InsertOneAsync(player);
            return player;
        }

        public async Task<Player> DeletePlayer(Guid id)
        {
            Player player = await GetPlayer(id);
            var filter = Builders<Player>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(filter);
            
            return player;
        }

        public async Task<Player> GetPlayer(Guid id)
        {
            var filter = Builders<Player>.Filter.Eq("Id", id);
            return await _collection.Find(filter).FirstAsync();
        }

        public async Task<Player[]> GetAllPlayers()
        {
            var filter = Builders<Player>.Filter.Empty;
            List<Player> players = await _collection.Find(filter).ToListAsync();
            return players.ToArray();
        }

        public async Task<Player> ModifyPlayer(Guid id, ModifiedPlayer modPlayer)
        {
            Player player = await GetPlayer(id);
            player.Modify(modPlayer);
            var filter = Builders<Player>.Filter.Eq("Id", player.Id);
            await _collection.ReplaceOneAsync(filter, player);
            return player;
        }

        public async Task<Item[]> GetAllItems(Guid playerId)
        {
            // Find correct player
            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
            // Only get the items List field
            var getOnlyItems = Builders<Player>.Projection.Include(p => p.Items);

            Player player = await _collection.Find(filter).Project<Player>(getOnlyItems).FirstAsync();
            return player.Items.ToArray();
        }

        public async Task<Item> GetItem(Guid playerId, Guid itemId)
        {
            // Find correct player and item
            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId) & Builders<Player>.Filter.Eq("Items.Id", itemId);

            // Only get the item
            var getOnlyItems = Builders<Player>.Projection.Include(p => p.Items).ElemMatch(i => i.Items, i => i.Id == itemId);

            Player player = await _collection.Find(filter).Project<Player>(getOnlyItems).FirstAsync();

            return player.Items[0];
        }
        
        public async Task<Item> CreateItem(Guid playerId, Item item)
        {
            // Find correct player
            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);
            // Add item to list
            var update = Builders<Player>.Update.AddToSet("Items", item);

            Player player = await _collection.FindOneAndUpdateAsync(filter, update);
            return item;
        }

        public async Task<Item> ModifyItem(Guid playerId, Guid itemId, ModifiedItem modItem)
        {
            Item item = await GetItem(playerId, itemId);
            item.Modify(modItem);

            // Find correct player and item
            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId) & Builders<Player>.Filter.Eq("Items.Id", itemId);

            // update that item
            var update = Builders<Player>.Update.Set(p => p.Items[-1], item);

            await _collection.UpdateOneAsync(filter, update);

            return item;
        }

        public async Task<Item> DeleteItem(Guid playerId, Guid itemId)
        {
            // get item first so we can return it
            Item item = await GetItem(playerId, itemId);

            // remove item
            var pull = Builders<Player>.Update.PullFilter(p => p.Items, i => i.Id == itemId);
            // find  player
            var filter = Builders<Player>.Filter.Eq(p => p.Id, playerId);

            await _collection.UpdateOneAsync(filter, pull);

            return item;
        }

        // Assignment 5

        public async Task<Player[]> MoreThanXScore(int x)
        {
            var filter = Builders<Player>.Filter.Gte("Score", x);
            var players = await _collection.Find(filter).ToListAsync();
            return players.ToArray();
        }

        public async Task<Player> GetPlayerWithName(string name)
        {
            var filter = Builders<Player>.Filter.Eq("Name", name);
            return await _collection.Find(filter).FirstAsync();
        }

        public async Task<Player[]> GetPlayersWithItemType(Item.ItemType itemType)
        {
            var filter = Builders<Player>.Filter.Eq("Items.Type", itemType);
            var players = await _collection.Find(filter).ToListAsync();
            return players.ToArray();
        }

        public async Task<int> GetLevelsWithMostPlayers()
        {
            var aggregate = Builders<Player>.Projection.Include("Level");
            var result = await _collection.Aggregate()
                        .Project(x => new {level = x.Level})
                        .Group(
                            x => x.level,
                            x => new {level = x.Key, count = x.Sum(y => 1)}

                        )
                        .SortByDescending(x => x.count)
                        .Limit(3)
                        .ToListAsync();

            return result[0].level;
        }

        // Assignment 6

        public async Task WriteToLog(LogEntry logEntry)
        {
            await _logCollection.InsertOneAsync(logEntry);
            return;
        }

        public async Task<LogEntry[]> GetLog()
        {
            var filter = Builders<LogEntry>.Filter.Empty;
            List<LogEntry> logList = await _logCollection.Find(filter).ToListAsync();
            return logList.ToArray();
        }
    }
}
