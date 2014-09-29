namespace EmployeeDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EmployeeData;

    /// <summary>
    /// This class is the generated interface to the DB.
    /// </summary>
    public partial class EmployeeModel : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionName">Name of the connection to the DB in the app.config</param>
        public EmployeeModel(string connectionName)
            : base("name=" + connectionName)
        {
        }

        /// <summary>
        /// Employee accessor/mutator
        /// </summary>
        public virtual DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Role accessor/mutator
        /// </summary>
        public virtual DbSet<Role> Roles { get; set; }


        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="modelBuilder">DBModuleBuilder maps the classes to the DB schema.</param>
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

            modelBuilder.Entity<Employee>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
