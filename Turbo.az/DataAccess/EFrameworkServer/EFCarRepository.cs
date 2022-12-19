using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az.Domain.Abstractions;
using Turbo.az.Domain.Entities;

namespace Turbo.az.DataAccess.EFrameworkServer
{
    public class EFCarRepository : ICarRepository
    {
        public ICollection<Car> GetAll()
        {
            List<Car> cars = new List<Car>();
            using(var context = new CarContext())
            {
                cars = context.Cars.ToList();
                
            }
            return cars;
        }
    }
}
