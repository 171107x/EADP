using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;

namespace EADP
{
    public partial class Createsurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["teacher"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string q1 = TextBoxq1.Text;
            string q2 = TextBoxq2.Text;
            string q3 = TextBoxq3.Text;
            string q4 = TextBoxq4.Text;

            SurveyQ surveyObj = new SurveyQ();
            SurveyQDAO surDAO = new SurveyQDAO();
            surDAO.InsertSurveyAnswers(q1, q2, q3, q4);
            Response.Redirect("TripManagement.aspx");
        }

        protected void resetBtn_Click(object sender, EventArgs e)
        {
            TextBoxq1.Text = String.Empty;
            TextBoxq2.Text = String.Empty;
            TextBoxq3.Text = String.Empty;
            TextBoxq4.Text = String.Empty;
        }
    }
}