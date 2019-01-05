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

namespace EADP
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Request.QueryString["email"].ToString();
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