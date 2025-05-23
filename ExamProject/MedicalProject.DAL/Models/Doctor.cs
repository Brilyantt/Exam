using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProject.DAL.Models
{
    public class Doctor : BaseModel
    {
        public string ImgPath { get; set; }
        public string DoctorName { get; set; }
        public string Category { get; set; }
        public string  PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
