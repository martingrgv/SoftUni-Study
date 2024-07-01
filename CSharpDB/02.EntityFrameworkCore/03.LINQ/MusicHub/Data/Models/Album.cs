using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MusicHub.Common;

namespace MusicHub.Data.Models
{
    /// <summary>
    /// Album
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Album constructor
        /// </summary>
        public Album()
        {
            Songs = new HashSet<Song>();
        }

        /// <summary>
        /// Album identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Album name
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.AlbumNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Album release date
        /// </summary>
        [Required]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Album price
        /// </summary>
        public decimal Price => Songs.Sum(s => s.Price);

        /// <summary>
        /// Producer identifier
        /// </summary>
        public int? ProducerId { get; set; }

        /// <summary>
        /// Album producer
        /// </summary>
        [ForeignKey(nameof(ProducerId))]
        public virtual Producer? Producer { get; set; }

        /// <summary>
        /// Album songs
        /// </summary>
        public virtual ICollection<Song> Songs { get; set; }
    }
}
