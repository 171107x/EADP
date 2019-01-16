using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP.DAL
{
    //changed filename from StudReg to StudentReg
    public class StudentReg
    {
        public string studentAdmin { get; set; }
        //changes made to trip id
        //initially was public int tripID {get; set;}
        public string TripID { get; set; }
        public string nationality { get; set; }
        public string MobileNO { get; set; }

        public string PassportNO { get;set;}

        public DateTime PassportExpiry { get;set;}
        public string DietConstraint{ get;set;}

        public string MedicalHistory{ get;set;}

        public string FASscheme{ get;set;}

        public string Remarks { get;set;}

    }
}