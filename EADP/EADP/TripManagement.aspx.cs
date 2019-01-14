using EADP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP
{
    public partial class TripManament : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            trip tripOjb = new trip();
            tripDAO tripDAO = new tripDAO();
            //tripOjb = tripDAO.getTripById(1);
            //Lbl_country.Text = tripOjb.Country;
            //Lbl_description.Text = tripOjb.Description;


            List<trip> tdList = new List<trip>();
            tdList = tripDAO.getTripInfo();
            GridViewTrip.DataSource = tdList;
            GridViewTrip.DataBind();
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            string TripID = Convert.ToString(tbTripID.Text.ToString());
            DateTime StartDate = Convert.ToDateTime(tbStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(tbEndDate.Text.ToString());
            string Country = tbCountry.Text.ToString();
            double ETripPrice = Convert.ToDouble(tbETripPrice.Text.ToString());


            tripDAO newTrip = new tripDAO();
            newTrip.InsertTrip(TripID, StartDate, EndDate, Country, ETripPrice);
            Response.Redirect("TripManagement.aspx");
        }
    }
}