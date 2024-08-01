using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastre.Data.Models
{
    public class PropertyCitizen
    {
        public int PropertyId { get; set; }
        public int CitizenId { get; set;}

        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; } = null!;

        [ForeignKey(nameof(CitizenId))]
        public Citizen Citizen { get; set; } = null!;
    }
}
