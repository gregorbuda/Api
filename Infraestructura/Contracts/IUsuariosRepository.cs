using Infraestructura.Models;
using Infrastucture.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Contracts
{
    public interface IUsuariosRepository : IAsyncRepository<Usuario>
    {
        Task<Boolean> GetToken(string Email, string Password);

        Task<Usuario> GetById(string UserId);

        Task<Usuario> GetByEmail(string Email);

        Task<bool> UpdateSuscripcion(string Id, string rol);
    }
}
