using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kabunga.Repositories.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(string id);
        Task Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
    }
}
