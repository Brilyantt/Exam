using MedicalProject.BL.ViewModels;
using MedicalProject.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicalProject.BL.Services;

public class AccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<AppRole> _roleManager;
    public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<string> RegisterAsync(AccountRegisterVM accountRegisterVM)
    {
        AppUser appUser = new AppUser();
        appUser.UserName = accountRegisterVM.UserName;
        appUser.Email = accountRegisterVM.EmailAddress;

        IdentityResult result = await _userManager.CreateAsync(appUser, accountRegisterVM.Password);
        if (!result.Succeeded)
        {
            string errorMessage = string.Empty;
            foreach (var error in result.Errors)
            {
                errorMessage += errorMessage + error.Description + "\n";

            }
        }

        result = await _userManager.AddToRoleAsync(appUser, "Admin");
        if (!result.Succeeded)
        {
            string errorMessage = string.Empty;
            foreach (var error in result.Errors)
            {
                errorMessage += errorMessage + error.Description + "\n";

            }
        }

        return "Ok";
    }

    public async Task<string> LoginAsync(AccountLoginVM accountLoginVM)
    {
        AppUser? appUser = await _userManager.FindByEmailAsync(accountLoginVM.UsernameOrEmail) ?? await _userManager.FindByNameAsync(accountLoginVM.UsernameOrEmail);
        if (appUser is null)
        {
            return "bele bir istifadeci yoxdur";
        }

        bool IsCorrect = await _userManager.CheckPasswordAsync(appUser, accountLoginVM.Password);
        if (!IsCorrect)
        {
            return "Sifre yalnisdir";
        }
        await _signInManager.SignInAsync(appUser, true);

        return "Ok";
    }

    public async Task<string> CreateRole()
    {
        AppRole appRole = new AppRole()
        {
            Name = "Admin",
            RoleName = "Test"
        };
        bool result = await _roleManager.RoleExistsAsync(appRole.Name);

        return "Ok";
    }
}
