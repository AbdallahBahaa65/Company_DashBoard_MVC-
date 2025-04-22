using System.Net;
using Demo.BusinessLogic.Profiles;
using Demo.BusinessLogic.Services.AttachmentServices;
using Demo.BusinessLogic.Services.AttachmentServices.AttachmentServices;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Contexts;
using Demo.DataAccess.Models.IdentiyModel;
using Demo.DataAccess.Repositories.Class;
using Demo.DataAccess.Repositories.Class.DepartmentRepositry;
using Demo.DataAccess.Repositories.Class.EmployeeRepository;
using Demo.DataAccess.Repositories.Interface;
using Demo.Presentation.Helpers;
using Demo.Presentation.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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

            //builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();
            builder.Services.AddTransient<IDepartmentService,DepartmentService>();
            //builder.Services.AddScoped<IDepartmentService,DepartmentService>();
            //builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeSerivces,EmployeeSerivces>();
            builder.Services.AddScoped<IUniteOfWork,UniteOfWork>();
            builder.Services.AddScoped<IAttachmentServices,AttachmentService>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();



            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));


            
            builder.Services.Configure<SmsSettings>(builder.Configuration.GetSection("Twilio"));




            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                options =>
                {
                    options.LogoutPath = "/Account/LogIn";
                    options.AccessDeniedPath = "/Home/Error";
                    options.LogoutPath = "/Account/LogIn";
                }

                );


            //builder.Services.AddAutoMapper(typeof(MapperProfiles).Assembly);
            builder.Services.AddAutoMapper(M=>M.AddProfile(new MapperProfiles()));
            builder.Services.AddTransient<IMailService,MailService>();
            builder.Services.AddTransient<ISmsService,SmsService>();

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
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); 
            #endregion

            app.Run();
        }
    }
}
