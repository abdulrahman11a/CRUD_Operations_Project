using DAL.Entities;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Principal;

namespace DAL.Presistance.DATA.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplacationUserIdentity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //call Configuration for  Tabls such that (IdentityRole,Identityuser,Identitylogin )
           // atherowes DbContext is Emty not contain Table
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());// Apply configurations Any Class inharnt IEntityTypeConfiguration from the assembly
        }
   
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
