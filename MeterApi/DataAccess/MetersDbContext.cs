using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeterApi.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace MeterApi.DataAccess
{
    public class MetersDbContext : DbContext
    {
        public MetersDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Meter> Meters { get; set; }
    }
}
