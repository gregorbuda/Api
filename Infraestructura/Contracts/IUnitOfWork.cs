using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuariosRepository usuariosRepository { get; }

        IRolRepository rolRepository { get; }
    }
}
