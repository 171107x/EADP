using EADP.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP
{
    public partial class TripStudentView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                trip tripOjb = new trip();
                tripDAO tripDAO = new tripDAO();

                List<trip> tripList = new List<trip>();
                tripList = tripDAO.getTripInfo();
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
                Response.Redirect("TripDetails.aspx?id="+e.CommandArgument);
            }
        }
    }
}