namespace ass3
{
    public class PlayersProcessor
    {
        private IRepository _repository;
        
        public ItemsProcessor(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Item> CreateItem(Newitem newItem)
        {
            var item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = newItem.Name
            };
            await _repository.CreateItem(item);
            return item;
        }
    }
}