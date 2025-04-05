using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseType
    {
        int Add(TEntity entity);
        int Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        TEntity? GetById(int id);
        int Update(TEntity entity);
    }
}
