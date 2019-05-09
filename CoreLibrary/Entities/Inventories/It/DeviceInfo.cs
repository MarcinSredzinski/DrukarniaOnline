using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary.Entities.Inventories.It
{
    public class DeviceInfo:BaseEntity
    {
        public DateTime DateOfPurchase { get; set; }
        public string Owner { get; set; }
        public IEnumerable<Software> Software { get; set; }
    }
}
