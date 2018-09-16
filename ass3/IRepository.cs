using System;
using System.Threading.Tasks;
namespace ass3
{
    public interface IRepository
    {
     Task<Player> Get(Guid id);
     Task<Player[]> GetAll();
     Task<Player> Create(Player player);
     Task<Player> Modify(Guid id, ModifiedPlayer player);
    Task<Player> Delete(Guid id);
   
    Task<Item> Get(Guid id);
    Task<Item[]> GetAll();
    Task<Item> Create(Item Item);
    Task<Item> Modify(Guid id, ModifiedItem item);
    Task<Item> Delete(Guid id);
    }
}