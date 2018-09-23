using System;
using System.ComponentModel.DataAnnotations;
namespace ass3
{
   public class Item
    {
        public enum ItemType
        {
            Sword,
            Axe,
            Shield
        }

        public Guid Id { get; set; }

        [EnumDataType(typeof(ItemType), ErrorMessage = "Invalid ItemType")]
        public ItemType Type { get; set; }

        [Range(1, 99)]
        public int Level { get; set; }

        [Validation]
        public DateTime CreationDate { get; set; }

        public void Modify(ModifiedItem item)
        {
            Level = item.Level;
        }

        public void Modify(NewItem item)
        {
            Level = item.Level;
            Type = item.Type;
        }
    }
}