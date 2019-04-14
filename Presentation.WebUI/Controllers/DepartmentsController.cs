using ApplicationLibrary.Repository;
using CoreLibrary.Entities.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.WebUI.Helpers;
using System.Threading.Tasks;

namespace Presentation.WebUI.Controllers
{
    public class DepartmentsController : BaseController<Department>
    {
        private IRepositoryBase<Department> _repository;

        public DepartmentsController(IRepositoryBase<Department> repository):base(repository)
        {
            _repository = repository;
        }  
    }
}
