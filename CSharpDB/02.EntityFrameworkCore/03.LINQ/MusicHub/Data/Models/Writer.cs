using System.ComponentModel.DataAnnotations;
using MusicHub.Common;

namespace MusicHub.Data.Models
{
    /// <summary>
    /// Writer
    /// </summary>
    public class Writer
    {
        /// <summary>
        /// Writer constructor
        /// </summary>
        public Writer()
        {
            Songs = new HashSet<Song>();
        }
        
        /// <summary>
        /// Writer identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Writer name
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.WriterNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Writer pseudonym
        /// </summary>
        [MaxLength(ValidationConstants.PseudonymMaxLength)]
        public string? Pseudonym { get; set; }

        /// <summary>
        /// Writer songs
        /// </summary>
        public ICollection<Song> Songs { get; set; }
    }
}
