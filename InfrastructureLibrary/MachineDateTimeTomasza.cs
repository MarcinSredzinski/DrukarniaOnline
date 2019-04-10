using ApplicationLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLibrary
{
    public class MachineDateTimeTomasza : IDateTime
    {
        public DateTime Now => System.DateTime.Now.AddDays(4);
    }
}
