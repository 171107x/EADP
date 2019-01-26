using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Input;

namespace EADP
{
    public partial class Forgot_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            using (SqlConnection con = new SqlConnection(DBConnect))
            {
                SqlCommand cmd = new SqlCommand("spResetPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramEmail = new SqlParameter("@Email", TextBox1.Text);

                cmd.Parameters.Add(paramEmail);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (Convert.ToBoolean(rdr["ReturnCode"]))
                    {
                        SendPasswordResetEmail(rdr["Email"].ToString(), TextBox1.Text, rdr["UniqueId"].ToString());
                        status.Text = "An email with instructions to reset your password is sent to your registered email";
                    }
                    else
                    {
                        status.ForeColor = System.Drawing.Color.Red;
                        status.Text = "Username not found!";
                    }
                }
                
            }
        }
        private void SendPasswordResetEmail(string ToEmail, string UserName, string UniqueId)
        {
            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("YourEmail@gmail.com", ToEmail);


            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("http://" + HttpContext.Current.Request.Url.Authority + "/ResetPassword.aspx?email=" + UniqueId);
            sbEmailBody.Append("<br/><br/>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Reset Your Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "nyptrip@gmail.com",
                Password = "nyptrip123"
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            
        }
    }
}