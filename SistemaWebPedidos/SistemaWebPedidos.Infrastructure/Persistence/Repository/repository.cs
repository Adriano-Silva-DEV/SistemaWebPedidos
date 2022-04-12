using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using SistemaWebPedidos.Core.Entities;


namespace SistemaWebPedidos.Infrastructure.Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ApiDbContext _apiDbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ApiDbContext apiDbContext)
        {
            this._apiDbContext = apiDbContext; 
            this._apiDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.DbSet = apiDbContext.Set<TEntity>();

        }
        public virtual async Task<TEntity> Adcionar(TEntity entity)
        {
            DbSet.Add(entity);
          await SaveChange();
            return entity;
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            _apiDbContext.Entry(entity).State = EntityState.Modified;
            _apiDbContext.Update(entity);

            await SaveChange();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate)
                .ToListAsync();
        }


        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChange();
        }

        public async Task<int> SaveChange()
        {
            return await _apiDbContext.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            _apiDbContext?.Dispose();
           
        }

    }
}