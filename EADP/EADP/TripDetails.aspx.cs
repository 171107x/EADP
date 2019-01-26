using EADP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP
{
    public partial class TripDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Session["SSTripID"] != null)
                {
                    string tripID = Session["SSTripID"].ToString();
                    trip tripOjb = new trip();
                    tripDAO tripDAO = new tripDAO();
                    //tripOjb = tripDAO.getTripById(1);

                    tripOjb = tripDAO.getTrip(tripID);
                    lblCn.Text = tripOjb.Country;
                    lblDesc.Text = tripOjb.Description;
                    lblSD.Text = tripOjb.StartDate.ToShortDateString();
                    lblED.Text = tripOjb.EndDate.ToShortDateString();
                    lblPrc.Text = tripOjb.ETripPrice.ToString();
                }
                else
                {
                    Response.Redirect("TripStudentView.aspx");
                }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {            
            Response.Redirect("ConfirmParticulars.aspx?id=" + Request.QueryString["id"].ToString());
        }
    }
}