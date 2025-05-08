using Infraestructura.Contracts;
using Infraestructura.Models;
using Infrastucture.Contracts;
using Infrastucture.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly SistemaContext _context;

        private IUsuariosRepository _usuariosRepository;
        public IUsuariosRepository usuariosRepository => _usuariosRepository ??
         new UsuariosRepository(_context);

        private IRolRepository _rolRepository;
        public IRolRepository rolRepository => _rolRepository ??
         new RolRepository(_context);

        public UnitOfWork(SistemaContext context)
        {
            _context = context;
        }

        public SistemaContext pedidosPacificoAzureContext => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class, new()
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
