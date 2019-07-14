using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeterApi.Features.Validation
{
    public interface IDataAnnotationsValidator
    {
        bool TryValidate(object @object, out ICollection<ValidationResult> results);
    }
}
