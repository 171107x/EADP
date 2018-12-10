using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP.DAL
{
    public class StudReg
    {
        public string studentAdmin { get; set; }
        public int tripID { get; set; }
        public string nationality { get; set; }
        public string MobileNO { get; set; }

        public string PassportNO { get;set;}

        public string PassportExpiry{ get;set;}
        public string DietConstraint{ get;set;}

        public string MedicalHistory{ get;set;}

        public string FASscheme{ get;set;}

        public string Remarks { get;set;}

    }
}