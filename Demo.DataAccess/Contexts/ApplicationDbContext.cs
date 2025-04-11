using System.Reflection;
using Demo.DataAccess.Models.IdentiyModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Demo.DataAccess.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) /*1*/: IdentityDbContext<ApplicationUser>(options)/*2*/
                                                            //1.Primary Constractor Here Represent ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
                                                            //2.Primary Constractor Here Represent Base(Option )
    {
        public DbSet<Department> Departments  { get; set; }
        public DbSet<Employee> Employees  { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
