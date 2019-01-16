using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace EADP
{
    public partial class Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
            else
            {
                StudList tdList = new StudList();
                StudListDAO tdDAO = new StudListDAO();
                tdList = tdDAO.getRegbyStudAdmin(Session["username"].ToString());
                tbAdminNo.Text = tdList.studentAdmin.ToString();    
            }
                    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StudList tdList = new StudList();
            StudListDAO tdDAO = new StudListDAO();
            tdList = tdDAO.getRegbyStudAdmin(Session["username"].ToString());
            if (Encryption.MD5Hash(tbPassword.Text) != tdList.studentPassword.ToString())
            {
                errorMsg.Text = "Your current password is incorrect";
            } else if (TextBox1.Text != TextBox2.Text)
            {
                errorMsg.Text = "You new password is different than the confirm password";
            } else
            {
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                StringBuilder sqlStr = new StringBuilder();
                int result = 0;    
                SqlCommand sqlCmd = new SqlCommand();
                
                sqlStr.AppendLine("UPDATE Student set StudentPassword = @paraPassword ");
                sqlStr.AppendLine("WHERE Email = @paraEmail");                              

                SqlConnection myConn = new SqlConnection(DBConnect);

                sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
               
                sqlCmd.Parameters.AddWithValue("@paraPassword", Encryption.MD5Hash(TextBox1.Text));
                sqlCmd.Parameters.AddWithValue("@paraEmail", Session["username"].ToString());               

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();
                
                myConn.Close();
                errorMsg.Text = "Password change";
                Response.AddHeader("Refresh", "5;URL=Account.aspx");
            }
        }

        
    }
}