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
using EADP.DAL;

namespace EADP
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }else
            {
                StudList tdList = new StudList();
                StudListDAO tdDAO = new StudListDAO();
                tdList = tdDAO.getRegbyStudAdmin(Session["username"].ToString());

                tdName.Text = tdList.studentName.ToString();
                Label1.Text = tdList.studentAdmin.ToString();
                Label2.Text = tdList.pemGroup.ToString();
                Label3.Text = tdList.nationality.ToString();
                Label4.Text = tdList.MobileNO.ToString();
                Label5.Text = tdList.DietConstraint.ToString();
                Label6.Text = tdList.MedicalHistory.ToString();

                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlDataAdapter da;
                DataSet ds = new DataSet();
                //Create Adapter
                StringBuilder sqlCommand = new StringBuilder();

                sqlCommand.AppendLine("Select * from ProfilePic where StudentAdmin = @paraStudentAdmin ");

                da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("paraStudentAdmin", tdList.studentAdmin.ToString());
            

                // fill dataset
                da.Fill(ds, "stud_table");            
                int rec_cnt = ds.Tables["stud_table"].Rows.Count;
                if (rec_cnt > 0)
                {
                    DataRow row = ds.Tables["stud_table"].Rows[0];
                    tdList.studentImage = row["Image"].ToString();
                    idProfile.ImageUrl = tdList.studentImage;
                } else
                {
                    idProfile.ImageUrl = "~/ProfilePic/download1.jpg";
                    
                }

            }
            

        }
    }
}