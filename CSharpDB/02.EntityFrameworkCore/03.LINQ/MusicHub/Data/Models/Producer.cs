using System.ComponentModel.DataAnnotations;
using MusicHub.Common;

namespace MusicHub.Data.Models
{
    /// <summary>
    /// Producer
    /// </summary>
    public class Producer
    {
        /// <summary>
        /// Producer constructor
        /// </summary>
        public Producer()
        {
            Albums = new HashSet<Album>();
        }

        /// <summary>
        /// Producer identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Producer name
        /// </summary>
        [Required]
        [MaxLength(ValidationConstants.ProducerNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Producer pseudonym
        /// </summary>
        [MaxLength(ValidationConstants.PseudonymMaxLength)]
        public string? Pseudonym { get; set; }

        /// <summary>
        /// Producer phone number
        /// </summary>
        [MaxLength(ValidationConstants.PhoneNumberMaxLength)]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Producer albums
        /// </summary>
        public virtual ICollection<Album> Albums { get; set; }
    }
}
