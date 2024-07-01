using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    /// <summary>
    /// Song performers
    /// </summary>
    public class SongPerformer
    {
        /// <summary>
        /// Song identifier
        /// </summary>
        public int SongId { get; set; }

        /// <summary>
        /// Song
        /// </summary>
        [ForeignKey(nameof(SongId))]
        public Song Song { get; set; } = null!;

        /// <summary>
        /// Performer identifier
        /// </summary>
        public int PerformerId { get; set; }

        /// <summary>
        /// Performer
        /// </summary>
        [ForeignKey(nameof(PerformerId))]
        public Performer Performer { get; set; } = null!;
    }
}
