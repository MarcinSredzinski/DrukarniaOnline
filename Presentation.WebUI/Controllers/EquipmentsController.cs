using ApplicationLibrary.Repository;
using CoreLibrary.Entities.Items;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.WebUI.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebUI.Controllers
{
    public class EquipmentsController : BaseController<Equipment>
    {
        private readonly IEquipmentRepository _repository;
        private readonly IEquipmentTypeRepository _equipmentTypeRepository;

        public EquipmentsController(IEquipmentRepository repository, IEquipmentTypeRepository equipmentTypeRepository) : base(repository)
        {
            _repository = repository;
            _equipmentTypeRepository = equipmentTypeRepository;
        }

        public override async Task<IActionResult> Index()
        {
            return View(await _repository.FindAllWithDetailsAsync());
        }

        public override IActionResult Create()
        {
            var lista = GetTypes();           
            ViewData["TypeId"] = new SelectList(lista, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Name,Produced,GivenToEmployee,ExpirationDate,TypeId,Id")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(equipment);
                await _repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
              ViewData["TypeId"] = new SelectList(await _equipmentTypeRepository.FindAllAsync(), "Id", "Name", equipment.TypeId);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public override async Task<IActionResult> Edit(int? id) //todo look into editing of items
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _repository.GetDetailsAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(await _equipmentTypeRepository.FindAllAsync(), "Id", "Name", equipment.TypeId);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(int id, [Bind("Name,Produced,GivenToEmployee,ExpirationDate,TypeId,Id")] Equipment equipment)
        {
            return await base.Edit(id, equipment);       
        }


        private IEnumerable<EquipmentType> GetTypes()
        {
            Task<IEnumerable<EquipmentType>> task = Task.Run(async () => await _equipmentTypeRepository.FindAllAsync());
            return task.Result;
        }

        //private bool EquipmentExists(int id)
        //{
        //    return _context.Equipments.Any(e => e.Id == id);
        //}
    }
}
