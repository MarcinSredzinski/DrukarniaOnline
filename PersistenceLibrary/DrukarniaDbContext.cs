using CoreLibrary.Entities.Company;
using CoreLibrary.Entities.Employees;
using CoreLibrary.Entities.Inventories.It;
using CoreLibrary.Entities.Inventory;
using CoreLibrary.Entities.Items;
using CoreLibrary.Entities.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<EmployeeEquipment> EmployeeEquipments { get; set; }
        public DbSet<UnasignedEquipment> UnasignedEquipments { get; set; }
        public DbSet<DeviceInfo> DeviceInfos { get; set; }
        public DbSet<Software> Softwares { get; set; }
    }
}

