using MedicalProject.BL.Exceptions;
using MedicalProject.BL.ViewModels;
using MedicalProject.DAL.Contexts;
using MedicalProject.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalProject.BL.Services;

public class DoctorService
{
    private readonly AppDbContext _context;
    public DoctorService(AppDbContext context)
    {
        _context = context;
    }


    #region Create

    public void Create(DoctorVM doctorVM)
    {
        Doctor doctor = new Doctor();
        doctor.DoctorName = doctorVM.DoctorName;
        doctor.Category = doctorVM.Category;
        doctor.EmailAddress = doctorVM.EmailAddress;
        doctor.PhoneNumber = doctorVM.PhoneNumber;

        string fileName = Path.GetFileNameWithoutExtension(doctorVM.File.FileName);
        string extension = Path.GetExtension(doctorVM.File.FileName);
        string fullName = fileName + Guid.NewGuid().ToString() + extension;
        Console.WriteLine(fullName);

        doctor.ImgPath = fullName;
        string updatedPath = "C:\\Users\\ca r221.14\\Desktop\\AdminPanel\\Medical.Exam\\MedicalProject.MVC\\wwwroot\\assets\\images\\img";

        updatedPath = Path.Combine(updatedPath, fullName);

        using FileStream fileStream = new FileStream(updatedPath, FileMode.Create);

        doctorVM.File.CopyTo(fileStream);

        _context.Doctors.Add(doctor);
        _context.SaveChanges();


    }


    #endregion

    #region Read

    public List<Doctor> Doctors()
    {
        return _context.Doctors.ToList();
    }

    public Doctor GetDoctorById(int id)
    {
        Doctor doctor = _context.Doctors.Find(id);
        if (doctor is not null)
        {
            return doctor;
        }
        throw new DoctorException($"database-de {id}-li melumat yoxdur");
    }

    #endregion

    #region Update
    public Doctor Update(int id, Doctor updatedDoctor)
    {
        if (id != updatedDoctor.Id)
        {
            throw new DoctorException($"database-de {id}-li melumat yoxdur");

        }

        Doctor? baseDoctor = _context.Doctors.AsNoTracking().SingleOrDefault(d => d.Id == id);
        if (baseDoctor != null)
        {
            return baseDoctor;
        }
        throw new DoctorException($"database-de {id}-li melumat yoxdur");

        _context.Doctors.Update(updatedDoctor);
        _context.SaveChanges();

    }

    #endregion

    #region Delete


    public void Delete(int id)
    {
        Doctor? doctor = _context.Doctors.Find(id);
        if (doctor is not null)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
        else
        {
            throw new DoctorException($"database-de {id}-li melumat yoxdur");

        }
    }
    #endregion


}
