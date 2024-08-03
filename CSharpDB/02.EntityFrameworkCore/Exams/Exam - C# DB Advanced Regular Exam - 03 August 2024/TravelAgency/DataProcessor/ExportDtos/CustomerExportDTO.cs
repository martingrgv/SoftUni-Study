using Newtonsoft.Json;

namespace TravelAgency.DataProcessor.ExportDtos
{
    public class CustomerExportDTO
    {
        [JsonProperty(nameof(FullName))]
        public string FullName { get; set; } = null!;

        [JsonProperty(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; } = null!;

        [JsonProperty(nameof(Bookings))]
        public BookingExportDTO[] Bookings { get; set; } = null!;
    }
}
