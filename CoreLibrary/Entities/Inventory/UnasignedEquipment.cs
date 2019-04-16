using CoreLibrary.Entities.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary.Entities.Inventory
{
    public class UnasignedEquipment : BaseEntity
    {
        public Equipment Equipment { get; set; }
        public int EquipmentId { get; set; }
        public int NumberOfElements { get; set; }
    }
}
