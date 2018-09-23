using System.ComponentModel.DataAnnotations;

namespace ass3
{
    public class ModifiedPlayer
    {
        public int Score { get; set; }
        [Range(1, 99)]
        public int Level { get; set; }
    }
}
