using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MeterApi.Features.Meters.Contracts
{
    public class CreateMetersDaily
    {
        [JsonProperty("meter_id")]
        [Required]
        public string MeterId { get; set; }

        [JsonProperty("customer_id")]
        [Required]
        public string CustomerId { get; set; }

        public string Resolution { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }

        public Dictionary<string, float> Values { get; set; }
    }
}
