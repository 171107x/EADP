using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP.DAL
{
    public class StudentStatus
    {
        public string Image { get; set; }
        public DateTime StartDate { get; set; }
        public string TripStatus { get; set; }
        public string StudentAdmin { get; set; } 
        public string Country { get; set; }
        public string TripID { get; set; }
    }
}