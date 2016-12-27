using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using MVC.Models.Interface;
using Service.Helpers;
using Service.Interface;
using SQLModel.Models;
using SQLModel.UnitOfWork;

namespace Service
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseModel
    {
        private readonly IUnitOfWork _unitOfWork;
        protected IRepository<TEntity> _repository { get; set; }

        public BaseService(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public virtual Guid Create(TEntity entity)
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();
            entity.CreatorId = entity.CreatorId.IsNotEmptyOrNull() ? entity.CreatorId : userId;
            entity.CreateDate = DateTime.Now;
            entity.ModifyId = userId;
            entity.ModifyDate = DateTime.Now;
            var result =  _repository.Create(entity);
            _repository.UnitOfWork.SaveChange();
            return result;
        }

        public virtual bool Update(TEntity entity)
        {
            bool result = false;
            if (null != entity)
            {
                entity.ModifyId = HttpContext.Current.User.Identity.GetUserId();
                entity.ModifyDate = DateTime.Now;
                _repository.Update(entity);
                _unitOfWork.SaveChange();
                result = true;
            }
            return result;
        }

        public virtual bool UpdateOnly(TEntity entity)
        {
            bool result = false;
            if (null != entity)
            {
                _repository.Update(entity);
                _unitOfWork.SaveChange();
                result = true;
            }
            return result;
        }

        public virtual bool Delete(Guid id)
        {
            var entity = _repository.GetById(id);
            var result = _repository.Delete(entity);
            _repository.UnitOfWork.SaveChange();
            return result == id;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            var result = _repository.GetAll();
            return result;
        }

        public virtual TEntity GetById(Guid id)
        {
            var result = _repository.GetById(id);
            return result;
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }
    }
}
