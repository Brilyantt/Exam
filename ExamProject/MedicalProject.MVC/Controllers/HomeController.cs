using MedicalProject.BL.Services;
using MedicalProject.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.MVC.Controllers;

public class HomeController : Controller
{
    private readonly DoctorService _doctorService;
    public HomeController(DoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public IActionResult Index()
    {
        List<Doctor> doctors = _doctorService.Doctors();
        return View(doctors);
    }
}
