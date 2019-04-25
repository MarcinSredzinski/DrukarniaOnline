using CoreLibrary.Entities.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CoreLibrary.Entities.Items
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Produced { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime GivenToEmployee { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }

        public List<EmployeeEquipment> EmployeeEquipments { get; set; }
        public int TypeId { get; set; }
        public EquipmentType Type { get; set; }

    }
}
