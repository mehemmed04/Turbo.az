using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az.Domain.Entities;

namespace Turbo.az.DataAccess.EFrameworkServer
{
    public class CarContext:DbContext
    {
        public CarContext():base(@"Data Source=DESKTOP-703A7RP;Initial Catalog=CarsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
        public DbSet<Car> Cars{ get; set; }
    }
}
