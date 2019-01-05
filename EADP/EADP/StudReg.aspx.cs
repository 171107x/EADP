 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;


namespace EADP
{
    public partial class StudReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "<h1>Update Particulars</h1>";
            StudList tdList = new StudList();
            StudListDAO tdDAO = new StudListDAO();
            if (Session["username"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
            else
            {
                tdList = tdDAO.getRegbyStudAdmin(Session["username"].ToString());
                Label14.Text = tdList.studentAdmin.ToString();
                Label2.Text = tdList.studentName.ToString();
                Label3.Text = tdList.gender.ToString();
                Label4.Text = tdList.DOB.ToString("dd/MM/yyyy");
                LblDiploma.Text = tdList.diploma.ToString();
                Label5.Text = tdList.pemGroup.ToString(); 
            }
                       
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nationality = "";
            StudList tdList = new StudList();
            StudListDAO tdDAO = new StudListDAO();
            tdList = tdDAO.getRegbyStudAdmin(Session["username"].ToString());
            string adminNO = tdList.studentAdmin.ToString();
            string tripID = "Korea2018";
            if(DdlCountry.SelectedValue != "-1")
            {
                nationality = DdlCountry.SelectedValue.ToString();
            }
            
            string mobileNO = tbMobileNo.Text.ToString();         
            string dietConstraint = tbDiet.Text.ToString();
            string medHist = tbMedical.Text.ToString();                       

            StudReg studObj = new StudReg();
            StudRegDAO studDAO = new StudRegDAO();            
            lblResult.Text = "Successfully Registered";
            lblResult.ForeColor = System.Drawing.Color.Black;

        }
    }
}