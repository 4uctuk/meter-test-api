using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterApi.Features.Meters.Contracts
{
    public class TotalDto
    {
        public string CustomerId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
