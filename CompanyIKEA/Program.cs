using BLL.Models_DTOS__CustomModel_.Departments;
using BLL.Models_DTOS__CustomModel_.Employee;
using BLL.Services;
using CompanyIKEAPL.Filtters;
using CompanyIKEAPL.Helper;
using CompanyIKEAPL.Helper.Mail;
using DAL.Entities.Identity;
using DAL.Presistance.DATA.AppDbContext;
using DAL.Presistance.DATA.DataSeed;
using DAL.Presistance.Repo.Departments;
using DAL.Presistance.Repo.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using NuGet.Protocol.Plugins;
using System.Composition;
using System.Configuration;

namespace CompanyIKEA
{
    public class Program
    {
     
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Servicess

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register the custom exception filter globally
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<HandelException>();
            });
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();  
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            //builder.Services.AddScoped<IMailSetting, MailSetting>();
            builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                CloseButton = true,
                Debug = false,
                PositionClass = "toast-top-right", // Choose the position of the toast
                ShowDuration = 300, // Duration for showing toast
               // Duration for hiding toast
                TimeOut = 5000, // Duration before the toast automatically disappears
                ExtendedTimeOut = 1000, // Extra time before the toast disappears after hovering over it
               
            });


            builder.Services.AddIdentity<ApplacationUserIdentity, IdentityRole>((option) =>
            {

                option.Password.RequireNonAlphanumeric = false;//Required spachal character    [ ( *&)^%$#@!~ ]
                option.Password.RequireDigit = false;   
                option.Password.RequiredLength = 4;
                option.Password.RequireUppercase = false;
                option.Password.RequiredUniqueChars = 0;
                option.User.RequireUniqueEmail = true;
                option.Lockout.AllowedForNewUsers = true;   //this allw user signOut 
                option.Lockout.MaxFailedAccessAttempts = 4;//4 timesAfter Close Accuont
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(3.5);// if Eter More log in Filed Close Account fot Time 

            }).AddEntityFrameworkStores<ApplicationDbContext>();//.AddUserStore() for Add stor Defrant Default Implemmlemt

            //AddIdentity Call this method For Register  ManoServices  And ServicesIndpend Such ConfigureApplicationCookie(configure)
            //internal Call  builder.Services.AddAuthentication("Identity.Applecation");

            // builder.Services.AddAuthentication("Hamad"); use this When Cange Default Schema


            builder.Services.AddAuthentication(op => { //this  use Change Default And Anther 

                op.DefaultChallengeScheme = "Identity.Applecation";//Default On All Applacation
                op.DefaultChallengeScheme = "Hamad";// Challenge Default Schema On All Applacation


            }); 

            builder.Services.ConfigureApplicationCookie(configure => { // Configrations For Schema Genaret Token

                configure.LoginPath = "/Authentication/SignIn";

                configure.AccessDeniedPath =new PathString("/Home/Error"); //this is object not contin this Role  go this page
                configure.LogoutPath = new PathString();
                
                configure.ExpireTimeSpan = TimeSpan.FromDays(1);// Expire token 
                configure.LogoutPath = new PathString("/Authentication/SignUp"); //For
                                                                                 //
                                                                                 //
                                                                                 //
                                                                                 //
                                                                                 //Sign Out Go to this Path=>/Authentication/SignIn
            });

            #endregion

            builder.Services.Configure<MailSetings>(builder.Configuration.GetSection("MeilSetangs"));

          var app = builder.Build();

            #region Configure Kestrel Middlewares
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllerRoute(
             name: "default",
                    pattern: "{controller=Authentication}/{action=SignUp}/{id?}");
            #endregion

            app.Run();
        }
    }
}
