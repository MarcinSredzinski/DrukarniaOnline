using CoreLibrary.Entities.Employees;
using System.Collections.Generic;
using System.Linq;

namespace CoreLibrary.Entities.Company
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
        
    }
}
