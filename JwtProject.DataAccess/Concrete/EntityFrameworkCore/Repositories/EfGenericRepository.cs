using JwtProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using JwtProject.DataAccess.Interfaces;
using JwtProject.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JwtProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public async Task Add(TEntity entity)
        {
            using var context = new JwtContext();
            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            using var context = new JwtContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new JwtContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new JwtContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetById(int id)
        {
            using var context = new JwtContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task Remove(TEntity entity)
        {
            using var context = new JwtContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            using var context = new JwtContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
