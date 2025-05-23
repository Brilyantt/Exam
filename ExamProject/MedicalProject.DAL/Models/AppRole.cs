using Microsoft.AspNetCore.Identity;

namespace MedicalProject.DAL.Models;

public class AppRole : IdentityRole
{
    public string RoleName { get; set; }
}
