using EADP.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP
{
    public partial class UpdateTrip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if(Session["SSProgCode"] != null)
                {
                    lblProgCode.Text = Session["SSProgCode"].ToString();
                    tbStartDateUD.Text = Session["SSStartDate"].ToString();
                    tbEndDateUD.Text = Session["SSEndDate"].ToString();
                    tbCountryUD.Text = Session["SSCountry"].ToString();
                    tbIDUD.Text = Session["SSLeadStaffID"].ToString();
                    //Request.Form["taDescUP"]= Session["SSDescription"].ToString();
                    tbMaxStudUD.Text = Session["SSMaxStud"].ToString();
                    tbPriceUD.Text = Session["SSPrice"].ToString();
                    //tbCountryUD.Text = Session["SSStaffIC"].ToString();
                }
            }
            //else
            //{
            //    Response.Redirect("TripManagement.aspx");
            //}
        }

        protected void btnClr_Click(object sender, EventArgs e)
        {
            tbStartDateUD.Text = String.Empty;
            tbEndDateUD.Text = String.Empty;
            tbCountryUD.Text = String.Empty;
            tbIDUD.Text = String.Empty;
            tbMaxStudUD.Text = String.Empty;
            tbPriceUD.Text = String.Empty;
            imgUploadUD.Attributes.Clear();
            foreach (var item in Page.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string TripID = Convert.ToString(lblProgCode.Text.ToString());
            DateTime StartDate = Convert.ToDateTime(tbStartDateUD.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(tbEndDateUD.Text.ToString());
            TimeSpan Diff = EndDate - StartDate;
            int Duration = Convert.ToInt16(Diff.Days.ToString());
            string Country = tbCountryUD.Text.ToString();
            string Description = Request.Form["taDescUP"].ToString();
            int MaxStudent = Convert.ToInt16(tbMaxStudUD.Text.ToString());
            double ETripPrice = Convert.ToDouble(tbPriceUD.Text.ToString());
            int StaffID = Convert.ToInt16(tbIDUD.Text.ToString());
            string Image = "~/tripImg/" + Guid.NewGuid().ToString() + "" + Path.GetExtension(imgUploadUD.FileName);

            if (StartDate < DateTime.Now.Date)
            {
                lblError.Text = "Invalid Start Date!";
                tbStartDateUD.Focus();
            }
            else if (EndDate < DateTime.Now.Date)
            {
                lblError.Text = "Invalid End Date!";
                tbEndDateUD.Focus();
            }
            else
            {
                tripDAO newTrip = new tripDAO();
                newTrip.UpdateTrip(TripID, StartDate, EndDate, Duration, Country, Description, MaxStudent, ETripPrice, StaffID, Image);
                Response.Redirect("TripManagement.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TripManagement.aspx");
        }
    }
}