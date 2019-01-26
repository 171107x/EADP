using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EADP
{
    public partial class TripStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            if (Session["username"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }            
            if (!IsPostBack)
            {
                StudentStatusDAO tdDAO = new StudentStatusDAO();
                List<StudentStatus> tdList = new List<StudentStatus>();

                DataSet ds = new DataSet();
                DataTable tdData = new DataTable();

                StringBuilder sqlStr = new StringBuilder();
                sqlStr.AppendLine("select * from Student");
                sqlStr.AppendLine("Where Email = @paraEmail;");

                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

                da.SelectCommand.Parameters.AddWithValue("paraEmail", Session["username"].ToString());

                da.Fill(ds, "TableTD");

                int rec_cnt = ds.Tables["TableTD"].Rows.Count;

                StudList myTD = new StudList();
                string studentid = "";               
                if (rec_cnt > 0)
                {
                    DataRow row = ds.Tables["TableTD"].Rows[0];
                    studentid = row["StudentAdmin"].ToString();                    
                }
                else
                {
                    myTD = null;
                }
                tdList = tdDAO.getStudentStatus(studentid, DateTime.Now);                

                GVStatus.DataSource = tdList;
                GVStatus.DataBind();
                GVStatus.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GVStatus.Columns[0].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            }
        }

        protected void GVStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel Trip")
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GVStatus.Rows[rowIndex];

                string country = row.Cells[1].Text;
                string btn = row.Cells[3].Text;
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

                SqlConnection myConn = new SqlConnection(DBConnect);


                StudentStatusDAO tdDAO = new StudentStatusDAO();

                DataSet ds1 = new DataSet();

                StringBuilder sqlStr1 = new StringBuilder();
                sqlStr1.AppendLine("select * from Student");
                sqlStr1.AppendLine("Where Email = @paraEmail;");

                SqlDataAdapter da1 = new SqlDataAdapter(sqlStr1.ToString(), myConn);

                da1.SelectCommand.Parameters.AddWithValue("paraEmail", Session["username"].ToString());

                da1.Fill(ds1, "TableTD");

                int rec_cnt1 = ds1.Tables["TableTD"].Rows.Count;

                StudList myTD1 = new StudList();
                string studentid = "";
                if (rec_cnt1 > 0)
                {
                    DataRow row2 = ds1.Tables["TableTD"].Rows[0];
                    studentid = row2["StudentAdmin"].ToString();
                }
                else
                {
                    myTD1 = null;
                }

                StudentStatusDAO tdDAO1 = new StudentStatusDAO();
                StudentStatus tdList = new StudentStatus();
                List<StudentStatus> tdList1 = new List<StudentStatus>();

                tdList = tdDAO1.getStudentdate(studentid, DateTime.Now);
                DateTime date = tdList.StartDate;
                double days = (Convert.ToDateTime(date) - Convert.ToDateTime(DateTime.Now)).TotalDays;


                StringBuilder sqlStr = new StringBuilder();
                int result = 0;
                SqlCommand sqlCmd = new SqlCommand();
                sqlStr.AppendLine("UPDATE RegisteredStudent set TripStatus = @paraStatus ");
                sqlStr.AppendLine("WHERE StudentAdmin = @paraStudentAdmin And TripID = @paraTripID");

                sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
                sqlCmd.Parameters.AddWithValue("@paraStatus", "Cancel");
                sqlCmd.Parameters.AddWithValue("@paraStudentAdmin", studentid.ToString());
                sqlCmd.Parameters.AddWithValue("@paraTripID", country.ToString());

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                myConn.Close();

                tdList1 = tdDAO1.getStudentStatus(studentid, DateTime.Now);

                GVStatus.DataSource = tdList1;
                GVStatus.DataBind();



            }
        }


    }
}