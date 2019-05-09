using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary.Entities.Inventories.It
{
    public class Software:BaseEntity
    {
        public string NameOfProgramm { get; set; }
        public string LicenseInfo{ get; set; }
        public int DeviceId { get; set; }
        public DeviceInfo Device { get; set; }
    }
}
