using System.ComponentModel.DataAnnotations;
using static GameZone.Data.Constants.ValidationConstants;

namespace GameZone.Data.Models
{
	public class Genre
	{
        public Genre()
        {
            Games = new List<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GENRE_NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

		public ICollection<Game> Games { get; set; }
	}
}
