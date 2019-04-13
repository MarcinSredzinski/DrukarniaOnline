using CoreLibrary.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary.Repository
{
    public interface IEmployeeRepository : IReposotoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee dbEmployee, Employee employee);
        Task DeleteEmployeeAsync(Employee employee);
    }
}
