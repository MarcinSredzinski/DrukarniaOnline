using CoreLibrary.Entities.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary.Entities.Company
{
    public class JobPosition : BaseEntity
    {
        public string Name { get; set; }
        public Dictionary<EquipmentType, int> EquipmentAndRequiredQuantity { get; set; }
    }
}
