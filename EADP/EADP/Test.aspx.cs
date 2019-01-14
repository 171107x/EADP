using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;
using System.Net.Mail;
using System.Web;

namespace EADP
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SurveyQ tdList = new SurveyQ();
            SurveyQDAO tdDAO = new SurveyQDAO();
            tdList = tdDAO.getSurveyQuestions(1);
            LblCountry.Text = tdList.q1.ToString();

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mailMessage = new MailMessage("nyptrip@gmail.com", TextBox1.Text);
                // Specify the email body
                mailMessage.Body = "Hi \n You have recently completed a trip! \n Please login at http://" + HttpContext.Current.Request.Url.Authority + "/LoginStudent.aspx"  + " \n The survey will only be available for a week.";
                // Specify the email Subject
                mailMessage.Subject = "Trip Survey";
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