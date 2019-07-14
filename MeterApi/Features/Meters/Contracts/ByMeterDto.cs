using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterApi.Features.Meters.Contracts
{
    public class ByMeterDto
    {
        public string CustomerId { get; set; }

        public string MeterId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
