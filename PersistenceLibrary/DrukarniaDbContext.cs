using CoreLibrary.Entities.Company;
using CoreLibrary.Entities.Employees;
using CoreLibrary.Entities.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CoreLibrary.Entities.Relations;
using CoreLibrary.Entities.Inventory;

namespace PersistenceLibrary
{
    public class DrukarniaDbContext : IdentityDbContext, IDrukarniaDbContext  
    {
        public DrukarniaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeEquipment> EmployeeEquipments { get; set;}
        public DbSet<UnasignedEquipment> UnasignedEquipments { get; set; }
    }
}

