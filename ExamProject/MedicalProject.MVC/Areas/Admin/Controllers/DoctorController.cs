using MedicalProject.BL.Services;
using MedicalProject.BL.ViewModels;
using MedicalProject.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class DoctorController : Controller
{
    private readonly DoctorService _doctorService;
    public DoctorController(DoctorService doctorService)
    {
        _doctorService = doctorService;
    }


    public IActionResult Index()
    {
        List<Doctor> doctors = _doctorService.Doctors();
        return View(doctors);
    }

    [HttpGet]
    public IActionResult Info(int id)
    {
        Doctor doctor = _doctorService.GetDoctorById(id);
        return View(doctor);
    }

    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(DoctorVM doctorVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _doctorService.Create(doctorVM);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Update
    [HttpGet]
    public IActionResult Update(int id)
    {
        Doctor doctor = _doctorService.GetDoctorById(id);
        return View(doctor);
    }
    [HttpPost]
    public IActionResult Update(int id, Doctor doctor)
    {
        _doctorService.Update(id, doctor);
        return RedirectToAction(nameof(Index));
    }


    #endregion

    #region Delete
    [HttpGet]
    public IActionResult Delete(int id)
    {
        Doctor doctor = _doctorService.GetDoctorById(id);
        return View(doctor);
    }
    [HttpPost]
    [ActionName("Delete")]

    public IActionResult DeleteItem(int id)
    {
        _doctorService.Delete(id);
        return RedirectToAction(nameof(Index));
    }


    #endregion


}
