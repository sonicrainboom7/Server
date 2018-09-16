using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ass3
{
    public class InMemoryRepository : IRepository
    {
        private List<Player> players = new List<Player>();
        private List<Item> items = new List<Player>();

        public async Task<Player> Create(Player player)
        {
            await Task.CompletedTask;
            players.Add(player);
            return player;
        }
        public async Task<Item> Create(Item Item)
        {
            await Task.CompletedTask;
            items.Add(item);
            return item;
        }
        public async Task<Player> Delete(Guid id)
        {
            await Task.CompletedTask;
            Player found = GetPlayerById(id);
            if (found != null)
            {
                players.Remove(found);
                return found;
            }
            else 
            {
                return null;
            }

        }
         public async Task<Item> Delete(Guid id)
        {
            await Task.CompletedTask;
            Item found = GetItemById(id);
            if (found != null)
            {
                items.Remove(found);
                return found;
            }
            else 
            {
                return null;
            }

        }
        public async Task<Player> Get(Guid id)
        {
            await Task.CompletedTask;
            return GetPlayerById(id);
        }
         public async Task<Item> Get(Guid id)
        {
            await Task.CompletedTask;
            return GetItemById(id);
        }

        public async Task<Player[]> GetAll()
        {
            await Task.CompletedTask;
            return players.ToArray();
        }
         public async Task<Item[]> GetAll()
        {
            await Task.CompletedTask;
            return items.ToArray();
        }
            public async Task<Player> Modify(Guid id, ModifiedPlayer player)
            {
                await Task.CompletedTask;
                Player found = GetPlayerById(id);
                if (found != null)
                {
                    found.Score = player.Score;
                    
                }
                return found;
                }
            public async Task<Item> Modify(Guid id, ModifiedItem item)
            {
                await Task.CompletedTask;
                Item found = GetItemById(id);
                if (found != null)
                {
                    found.Level = item.Level;
                    found.ItemType = item.ItemType;
                    found.CreationDate = item.CreationDate;
                    
                }
                return found;
                }
                private Player GetPlayerById(Guid id)
                {
                    foreach (Player player in players)
                    {
                       if (player.Id == id)
                       {
                           return player;
                       } 
                    }
                    return null;
                }
                 
                private Player GetPlayerById(Guid id)
                {
                    foreach (Player player in players)
                    {
                       if (player.Id == id)
                       {
                           return player;
                       } 
                    }
                    return null;
                }
                private Item GetItemById(Guid id)
                {
                    foreach (Item item in items)
                    {
                       if (item.Id == id)
                       {
                           return item;
                       } 
                    }
                    return null;
                }
            }
    }
