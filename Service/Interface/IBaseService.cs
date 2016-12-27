using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IBaseService<TEntity>
    {
        Guid Create(TEntity entity);
        bool Update(TEntity entity);
        bool UpdateOnly(TEntity entity);
        bool Delete(Guid id);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
