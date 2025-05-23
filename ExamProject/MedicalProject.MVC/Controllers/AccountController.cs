using MedicalProject.BL.Services;
using MedicalProject.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.MVC.Controllers;

public class AccountController : Controller
{
    private readonly AccountService _accountService;
    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(AccountRegisterVM accountRegisterVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _accountService.RegisterAsync(accountRegisterVM);
        return RedirectToAction(nameof(Login));
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(AccountLoginVM accountLoginVM)
    {
        _accountService.LoginAsync(accountLoginVM);
        return RedirectToAction(nameof(Index), "Home");
    }

}
