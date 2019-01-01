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

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            int SurveyQID = 1;
            string q1 = TextBoxq1.Text;
            string q2 = TextBoxq2.Text;
            string q3 = TextBoxq3.Text;
            string q4 = TextBoxq4.Text;

            SurveyQ surveyObj = new SurveyQ();
            SurveyQDAO surDAO = new SurveyQDAO();
            surDAO.InsertSurveyAnswers(SurveyQID,  q1, q2, q3, q4);
            Response.Redirect("Statistics.aspx");
        }
    }
}