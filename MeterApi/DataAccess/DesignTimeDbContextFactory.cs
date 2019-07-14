using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MeterApi.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MetersDbContext>
    {
        public MetersDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MetersDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\projects\\meter-test-api\\MeterApi\\wwwroot\\meters.mdf;Integrated Security=True;Connect Timeout=30");

            return new MetersDbContext(optionsBuilder.Options);
        }
    }
}
