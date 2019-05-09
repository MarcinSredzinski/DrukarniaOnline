using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebUI.ViewModels
{
    public class EmployeeEquipments
    {
        public IQueryable<SelectListItem> Equipments { get; set; }
    }
}
