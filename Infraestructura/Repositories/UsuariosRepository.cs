using Infraestructura.Contracts;
using Infraestructura.Models;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class UsuariosRepository : RepositoryBase<Usuario>, IUsuariosRepository
    {
        public UsuariosRepository(SistemaContext context) : base(context)
        {
        }

        public async Task<bool> GetToken(string Email, string Password)
        {
            var login = await _context.Usuarios.Where(x => x.Email == Email && x.Password == Password).FirstOrDefaultAsync();

            if (login != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Usuario> GetById(string UserId)
        {
            var user = await _context.Usuarios.Where(x => x.Id == UserId.ToString()).FirstOrDefaultAsync();

            return user;
        }

        public async Task<bool> UpdateSuscripcion(string Id, string rol)
        {
            bool result = false;

            var suscripcione = await _context.Usuarios.Where(x => x.Id == Id.ToString()).FirstOrDefaultAsync();

            suscripcione.Rol = rol;

            _context.Entry(suscripcione).State = EntityState.Modified;

            _context.SaveChanges();

            result = true;

            return result;
        }
         
        public async Task<Usuario> GetByEmail(string Email)
        {
            var user = await _context.Usuarios.Where(x => x.Email == Email.ToString()).FirstOrDefaultAsync();

            return user;
        }
    }
}
