using ApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLibrary
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => System.DateTime.Now.AddYears(3);
        public int CurrentYear => System.DateTime.Now.Year;
    }
}
