using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az.Domain.Abstractions;

namespace Turbo.az.DataAccess.EFrameworkServer
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public ICarRepository CarRepository => new EFCarRepository();
    }
}
