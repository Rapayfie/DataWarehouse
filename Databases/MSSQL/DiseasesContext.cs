using DataWarehouse.Models;
using Microsoft.EntityFrameworkCore;

namespace DataWarehouse.Databases.MSSQL
{
    public class DiseasesContext : DbContext
    {
        #region Constructor
        public DiseasesContext() 
            : base()
        {
            _ = Database.EnsureCreated();
        }
        #endregion

        #region Public Properties
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DiseaseHospitalHistory> DiseaseHospitalHistories { get; set; }
        #endregion
        
        #region Overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                               Database=DiseasesDB;
                               Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder
                .Entity<Patient>()
                .HasMany(e => e.Diseases)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Disease>()
                .HasMany(e => e.DiseaseHospitalHistory)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
        #endregion
    }
}