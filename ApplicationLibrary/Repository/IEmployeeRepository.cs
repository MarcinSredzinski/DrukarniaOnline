using CoreLibrary.Entities.Employees;
using CoreLibrary.Entities.Relations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationLibrary.Repository
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<Employee>> FindAllWithDetailsAsync();
        List<EmployeeEquipment> GetUsersEquipment(int employeeId);
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee dbEmployee, Employee employee);
        Task DeleteEmployeeAsync(Employee employee);
    }
}
