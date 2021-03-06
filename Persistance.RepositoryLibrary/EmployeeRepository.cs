﻿using ApplicationLibrary.Repository;
using CoreLibrary.Entities.Employees;
using CoreLibrary.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using PersistenceLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.RepositoryLibrary
{
    public class EmployeeRepository : RepositoryBase<Employee>, IRepositoryBase<Employee>, IEmployeeRepository
    {
        private DrukarniaDbContext _drukarniaDbContext;
        public EmployeeRepository(DrukarniaDbContext drukarniaDbContext)
           : base(drukarniaDbContext)
        {
            _drukarniaDbContext = drukarniaDbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await FindAllAsync();
            return employees.OrderBy(x => x.LastName);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await FindByConditionAsync(e => e.Id.Equals(employeeId));
            return employee.DefaultIfEmpty(new Employee())
                    .FirstOrDefault();
        }
        public async Task<IEnumerable<Employee>> FindAllWithDetailsAsync()
        {
            return await _dbContext.Set<Employee>().Include(e => e.Department).ToListAsync<Employee>();
        }

        public new async Task<Employee> GetDetailsAsync(int id)
        {
            return await _dbContext.Set<Employee>().Include(e => e.EmployeeEquipments).Include(d=> d.Department).FirstOrDefaultAsync(i => i.Id == id);
        }
        public new async Task<Employee> GetDetailsAsync(int? id)
        {
            if (int.TryParse(id.ToString(), out int certainId))
            {
                return await _dbContext.Set<Employee>().Include(e => e.EmployeeEquipments).Include(d => d.Department).FirstOrDefaultAsync(i => i.Id == certainId);
            }
            else
            {
                return null;
            }
        }



        public List<EmployeeEquipment> GetUsersEquipment(int employeeId)
        {
            var employeeequipment4 =  _drukarniaDbContext.EmployeeEquipments
                          .Include(e => e.Equipment)
                          .Include(e=>e.Employee)
                         .ToList<EmployeeEquipment>();
            //   .Where(ee => ee.EmployeeId == employeeId).ToList<EmployeeEquipment>();

            return  employeeequipment4;
           
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            Create(employee);
            await SaveAsync();
        }

        public async Task UpdateEmployeeAsync(Employee dbEmployee, Employee employee)
        {
            Update(employee);
            await SaveAsync();
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            Delete(employee);
            await SaveAsync();
        }

    }
}
