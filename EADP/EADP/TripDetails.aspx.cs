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
    public partial class TripDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Session["SSTripID"] != null)
                {
                    string tripID = Session["SSTripID"].ToString();
                    trip tripOjb = new trip();
                    tripDAO tripDAO = new tripDAO();
                    //tripOjb = tripDAO.getTripById(1);

                    tripOjb = tripDAO.getTrip(tripID);
                    imgTripDetails.ImageUrl = tripOjb.Image;
                    lblCn.Text = tripOjb.Country;
                    lblDesc.Text = tripOjb.Description;
                    lblSD.Text = tripOjb.StartDate.ToShortDateString();
                    lblED.Text = tripOjb.EndDate.ToShortDateString();
                    lblPrc.Text = tripOjb.ETripPrice.ToString();
                }
                else
                {
                    Response.Redirect("TripStudentView.aspx");
                }
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                StudList studList = new StudList();
                DataSet ds = new DataSet();
                DataTable tripData = new DataTable();

                StudListDAO StudDao = new StudListDAO();
                studList = StudDao.getRegbyStudAdmin(Session["Username"].ToString());

                StringBuilder sqlStr = new StringBuilder();
                sqlStr.AppendLine("SELECT * FROM RegisteredStudent");
                sqlStr.AppendLine("INNER JOIN Trip");
                sqlStr.AppendLine("ON RegisteredStudent.TripID = Trip.TripID");
                sqlStr.AppendLine("where RegisteredStudent.TripID = @paraTripID AND RegisteredStudent.StudentAdmin = @paraStudentAdmin");

                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


                da.SelectCommand.Parameters.AddWithValue("@paraTripID", Request.QueryString["id"].ToString());
                da.SelectCommand.Parameters.AddWithValue("@paraStudentAdmin", studList.studentAdmin);
                da.Fill(ds, "studList");

                int rec_cnt = ds.Tables["studList"].Rows.Count;
                if (rec_cnt > 0)
                {
                    btnRegister.CssClass = "btn btn-primary disabled float-right";
                    btnRegister.Enabled = false;
                }
               

                
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {            
            Response.Redirect("ConfirmParticulars.aspx?id=" + Request.QueryString["id"].ToString());
        }
    }
}