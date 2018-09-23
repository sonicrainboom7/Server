using System.ComponentModel.DataAnnotations;
namespace ass3
{
    public class NewItem
    {
        [EnumDataType(typeof(Item.ItemType), ErrorMessage = "Invalid ItemType")]
        public Item.ItemType Type { get; set; }
        [Range(1, 99)]
        public int Level { get; set; }

    }
}