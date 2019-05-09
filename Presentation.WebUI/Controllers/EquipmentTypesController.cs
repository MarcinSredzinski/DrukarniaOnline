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
        public IRepositoryBase<Certificate> _certificateRepository { get; set; }
        public IEquipmentTypeRepository _equipmentTypesRepository { get; set; }

        public EquipmentTypesController(IEquipmentTypeRepository repository, IRepositoryBase<Certificate> certificateRepository) : base(repository)
        {
            _equipmentTypesRepository = repository;
            _certificateRepository = certificateRepository;
        }
        public override async Task<IActionResult> Index()
        {
            return View(await _equipmentTypesRepository.FindAllWithDetailsAsync());
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
                _equipmentTypesRepository.Create(entity);
                await _equipmentTypesRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        // GET: EquipmentTypes/Edit/5
        public override async Task<IActionResult> Edit(int? id) //todo look into editing of items
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _equipmentTypesRepository.GetDetailsAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            ViewData["CertificateId"] = new SelectList(await _certificateRepository.FindAllAsync(), "Id", "Name", equipment.CertificateId);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(int id, [Bind("Name,Producent,Size,SpecialDateTime,CertificateId,Id")] EquipmentType equipmentType)
        {
            return await base.Edit(id, equipmentType);
        }


        private IEnumerable<Certificate> GetCertificates()
        {
            Task<IEnumerable<Certificate>> task =Task.Run(async() =>  await _certificateRepository.FindAllAsync());
            return task.Result;
        }
    }
}
