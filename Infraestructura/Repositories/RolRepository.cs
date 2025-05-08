using Infraestructura.Contracts;
using Infraestructura.Models;
using Infrastucture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class RolRepository : RepositoryBase<Role>, IRolRepository
    {
        public RolRepository(SistemaContext context) : base(context)
        {
        }
    }
}
