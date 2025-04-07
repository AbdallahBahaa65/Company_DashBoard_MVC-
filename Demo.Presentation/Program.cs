using Demo.BusinessLogic.Profiles;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Contexts;
using Demo.DataAccess.Repositories.Class.DepartmentRepositry;
using Demo.DataAccess.Repositories.Class.EmployeeRepository;
using Demo.DataAccess.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region USe MVC Servece In Container 

            builder.Services.AddControllersWithViews( Options=>
            {
                Options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());


            });
            //builder.Services.AddScoped<ApplicationDbContext>(); // 2.Register to Service In DI Container 
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                //options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
                //options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
            } , ServiceLifetime.Scoped);

            builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();
            builder.Services.AddTransient<IDepartmentService,DepartmentService>();
            //builder.Services.AddScoped<IDepartmentService,DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeSerivces,EmployeeSerivces>();

            //builder.Services.AddAutoMapper(typeof(MapperProfiles).Assembly);
            builder.Services.AddAutoMapper(M=>M.AddProfile(new MapperProfiles()));

            #endregion

            var app = builder.Build();


            #region Confige  HTTP Request MiddleWares 
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); 
            #endregion

            app.Run();
        }
    }
}
