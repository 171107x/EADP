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
    public partial class TripManament : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                trip tripOjb = new trip();
                tripDAO tripDAO = new tripDAO();
                //tripOjb = tripDAO.getTripById(1);
                //Lbl_country.Text = tripOjb.Country;
                //Lbl_description.Text = tripOjb.Description;

                List<trip> tripList = new List<trip>();
                tripList = tripDAO.getTripInfo();
                GridViewTrip.DataSource = tripList;
                GridViewTrip.DataBind();

                List<trip> tripHist = new List<trip>();
                tripHist = tripDAO.getTripHist();
                GridViewHist.DataSource = tripHist;
                GridViewHist.DataBind();
            }
        }

        protected void BtnRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudReg.aspx");
        }

        protected void GridViewTrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewTrip.SelectedRow;

            Session["SSProgCode"] = row.Cells[0].Text;
            Session["SSStartDate"] = row.Cells[1].Text;
            Session["SSEndDate"] = row.Cells[2].Text;
            Session["SSCountry"] = row.Cells[3].Text;
            Session["SSLeadStaffID"] = row.Cells[8].Text;
            Session["SSDescription"] = row.Cells[6].Text;
            Session["SSMaxStud"] = row.Cells[7].Text;
            Session["SSPrice"] = row.Cells[4].Text;
            DateTime StartDate = Convert.ToDateTime(Session["SSStartDate"].ToString());
            if (StartDate <= DateTime.Now.Date)
            {
                row.Enabled = false;
                lblMsg.Text = "Cannot Edit Ongoing Trip";
            }
            else
            {
                Response.Redirect("UpdateTrip.aspx");
            }
        }

        protected void btnClr_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditTrip.aspx");
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
            if(result == 1)
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

        protected void studList_Click(object sender, EventArgs e)
        {
            LinkButton studList = sender as LinkButton;
            GridViewRow row = studList.NamingContainer as GridViewRow;
            string TripID = row.Cells[0].Text;
            Session["Code"] = TripID;
            Response.Redirect("ListofStud.aspx");
        }
    }
}