using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using MVC.Models.Interface;
using System.Linq.Expressions;
using SQLModel.DbContextFactory;
using SQLModel.Models;
using SQLModel.UnitOfWork;

namespace MVC.Models.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseModel 
    {
        public IDbSet<TEntity> DbSet { get; set; }
        public DbContext DbContext { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.DbContext = unitOfWork.Context;
            this.DbSet = DbContext.Set<TEntity>();
        }

        public virtual Guid Create(TEntity entity)
        {
            dynamic obj = DbSet.Add(entity);
            return obj.Id;
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.Entry(entity).Property(x => x.CreateDate).IsModified = false;
            DbContext.Entry(entity).Property(x => x.CreatorId).IsModified = false;
        }

        public virtual Guid Delete(TEntity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dynamic obj = DbSet.Remove(entity);

            return obj.Id;
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }
    }
}