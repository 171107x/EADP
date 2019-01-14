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
    public partial class ExtraStudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Session["page"] = "ExtraStudentDetails.aspx";
                Response.Redirect("LoginStudent.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            Session["Code"] = "Korea2018";
            string TripID = Session["Code"].ToString();
            string studentAdmin = Session["username"].ToString();
            string passportNO = tbPassportNo.Text.ToString();
            DateTime PassportExpiry = Convert.ToDateTime(tbDate.Text.ToString());
            string FASscheme = DdlFAS.SelectedValue.ToString();
            string WaitingList = DdlWait.SelectedValue.ToString();
            double PSEABalance = Convert.ToDouble(TextBox1.Text.ToString());

            lblResult.Text = PassportExpiry.ToString();

            StudRegDAO regStudent = new StudRegDAO();
            StringBuilder sqlStr = new StringBuilder();

            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO RegisteredStudent (StudentAdmin, TripID, PassportNO, ");
            sqlStr.AppendLine("PassportExpiry, FASscheme, WaitingList, PSEABalance)");
            sqlStr.AppendLine("VALUES (@paraStudAdmin,@paraTripID, @paraPassportNO, ");
            sqlStr.AppendLine("@paraPassportExpiry, @paraFASscheme, @paraWaitingList, @paraPSEABalance)");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraStudAdmin", studentAdmin);
            sqlCmd.Parameters.AddWithValue("@paraTripID", TripID);
            sqlCmd.Parameters.AddWithValue("@paraPassportNO", passportNO);
            sqlCmd.Parameters.AddWithValue("@paraPassportExpiry", PassportExpiry);
            sqlCmd.Parameters.AddWithValue("@paraFASscheme", FASscheme);
            sqlCmd.Parameters.AddWithValue("@paraWaitingList", WaitingList);
            sqlCmd.Parameters.AddWithValue("@paraPSEABalance", PSEABalance);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();


            myConn.Close();
        }
    }
}