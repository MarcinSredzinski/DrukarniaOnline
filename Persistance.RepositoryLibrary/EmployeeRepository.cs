using ApplicationLibrary.Repository;
using CoreLibrary.Entities.Employees;
using PersistenceLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.RepositoryLibrary
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private DrukarniaDbContext _drukarniaDbContext;
        public EmployeeRepository(DrukarniaDbContext _drukarniaDbContext)
           : base(_drukarniaDbContext)
        {
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

        //public async Task<OwnerExtended> GetOwnerWithDetailsAsync(Guid ownerId)
        //{
        //    var owner = await GetOwnerByIdAsync(ownerId);

        //    return new OwnerExtended(owner)
        //    {
        //        Accounts = await RepositoryContext.Accounts
        //            .Where(a => a.OwnerId == ownerId).ToListAsync()
        //    };
        //}

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
