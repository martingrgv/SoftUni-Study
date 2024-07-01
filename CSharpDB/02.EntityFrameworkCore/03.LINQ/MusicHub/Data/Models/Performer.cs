using System.ComponentModel.DataAnnotations;
using MusicHub.Common;

namespace MusicHub.Data.Models
{
    /// <summary>
    /// Performer
    /// </summary>
    public class Performer
    {
        /// <summary>
        /// Performer constructor
        /// </summary>
        public Performer()
        {
            PerformerSongs = new HashSet<SongPerformer>();
        }

        /// <summary>
        /// Performer identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Performer first name
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.PerformerFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Performer last name
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.PerformerLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Performer age
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Performer net worth
        /// </summary>
        [Required]
        public decimal NetWorth { get; set; }

        /// <summary>
        /// Performer songs
        /// </summary>
        public ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
