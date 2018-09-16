using System.ComponentModel.DataAnnotations;
namespace ass3
{
    public class NewPlayer
    {
        [Required]
        public string Name { get; set; }
    }
}