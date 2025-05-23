using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MedicalProject.BL.ViewModels
{
    public class DoctorVM
    {
        [Required(ErrorMessage = "File bos gonterile bilmez")]
        public IFormFile File { get; set; }


        [Required(ErrorMessage = "hekimin adi  mutleq olmalidir")]
        public string DoctorName { get; set; }


        [Required(ErrorMessage = "Category   mutleq secilmelidr")]
        public string Category { get; set; }


        [Required(ErrorMessage = "Nomreni qeyd edin")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Email adresi yazin!")]
        public string EmailAddress { get; set; }
    }
}
