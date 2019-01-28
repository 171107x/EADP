using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EADP
{
    public partial class EditSurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string q1 = TextBoxq1.Text;
            string q2 = TextBoxq2.Text;
            string q3 = TextBoxq3.Text;
            string q4 = TextBoxq4.Text;

            int id = Convert.ToInt32(Session["SurveyID"]);
            SurveyQ newS = new SurveyQ();
            SurveyQDAO updateS = new SurveyQDAO();
            int result;
            result = updateS.updateSurvey(id,q1,q2,q3,q4);
            if(result == 1)
            {
                Label2.Text = "Survey updated!";
            }

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