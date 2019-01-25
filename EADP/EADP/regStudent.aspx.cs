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
    public partial class regStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Session["SSTripID"] != null)
                {
                    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                    SqlConnection myConn = new SqlConnection(DBConnect);
                    string TripID = Session["SSTripID"].ToString();
                    SqlCommand cmd = new SqlCommand("SELECT TripID FROM RegisteredStudent WHERE TripID ='" + TripID + "'", myConn);
                    myConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        if (reader.HasRows)
                        {
                            tripDAO tripDAO = new tripDAO();
                            List<StudentReg> studList = new List<StudentReg>();
                            studList = tripDAO.getStudList(TripID);
                            GVStudList.DataSource = studList;
                            GVStudList.DataBind();
                        }
                        else
                        {
                            lblNoStud.Text = "No such record exist!";
                        }
                        myConn.Close();
                    }
                    catch (Exception ex)
                    {
                        lblNoStud.Text = "idk what to put here";
                    }
                }
                else
                {
                    lblNoStud.Text = "No such record exist!!!";
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TripManagement.aspx");
        }
    }
}