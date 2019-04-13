using ApplicationLibrary.Repository;
using CoreLibrary.Entities.Items;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance.RepositoryLibrary;
using Presentation.WebUI.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebUI.Controllers
{
    public class EquipmentTypesController : BaseController<EquipmentType>
    {
        public IReposotoryBase<Certificate> _certificateRepository { get; set; }
        public IReposotoryBase<EquipmentType> _equipmentRepository { get; set; }

        public EquipmentTypesController(IReposotoryBase<EquipmentType> repository, IReposotoryBase<Certificate> certificateRepository) : base(repository)
        {
            _equipmentRepository = repository;
            _certificateRepository = certificateRepository;
        }
        public override async Task<IActionResult> Index()
        {
            return View(await (_equipmentRepository as EquipmentTypeRepository).FindAllWithDetailsAsync());
        }
        public override  IActionResult Create()
        {
            var lista = GetCertificates();
            var certificates = lista.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList<SelectListItem>();
            ViewData["certificates"] = certificates;
            return View();
        }
        // POST: ControllerName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Name,Id, CertificateId, Producent, Size")] EquipmentType entity)
        {
            if (ModelState.IsValid)
            {
                _equipmentRepository.Create(entity);
                await _equipmentRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }


        private IEnumerable<Certificate> GetCertificates()
        {
            Task<IEnumerable<Certificate>> task =Task.Run<IEnumerable<Certificate>>(async() =>  await _certificateRepository.FindAllAsync());
            return task.Result;
        }
    }
}
