using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeterApi.Features.Validation
{
    public class DataAnnotationsValidator : IDataAnnotationsValidator
    {
        public bool TryValidate(object @object, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(@object, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(
                @object, context, results,
                validateAllProperties: true
            );
        }
    }
}
