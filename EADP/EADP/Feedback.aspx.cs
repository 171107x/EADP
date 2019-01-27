using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace EADP
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
            StudList studList = new StudList();
            StudListDAO studDAO = new StudListDAO();
            StudentReg studReg = new StudentReg();
            StudRegDAO regDAO = new StudRegDAO();
            studList = studDAO.getRegbyStudAdmin(Session["Username"].ToString());
            Lblno.Text = studList.studentAdmin.ToString();
            studReg = regDAO.getTripID(Lblno.Text);
            Lblcode.Text = studReg.TripID.ToString();
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            int rate = Convert.ToInt32(DropDownList1.SelectedValue);
            string comments = tbComments.Text.ToString();
            string recommends = RadioButtonList3.SelectedValue.ToString();
            Feedback feedbackObj = new Feedback();
            FeedbackDAO feedDAO = new FeedbackDAO();
            string studentAdmin = Lblno.Text;
            string tripID = Lblcode.Text;
            feedDAO.insertFeedbackResponse(studentAdmin,tripID, rate, comments, recommends);
            
            Response.Redirect("Statistics.aspx");
        }
    }
}