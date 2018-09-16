namespace ass3
{
   public class Item
    {
        
        public Guid Id { get; set; }
        public string Name {get; set; }
        public int Price { get; set; }
        public ItemType ItemType { get; set; }
        public int Level { get; set; }
        public DateTime CreationDate { get; set; }
    }
}