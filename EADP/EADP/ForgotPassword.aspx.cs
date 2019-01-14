using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            try
            {
                MailMessage mailMessage = new MailMessage("nyptrip@gmail.com", TextBox1.Text);
                // Specify the email body
                mailMessage.Body = "Hi \n To reset your Ubisoft account password please click here. http://" + HttpContext.Current.Request.Url.Authority + "/ResetPassword.aspx?email=" + TextBox1.Text + " \n If you have previously requested to change your password, only the link contained in this e - mail is valid.";
                // Specify the email Subject
                mailMessage.Subject = "testing";
                mailMessage.IsBodyHtml = true;
                // Specify the SMTP server name and post number
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                // Specify your gmail address and password
                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "nyptrip@gmail.com",
                    Password = "nyptrip123"
                };
                // Gmail works on SSL, so set this property to true
                smtpClient.EnableSsl = true;
                // Finall send the email message using Send() method
                smtpClient.Send(mailMessage);
                status.Text = HttpContext.Current.Request.Url.Authority; 

            }
            catch (Exception ex)
            {
                status.Text = ex.StackTrace;
            }
        }
    }
}