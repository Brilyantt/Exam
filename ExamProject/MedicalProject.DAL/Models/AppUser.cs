using Microsoft.AspNetCore.Identity;

namespace MedicalProject.DAL.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
}
