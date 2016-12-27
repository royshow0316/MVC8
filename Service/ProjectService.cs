using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using MVC.Models.Interface;
using MVC.Models.Repository;
using Service.Interface;
using SQLModel.UnitOfWork;

namespace Service
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork, IRepository<Project> repository)
            : base(unitOfWork, repository)
        { }
    }
}
