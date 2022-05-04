using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SistemaWebPedidos.Core.Entities;

namespace SistemaWebPedidos.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {

        public Task<TEntity> Adcionar(TEntity entity);

        public Task<TEntity> ObterPorId(Guid id);

        public Task<List<TEntity>> ObterTodos();

        public Task Atualizar(TEntity entity);

        public Task Remover(Guid id);

        public Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        public Task<int> SaveChange();
    }
}
