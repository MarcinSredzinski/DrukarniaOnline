using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreLibrary.Entities.Employees;
using PersistenceLibrary;
using Presentation.WebUI.Helpers;
using CoreLibrary.Entities.Company;
using ApplicationLibrary.Repository;
using CoreLibrary.Entities.Relations;
using CoreLibrary.Entities.Items;

namespace Presentation.WebUI.Controllers
{
    public class EmployeesController : BaseController<Employee>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IRepositoryBase<EmployeeEquipment> _employeeEquipmentRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IRepositoryBase<Department> _departmentRepository;

        public EmployeesController(IEmployeeRepository repository, IEquipmentRepository equipmentRepository,
            IRepositoryBase<Department> departmentRepository) : base(repository)
        {
            _repository = repository;
            _equipmentRepository = equipmentRepository;
            _departmentRepository = departmentRepository;
        }

        // GET: Employees
        public override async Task<IActionResult> Index()
        {         
            return View(await _repository.FindAllWithDetailsAsync());
        }

      
        // GET: Employees/Create
        public override IActionResult Create()
        {
            var listOfDepartments = GetAdditional<Department>(_departmentRepository);
            var listOfEquipments = GetAdditional<Equipment>(_equipmentRepository);
            ViewData["EquipmentId"] = new MultiSelectList(listOfEquipments, "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(listOfDepartments, "Id", "Name");
            ViewModels.EmployeeEquipments empeq = new ViewModels.EmployeeEquipments();
            //empeq.Equipments = listOfEquipments.Select(e => new SelectListItem
            //{
            //    Text = e.Name,
            //    Value = e.Id.ToString()
            //});
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("FirstName,LastName,DateOfBirth,WorkStartDate,IsManager,DepartmentId,EmployeeEquipments,Id")] Employee employee)
        {
            return await base.Create(employee);
        }

        // GET: Employees/Edit/5
        public override async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _repository.GetDetailsAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(await _departmentRepository.FindAllAsync(),"Id", "Name", employee.DepartmentId);
            ViewData["EquipmentId"] = new MultiSelectList(await _employeeEquipmentRepository.FindAllAsync(), "Id", "Name", employee.EmployeeEquipments);

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,DateOfBirth,WorkStartDate,IsManager,DepartmentId,EmployeeEquipments, Id")] Employee employee)
        {
            return await base.Edit(id, employee);
        }

        //// GET: Employees/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await _context.Employees
        //        .Include(e => e.Department)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee);
        //}

        //// POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Employees.Any(e => e.Id == id);
        //}
        private IEnumerable<T> GetAdditional<T>(IRepositoryBase<T> additionalRepository) where T : class
        {
            Task<IEnumerable<T>> task = Task.Run(async () => await additionalRepository.FindAllAsync());
            return task.Result;
        }
      
    }
}
