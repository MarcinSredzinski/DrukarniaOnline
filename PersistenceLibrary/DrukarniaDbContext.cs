using CoreLibrary.Entities.Company;
using CoreLibrary.Entities.Employees;
using CoreLibrary.Entities.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace PersistenceLibrary
{
    public class DrukarniaDbContext : IdentityDbContext //DbContext
    {
        public DrukarniaDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}

