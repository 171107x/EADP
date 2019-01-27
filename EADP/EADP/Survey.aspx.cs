using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;

namespace EADP
{
    public partial class Survey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Session["new"] = "Survey";
                Response.Redirect("LoginStudent.aspx");
            }
            StudList studList = new StudList();
            StudListDAO studDAO = new StudListDAO();
            SurveyQ tdList = new SurveyQ();
            SurveyQDAO tdDAO = new SurveyQDAO();
            studList = studDAO.getRegbyStudAdmin(Session["Username"].ToString());
            LblNo.Text = studList.studentAdmin.ToString();
            tdList = tdDAO.getSurveyQuestions();
            if (tdList == null)
            {
                tbQ1.Visible = false;
                tbQ2.Visible = false;
                tbQ3.Visible = false;
                tbQ4.Visible = false;
                LblQ2.Visible = false;
                LblQ3.Visible = false;
                LblQ4.Visible = false;
                submitBtn.Visible = false;
                resetBtn.Visible = false;
                LblQ1.Text = "<h1>No survey has been loaded for the moment. Please check back again later!</h1>";
            }
            else
            {
                LblQ1.Text = tdList.q1.ToString();
                LblQ2.Text = tdList.q2.ToString();
                LblQ3.Text = tdList.q3.ToString();
                LblQ4.Text = tdList.q4.ToString();
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string SurveyID = String.Format("S{0}",LblNo.Text);
            string studentAdmin = LblNo.Text;
            string q1Ans = tbQ1.Text;
            string q2Ans = tbQ2.Text;
            string q3Ans = tbQ3.Text;
            string q4Ans = tbQ4.Text;
            string q5Ans = "";
            string q6Ans = "";
            string q7Ans = "";
            Survey surveyObj = new Survey();
            SurveyDAO surDAO = new SurveyDAO();
            surDAO.InsertSurveyAnswers(SurveyID,studentAdmin, q1Ans, q2Ans, q3Ans, q4Ans, q5Ans, q6Ans, q7Ans);
            Response.Redirect("Statistics.aspx");
        }


        protected void resetBtn_Click1(object sender, EventArgs e)
        {
            tbQ1.Text = String.Empty;
            tbQ2.Text = String.Empty;
            tbQ3.Text = String.Empty;
            tbQ4.Text = String.Empty;
        }
    }
}