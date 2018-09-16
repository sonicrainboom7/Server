using System;
using Microsoft.AspNetCore.Mvc;
using game_server.Validation;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ass3
{
   [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly ItemsProcessor _itemProcessor;

        public ItemsController(ILogger<ItemsController> logger, ItemsProcessor ItemsProcessor)
        {
            _logger = logger;
            _itemProcessor = ItemsProcessor;
        }

        [HttpGet]
        [Route("")]
        public Task<Item[]> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("{itemrd}")]
        public Task<Item> Get(string itemId)
        {
            
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("")]
        [ValidateModel]
        public Task<Player> Create(NewItem newItem)
        {
            _logger.LogInformation("Creating item with name " + newItem.Name);
            return _itemProcessor.CreateItem(newItem);
        }

        [HttpDelete]
        [Route("{itemId}")]
        public Task<Item> Ban(Guid itemId)
        {
            throw new NotImplementedException();
        }
    }

}