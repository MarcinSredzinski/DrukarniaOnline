using CoreLibrary.Entities.Company;
using CoreLibrary.Entities.Items;
using CoreLibrary.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLibrary.Entities.Employees
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime WorkStartDate { get; set; }
        public bool IsManager { get; set; }

        public IQueryable<EmployeeEquipment> EmployeeEquipments { get; set; }

        public int DepartmentId { get; set; } 
        public Department Department { get; set; }
    }
}
