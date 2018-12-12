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

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string SurveyID = String.Format("S{0}",tbAdmin.Text.ToString());
            string studentAdmin = tbAdmin.Text.ToString();
            string q1Ans = RadioButtonList1.SelectedValue.ToString();
            string q2Ans = RadioButtonList2.SelectedValue.ToString();
            string q3Ans = "";
            string q4Ans = "";
            string q5Ans = "";
            string q6Ans = "";
            string q7Ans = "";
            Survey surveyObj = new Survey();
            SurveyDAO surDAO = new SurveyDAO();
            surDAO.InsertSurveyAnswers(SurveyID,studentAdmin, q1Ans, q2Ans, q3Ans, q4Ans, q5Ans, q6Ans, q7Ans);
            Response.Redirect("Statistics.aspx");
        }
    }
}