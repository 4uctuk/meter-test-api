using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeterApi.DataAccess.Model
{
    public class Meter
    {
        public int Id { get; set; }

        public DateTime MeasureDateTime { get; set; }

        public float Value { get; set; }

        public string MeterId { get; set; }

        public string CustomerId { get; set; }
    }
}
