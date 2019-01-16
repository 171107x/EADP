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
    public partial class Status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            Session["username"] = "172345A@mymails.nyp.edu.sg";
            if (Session["username"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }else
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
                tdList = tdDAO.getStudentStatus(studentid);                
                GVStatus.DataSource = tdList;                
                GVStatus.DataBind();
                GVStatus.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GVStatus.Columns[0].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            }
        }

        
    }
}