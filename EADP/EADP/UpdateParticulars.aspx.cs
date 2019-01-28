using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;

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
                if (!IsPostBack)
                {
                    tdList = tdDAO.getRegbyStudAdmin(Session["username"].ToString());
                    Label14.Text = tdList.studentAdmin.ToString();
                    Label2.Text = tdList.studentName.ToString();
                    Label3.Text = tdList.gender.ToString();
                    Label4.Text = tdList.DOB.ToString("dd/MM/yyyy");
                    LblDiploma.Text = tdList.school.ToString();
                    Label5.Text = tdList.pemGroup.ToString();
                    DdlCountry.SelectedValue = tdList.nationality.ToString();
                    tbMobileNo.Text = tdList.MobileNO.ToString();
                    tbDiet.Text = tdList.DietConstraint.ToString();
                    tbMedical.Text = tdList.MedicalHistory.ToString();
                }
                    
            }
                       
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StudList tdList = new StudList();
            StudListDAO tdDAO = new StudListDAO();
            tdList = tdDAO.getRegbyStudAdmin(Session["username"].ToString());
            
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE Student set Nationality = @paraNationality, MobileNO = @paraMobileNO, DietConstraint = @paraDietConstraint, MedicalHistory = @paraMedicalHistory ");
            sqlStr.AppendLine("WHERE Email = @paraEmail");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraNationality", DdlCountry.SelectedValue.ToString());
            sqlCmd.Parameters.AddWithValue("@paraMobileNO", tbMobileNo.Text);
            sqlCmd.Parameters.AddWithValue("@paraDietConstraint", tbDiet.Text);
            sqlCmd.Parameters.AddWithValue("@paraMedicalHistory", tbMedical.Text);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Session["username"].ToString());

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            lblResult.Text = "Particulars Updated";
            if (Session["page"] != null)
            {
                Response.Redirect(Session["page"].ToString());
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account.aspx");
        }
    }
}