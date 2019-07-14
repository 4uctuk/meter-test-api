using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MeterApi.Features.Validation
{
    public class ErrorResponse
    {
        public int ErrorCount { get; set; }
        public List<string> InvalidKeys { get; }
        public List<string> ErrorMessages { get; }

        public ErrorResponse()
        {
            InvalidKeys = new List<string>();
            ErrorMessages = new List<string>();
        }

        public ErrorResponse(IEnumerable<string> validationMessages) : this()
        {
            if (validationMessages == null) throw new ArgumentNullException(nameof(validationMessages));

            ErrorMessages = validationMessages.ToList();
            ErrorCount = ErrorMessages.Count;
        }

        public ErrorResponse(params string[] errors) : this()
        {
            ErrorMessages.AddRange(errors);
            ErrorCount = ErrorMessages.Count;
        }

        public ErrorResponse(ModelStateDictionary modelState) : this()
        {
            ErrorCount = modelState.ErrorCount;

            foreach (var key in modelState.Keys)
            {
                InvalidKeys.Add(key);
            }

            foreach (var value in modelState.Values)
            {
                foreach (var error in value.Errors)
                {
                    if (!string.IsNullOrEmpty(error.ErrorMessage))
                        ErrorMessages.Add(error.ErrorMessage);

                    var exceptionMessage = error.Exception?.Message;
                    if (!string.IsNullOrEmpty(exceptionMessage))
                        ErrorMessages.Add(exceptionMessage);

                    var innerExceptionMessage = error.Exception?.InnerException?.Message;
                    if (innerExceptionMessage != null)
                        ErrorMessages.Add(innerExceptionMessage);
                }
            }
        }

        public override string ToString()
        {
            return $"Error count: {ErrorCount}: {string.Join(", ", ErrorMessages)}";
        }

        public ErrorResponse AddErrorMessage(string message)
        {
            ErrorCount++;
            ErrorMessages.Add(message);
            return this;
        }
    }
}
