using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int CountryId { get; set; }
    }
}
