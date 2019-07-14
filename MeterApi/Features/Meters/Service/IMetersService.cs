using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeterApi.Features.Meters.Contracts;

namespace MeterApi.Features.Meters.Service
{
    public interface IMetersService
    {
        Task AddMetersToDataBase(CreateMetersDaily createMetersDaily);

        Task<float> GetTotal(string customerId, DateTime from, DateTime to);

        Task<float> GetByMeter(string meterId, string customerId, DateTime from, DateTime to);
    }
}
