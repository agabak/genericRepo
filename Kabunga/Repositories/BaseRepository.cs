using Kabunga.Data;
using Kabunga.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kabunga.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<TEntity> dbSet;
        public BaseRepository(DataContext dataContext)
        {
             _dataContext = dataContext;
              dbSet = _dataContext.Set<TEntity>();
        }
        public virtual async  Task<IEnumerable<TEntity>> GetAll()
        {
            var users = await dbSet.ToListAsync();
            return users;
        }
        public virtual async Task<TEntity> GetById(object id)
        {
            var user = await dbSet.FindAsync(id);
            return user;
        }
        public virtual async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }
        public virtual async Task<TEntity> Update(TEntity entity)
        {
               dbSet.Attach(entity);
               _dataContext.Entry(entity).State = EntityState.Modified;
            await  _dataContext.SaveChangesAsync();
            return entity;
        }
    }
}
