using CoreLibrary.Entities.Employees;
using CoreLibrary.Entities.Items;
using System;

namespace CoreLibrary.Entities.Relations
{
    public class EmployeeEquipment : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public DateTime GivenOut { get; set; }
    }
}
