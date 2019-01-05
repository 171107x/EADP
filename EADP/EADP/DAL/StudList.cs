using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP.DAL
{
    public class StudList
    {
        public string studentAdmin { get; set; }
        public string studentName { get; set; }
        public string studentPassword { get; set; }
        public string studentImage { get; set; }
        public string gender { get; set; }
        public string diploma { get; set; }
        public DateTime DOB { get; set; }
        public string pemGroup { get; set; }
        public string nationality { get; set; }
        public string MobileNO { get; set; }
        public string passportNo { get; set; }
        public DateTime passportE { get; set; }
        public string DietConstraint { get; set; }
        public string MedicalHistory { get; set; }
        public string FASscheme { get; set; }
        public string Remarks { get; set; }

    }
}