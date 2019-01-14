using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;

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
    }
}