using CoreLibrary.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLibrary.Entities.Items
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Produced { get; set; }
        public DateTime GivenToEmployee { get; set; }
        public DateTime ExpirationDate { get; set; }

        public IQueryable<EmployeeEquipment> EmployeeEquipments { get; set; }
        public int TypeId { get; set; }
        public EquipmentType Type { get; set; }

    }
}
