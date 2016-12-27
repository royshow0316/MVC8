using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SQLModel.UnitOfWork;

namespace MVC.Models.Interface
{
    public interface IRepository<TEntity>
    {
        IUnitOfWork UnitOfWork { get; set; }

        Guid Create(TEntity entity);

        void Update(TEntity entity);

        Guid Delete(TEntity entity);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        TEntity GetById(Guid id);
    }
}
