using EADP.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP
{
    public partial class studyTrip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tripDAO tripDAO = new tripDAO();

            List<trip> studyTrip = new List<trip>();
            studyTrip = tripDAO.getStudyTrip();
            GridViewTrip.DataSource = studyTrip;
            GridViewTrip.DataBind();

            List<trip> studyTripHist = new List<trip>();
            studyTripHist = tripDAO.getStudyTripHist();
            GridViewHist.DataSource = studyTrip;
            GridViewHist.DataBind();

        }
        protected void studList_Click(object sender, EventArgs e)
        {
            LinkButton studList = sender as LinkButton;
            GridViewRow row = studList.NamingContainer as GridViewRow;
            string TripID = row.Cells[0].Text;
            Session["SSTripID"] = TripID;
            Response.Redirect("regStudent.aspx");
        }
        protected void tripDelete_Click(object sender, EventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            LinkButton tripDelete = sender as LinkButton;
            GridViewRow row = tripDelete.NamingContainer as GridViewRow;
            //string ProgCode = Convert.ToString(GridViewTrip.DataKeys[row.RowIndex].Value.ToString());
            string ProgCode = row.Cells[0].Text;
            int result;
            myConn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Trip WHERE TripID ='" + ProgCode + "'", myConn);
            result = cmd.ExecuteNonQuery();
            myConn.Close();
            if (result == 1)
            {
                trip tripOjb = new trip();
                tripDAO tripDAO = new tripDAO();
                List<trip> tripList = new List<trip>();
                tripList = tripDAO.getTripInfo();
                GridViewTrip.DataSource = tripList;
                GridViewTrip.DataBind();
            }
            //Response.Redirect("Tripmanagement.aspx");
        }
        protected void btnClr_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditTrip.aspx");
        }
    }
}