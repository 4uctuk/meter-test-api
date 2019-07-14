using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeterApi.Features.Meters.Contracts
{
    public class MeterValue
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ssZ}")]
        public string DateTimeId { get; set; }

        public float Value { get; set; }
    }
}
