using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;

namespace EADP
{
    public partial class ConfirmParticulars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "<h1>Check Your Particulars</h1>";
            StudList tdList = new StudList();
            StudListDAO tdDAO = new StudListDAO();
            if (Session["username"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    tdList = tdDAO.getRegbyStudAdmin(Session["username"].ToString());
                    Label14.Text = tdList.studentAdmin.ToString();
                    Label2.Text = tdList.studentName.ToString();
                    Label3.Text = tdList.gender.ToString();
                    Label4.Text = tdList.DOB.ToString("dd/MM/yyyy");
                    LblDiploma.Text = tdList.school.ToString();
                    Label5.Text = tdList.pemGroup.ToString();
                    tdCountry.Text = tdList.nationality.ToString();
                    tdMobileNo.Text = tdList.MobileNO.ToString();
                    tdDiet.Text = tdList.DietConstraint.ToString();
                    tdMedical.Text = tdList.MedicalHistory.ToString();
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExtraStudentDetails.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["page"] = "ConfirmParticulars.aspx";
            Response.Redirect("UpdateParticulars.aspx");
        }
    }
}