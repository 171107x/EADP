using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;
using System.Data;

namespace EADP
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select * from ResetPassword ");
            sqlStr.AppendLine("Inner Join Student");
            sqlStr.AppendLine("on Student.StudentAdmin = ResetPassword.StudentAdmin");
            sqlStr.AppendLine("where ResetID = @paraResetID;");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraResetID", Request.QueryString["email"].ToString());

            da.Fill(ds, "TableTD");

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            DataRow row = ds.Tables["TableTD"].Rows[0];

            if (rec_cnt > 0)
            {
                TextBox1.Text = row["Email"].ToString();
            }

            DateTime expire = Convert.ToDateTime(row["ResetRequestDateTime"].ToString());
            double days = (DateTime.Now - expire).TotalDays;
            if (days > 1)
            {
                Response.Redirect("Expire.aspx");
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbpassword.Text != tbconfirm.Text)
            {
                status.Text = "New Password and Confirm New Password do not match";
            }
            else
            {
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                StringBuilder sqlStr = new StringBuilder();
                int result = 0;
                SqlCommand sqlCmd = new SqlCommand();

                sqlStr.AppendLine("UPDATE Student set StudentPassword = @paraPassword ");
                sqlStr.AppendLine("WHERE Email = @paraEmail");

                SqlConnection myConn = new SqlConnection(DBConnect);

                sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paraPassword", Encryption.MD5Hash(tbpassword.Text));
                sqlCmd.Parameters.AddWithValue("@paraEmail", TextBox1.Text);

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                myConn.Close();
                status.Text = "Password change";
            }
        }
    }
}