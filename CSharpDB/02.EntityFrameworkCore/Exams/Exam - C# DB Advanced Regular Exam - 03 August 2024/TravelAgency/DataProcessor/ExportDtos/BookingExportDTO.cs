﻿using Newtonsoft.Json;

namespace TravelAgency.DataProcessor.ExportDtos
{
    public class BookingExportDTO
    {
        [JsonProperty(nameof(TourPackageName))]
        public string TourPackageName { get; set; } = null!;

        [JsonProperty(nameof(Date))]
        public string Date { get; set; } = null!;
    }
}
