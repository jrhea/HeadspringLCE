namespace EmployeeDirectory.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeDirectoryModel : DbContext
    {
        public EmployeeDirectoryModel()
            : base("name=EmployeeDirectoryModel")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.WorkPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.HomePhone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<JobTitle>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<JobTitle>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.JobTitle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);
        }
    }
}
