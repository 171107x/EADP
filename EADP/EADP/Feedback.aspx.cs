using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;

namespace EADP
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string studentAdmin = tbAdmin.Text.ToString();
            string tripID = tbTrip.Text.ToString();
            int rate = Convert.ToInt32(DropDownList1.SelectedValue);
            string comments = tbComments.Text.ToString();
            string recommends = RadioButtonList3.SelectedValue.ToString();
            Feedback feedbackObj = new Feedback();
            FeedbackDAO feedDAO = new FeedbackDAO();
            feedDAO.insertFeedbackResponse(studentAdmin,tripID, rate, comments, recommends);
            Response.Redirect("Statistics.aspx");
        }
    }
}