using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Entities.Items;
using PersistenceLibrary;
using ApplicationLibrary.Repository;
using Presentation.WebUI.Helpers;

namespace Presentation.WebUI.Controllers
{
    public class CertificatesController : BaseController<Certificate>
    {
        private readonly IRepositoryBase<Certificate> _repository;

        public CertificatesController(IRepositoryBase<Certificate> repository):base(repository)
        {
            _repository = repository;
        }      
    }
}
