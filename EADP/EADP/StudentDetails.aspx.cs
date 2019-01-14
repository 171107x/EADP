using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;

namespace EADP
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["studInfo"] != null)
            {
                StudList tdList = new StudList();
                StudListDAO tdDAO = new StudListDAO();
                ProgCode.Text = "<h1>" + Session["Code"].ToString() + "</h1>";
                tdList = tdDAO.getTDbyStudAdmin(Session["studInfo"].ToString());
                LblAdmin.Text = tdList.studentAdmin.ToString();
                LblStudname.Text = tdList.studentName.ToString();
                LblGender.Text = tdList.gender.ToString();
                LblSchool.Text = tdList.school.ToString();
                LblPEMGroup.Text = tdList.pemGroup.ToString();
                LblNationality.Text = tdList.nationality.ToString();
                Label3.Text = tdList.passportNo.ToString();
                Label4.Text = tdList.passportE.ToString("dd/MM/yyyy");
                Label5.Text = tdList.DietConstraint.ToString();
                Label6.Text = tdList.MedicalHistory.ToString();
                Label7.Text = tdList.FASscheme.ToString();
                Remarks.Text = tdList.Remarks.ToString();

            }
            else
            {
                Response.Redirect("ListofStud.aspx");
            }
        }
    }
}