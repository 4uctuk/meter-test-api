using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MeterApi.DataAccess;
using MeterApi.DataAccess.Model;
using MeterApi.Features.Meters.Contracts;
using MeterApi.Features.Validation;
using Microsoft.EntityFrameworkCore;

namespace MeterApi.Features.Meters.Service
{
    public class MetersService : IMetersService
    {
        private readonly MetersDbContext _metersDbContext;
        private readonly IDataAnnotationsValidator _dataAnnotationsValidator;

        public MetersService(MetersDbContext metersDbContext,
            IDataAnnotationsValidator dataAnnotationsValidator)
        {
            _metersDbContext = metersDbContext;
            _dataAnnotationsValidator = dataAnnotationsValidator;
        }

        public async Task AddMetersToDataBase(CreateMetersDaily createMetersDaily)
        {
            var valid = _dataAnnotationsValidator.TryValidate(createMetersDaily, out var validationMessages);
            if (!valid)
            {
                var ex = new InvalidOperationException("Invalid data for task create operation");
                ex.Data.Add(nameof(validationMessages), validationMessages.Select(r => r.ErrorMessage));
                throw ex;
            }

            foreach (var meterValue in createMetersDaily.Values)
            {
                var newMeter = new Meter()
                {
                    CustomerId = createMetersDaily.CustomerId,
                    MeterId = createMetersDaily.MeterId,
                    MeasureDateTime = DateTime.ParseExact(meterValue.Key, "yyyy-MM-ddTHH:mm:ssZ",
                        CultureInfo.InvariantCulture),
                    Value = meterValue.Value
                };
                await _metersDbContext.AddAsync(newMeter);
            }

            await _metersDbContext.SaveChangesAsync();
        }

        public async Task<float> GetTotal(string customerId, DateTime @from, DateTime to)
        {
            var total = await _metersDbContext.Meters.AsNoTracking()
                .Where(
                    c => 
                        c.CustomerId == customerId
                        && c.MeasureDateTime >= from
                        && c.MeasureDateTime <= to)
                .SumAsync(c => c.Value);

            return total;
        }

        public async Task<float> GetByMeter(string meterId, string customerId, DateTime @from, DateTime to)
        {
            var total = await _metersDbContext.Meters.AsNoTracking()
                .Where(c =>
                    c.CustomerId == customerId
                    && c.MeterId == meterId
                    && c.MeasureDateTime >= from
                    && c.MeasureDateTime <= to)
                .SumAsync(c => c.Value);

            return total;
        }
    }
}
