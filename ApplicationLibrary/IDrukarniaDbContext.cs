using CoreLibrary.Entities.Company;
using CoreLibrary.Entities.Employees;
using CoreLibrary.Entities.Items;
using CoreLibrary.Entities.Relations;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLibrary
{
    public interface IDrukarniaDbContext 
    {
        DbSet<Certificate> Certificates { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Equipment> Equipments { get; set; }
        DbSet<EquipmentType> EquipmentTypes { get; set; }
        DbSet<EmployeeEquipment> EmployeeEquipments { get; set; }
    }
}