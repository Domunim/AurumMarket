using AurumMarket.Domain.Models;
using AurumMarket.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.EntityFramework.Services
{
    public class GenericDataServices<T> : IDataServices<T> where T : DomainObjectModel
    {
        private readonly AurumMarketDbContextFactory _contextFactory;

        public GenericDataServices(AurumMarketDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (AurumMarketDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (AurumMarketDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

                context.Set<T>().Remove(entity);

                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> GetById(int id)
        {
            using (AurumMarketDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (AurumMarketDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (AurumMarketDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);

                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
