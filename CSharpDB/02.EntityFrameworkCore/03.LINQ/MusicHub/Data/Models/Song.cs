using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MusicHub.Common;
using MusicHub.Data.Models.Enums;

namespace MusicHub.Data.Models
{
    /// <summary>
    /// Song
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Song constructor
        /// </summary>
        public Song()
        {
            SongPerformers = new HashSet<SongPerformer>();
        }

        /// <summary>
        /// Song identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Song name
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.SongNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Song duration
        /// </summary>
        [Required]
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Song creation date
        /// </summary>
        [Required]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Song genre
        /// </summary>
        [Required]
        public Genre Genre { get; set; }

        /// <summary>
        /// Song price
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Album identifier
        /// </summary>
        public int? AlbumId { get; set; }

        /// <summary>
        /// Song album
        /// </summary>
        [ForeignKey(nameof(AlbumId))]
        public virtual Album Album { get; set; } = null!;

        /// <summary>
        /// Writer identifier
        /// </summary>
        [Required]
        public int WriterId { get; set; }

        /// <summary>
        /// Song writer
        /// </summary>
        [ForeignKey(nameof(WriterId))]
        public virtual Writer Writer { get; set; } = null!;

        /// <summary>
        /// Song performers
        /// </summary>
        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
