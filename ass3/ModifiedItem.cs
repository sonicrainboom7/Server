using System.ComponentModel.DataAnnotations;
namespace ass3
{
    public class ModifiedItem
    {
        [Range(1, 99)]
        public int Level { get; set; }
    }
}