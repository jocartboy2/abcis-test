using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class AbcisCommand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string plu { get; set; }

        [Required]
        public string ordercode { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public float cost { get; set; }

        [Required]
        public float sell { get; set; }
    }
}