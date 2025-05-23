
using MedicalProject.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalProject.DAL.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Doctor> Doctors { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
