using System.ComponentModel.DataAnnotations;
using static GameZone.Data.Constants.ValidationConstants;
using static GameZone.Data.Constants.Messages;
using GameZone.Attributes;
using GameZone.Data.Models;

namespace GameZone.Models
{
	public class GameCreateModel
	{
        public GameCreateModel()
        {
			Genres = new List<Genre>();           
        }

        [Required]
		[Display(Name = "Title")]
		[StringLength(TITLE_MAX_LENGTH, MinimumLength = TITLE_MIN_LENGTH, ErrorMessage = TITLE_LENGTH_ERROR_MESSAGE)]
		public string Title { get; set; } = null!;

		[Display(Name = "Image")]
		public string? ImageUrl { get; set; } = null!;

		[Required]
		[Display(Name = "Description")]
		[StringLength(DESCRIPTION_MAX_LENGTH, MinimumLength = DESCRIPTION_MIN_LENGTH, ErrorMessage = TITLE_LENGTH_ERROR_MESSAGE)]
		public string Description { get; set; } = null!;

		[Required]
		[Display(Name = "Released On")]
		[DateFormat("yyyy-MM-dd")]
		public DateTime ReleasedOn { get; set; }

		[Required]
		[Display(Name = "Genre")]
		public int GenreId { get; set; }

		public ICollection<Genre> Genres { get; set; }
	}
}
