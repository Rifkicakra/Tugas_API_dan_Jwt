using API_dan_JWT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace API_dan_JWT.Context
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {

        }

        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual  DbSet<Department> Departments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        //protected override void OnModelCreating(MyContext modebuilder)
        //{
        //    modebuilder.Entity<User>(entity =>
        //    { 
        //        entity.
        //    });


        //}

    }
}
