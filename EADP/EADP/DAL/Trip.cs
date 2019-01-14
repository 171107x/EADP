using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP.DAL
{
    public class trip
    {
        public string TripID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public double ETripPrice { get; set; }
        public int MaxStudent { get; set; }
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string Image { get; set; }

    }
}