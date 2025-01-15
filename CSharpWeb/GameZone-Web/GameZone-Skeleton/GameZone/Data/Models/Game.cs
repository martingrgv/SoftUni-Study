using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Data.Constants.ValidationConstants;

namespace GameZone.Data.Models
{
	public class Game
	{
        public Game()
        {
            GamersGames = new List<GamerGame>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TITLE_MAX_LENGTH)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DESCRIPTION_MAX_LENGTH)]
		public string Description { get; set; } = null!;

		public string? ImageUrl { get; set; } = null!;

        [Required]
		public string PublisherId { get; set; } = null!;

        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
		public DateTime ReleasedOn { get; set; }

        [Required]
		public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

		public ICollection<GamerGame> GamersGames { get; set; }
	}
}
