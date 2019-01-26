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
    public partial class LoginStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            SqlDataAdapter da;
            SqlDataAdapter dstaff;
            DataSet ds = new DataSet();
            //Create Adapter
            StringBuilder sqlCommand = new StringBuilder();
            StringBuilder sqlCommandStaff = new StringBuilder();

            sqlCommand.AppendLine("Select * from Student where Email = @paraEmail and StudentPassword = @paraPassword");
            sqlCommandStaff.AppendLine("Select * from Staff where Email = @paraEmailS and Password = @paraPasswordS");

            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraEmail", tbEmail.Text);
            da.SelectCommand.Parameters.AddWithValue("paraPassword", Encryption.MD5Hash(tbPassword.Text));
            //da = new SqlDataAdapter("Select * from Student where Email = '" + tbEmail.Text + "' and StudentPassword = HASHBYTES('SHA2_512', '" + tbPassword.Text + "') ", DBConnect);

            dstaff = new SqlDataAdapter(sqlCommandStaff.ToString(), myConn);
            dstaff.SelectCommand.Parameters.AddWithValue("paraEmailS", tbEmail.Text);
            dstaff.SelectCommand.Parameters.AddWithValue("paraPasswordS", Encryption.MD5Hash(tbPassword.Text));
            // fill dataset
            da.Fill(ds, "stud_table");
            dstaff.Fill(ds, "staff_table");
            int rec_cnt = ds.Tables["stud_table"].Rows.Count;
            int staff_cnt = ds.Tables["staff_table"].Rows.Count;
            if (rec_cnt > 0)
            {
                Session["username"] = tbEmail.Text;
                Response.Redirect("TripStudentView.aspx");

            }
            else if (staff_cnt > 0)
            {
                Session["teacher"] = tbEmail.Text;
                Response.Redirect("TripManagement.aspx");
            }
            else
            {
                errorMsg.Text = "Your email or password is wrong";
            }
        }
    }
}