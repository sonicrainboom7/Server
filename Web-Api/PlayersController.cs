using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Web_Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController
    {
        private PlayerProcessor _processor;
        public PlayersController(PlayerProcessor processor)
        {
            _processor = processor;
        }
        [HttpGet("{id:Guid}")]
        public Task<Player> Get(Guid id)
        {
            return _processor.Get(id);
        }
        [HttpGet]
        public Task<Player[]> GetAll()
        {
          return _processor.GetAll();  
        }
        [HttpPost]
        public Task<Player> Create([FromBody]NewPlayer player)
        {
            return _processor.Create(player);
        }
        [HttpPut("{id:Guid}")]
        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            return _processor.Modify(id,player);
        }
        [HttpDelete("{id:Guid}")]
        public Task<Player> Delete(Guid id)
        {
            return _processor.Delete(id);
        }
    }

}