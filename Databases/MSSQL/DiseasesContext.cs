using DataWarehouse.Models;
using Microsoft.EntityFrameworkCore;

namespace DataWarehouse.Databases.MSSQL
{
    public class DiseasesContext : DbContext
    {
        public DiseasesContext()
        {
            
        }
        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DiseaseHospitalHistory> DiseaseHospitalHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\\MSSQLLocalDB;Database=DiseasesDB;Trusted_Connection=True;");
        }
    }
}