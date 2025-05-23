using MedicalProject.BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.MVC.Areas.Admin.Controllers;
[Area("Admin")]

public class DashboardController : Controller
{
    private readonly DoctorService _doctorService;
    public DashboardController(DoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    public IActionResult Index()
    {
        return View();
    }
}
