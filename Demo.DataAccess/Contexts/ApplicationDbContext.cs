
using System.Reflection;

namespace Demo.DataAccess.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) /*1*/: DbContext(options)/*2*/
                                                            //1.Primary Constractor Here Represent ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
                                                            //2.Primary Constractor Here Represent Base(Option )
    {
        public DbSet<Department> Departments  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
