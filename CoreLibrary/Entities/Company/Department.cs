using CoreLibrary.Entities.Employees;
using System.Linq;

namespace CoreLibrary.Entities.Company
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }

        public IQueryable<Employee> Employees { get; set; }      

    }
}
