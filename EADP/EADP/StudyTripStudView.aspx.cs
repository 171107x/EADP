using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;

namespace EADP
{
    public partial class StudyTripStudView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                trip tripOjb = new trip();
                tripDAO tripDAO = new tripDAO();

                List<trip> tripList = new List<trip>();
                tripList = tripDAO.getTripStudyType();
                TripList.DataSource = tripList;
                TripList.DataBind();
            }
        }
        protected void TripList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "moreDetails")
            {
                Session["SSTripID"] = e.CommandArgument;
                //Lbl_description.Text = Session["SSTripID"].ToString();
                Response.Redirect("TripDetails.aspx?id=" + e.CommandArgument);
            }
        }
    }
}