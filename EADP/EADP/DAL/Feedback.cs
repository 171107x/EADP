using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP.DAL
{
    public class Feedback
    {
        public string studentAdmin { get; set; }
        public string tripID { get; set; }
        public int rates { get; set; }
        public string comments { get; set; }
        public string recommend { get; set; }
    }
}