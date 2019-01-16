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
using System.Data;

namespace EADP
{
    public partial class ExtraStudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = "171107x@mymail.nyp.edu.sg";
            if (Session["username"] == null)
            {
                Session["page"] = "ExtraStudentDetails.aspx";
                Response.Redirect("LoginStudent.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Code"] = "Korea2018";
            StudentStatusDAO tdDAO1 = new StudentStatusDAO();
            StudentStatus tdList = new StudentStatus();
            tdList = tdDAO1.getdate(Session["Code"].ToString());
            DateTime date = tdList.StartDate;
            double days = (Convert.ToDateTime(tbDate.Text.ToString()) - Convert.ToDateTime(date)).TotalDays;
            if(days < 182.5)
            {
                lblwarning.Text = "Please renew your passport";
            }
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;           

            SqlConnection myConn = new SqlConnection(DBConnect);


            StudentStatusDAO tdDAO = new StudentStatusDAO();

            DataSet ds1 = new DataSet();

            StringBuilder sqlStr1 = new StringBuilder();
            sqlStr1.AppendLine("select * from Student");
            sqlStr1.AppendLine("Where Email = @paraEmail;");

            SqlDataAdapter da1 = new SqlDataAdapter(sqlStr1.ToString(), myConn);

            da1.SelectCommand.Parameters.AddWithValue("paraEmail", Session["username"].ToString());

            da1.Fill(ds1, "TableTD");

            int rec_cnt1 = ds1.Tables["TableTD"].Rows.Count;

            StudList myTD1 = new StudList();
            string studentid = "";
            if (rec_cnt1 > 0)
            {
                DataRow row2 = ds1.Tables["TableTD"].Rows[0];
                studentid = row2["StudentAdmin"].ToString();
            }
            else
            {
                myTD1 = null;
            }
            
            string TripID = Session["Code"].ToString();            
            string passportNO = tbPassportNo.Text.ToString();
            DateTime PassportExpiry = Convert.ToDateTime(tbDate.Text.ToString());
            string FASscheme = DdlFAS.SelectedValue.ToString();
            string WaitingList = DdlWait.SelectedValue.ToString();
            double PSEABalance = Convert.ToDouble(TextBox1.Text.ToString());

            lblResult.Text = PassportExpiry.ToString();

            StudRegDAO regStudent = new StudRegDAO();
            StudReg tdlist = new StudReg();
            regStudent.InsertStudReg(studentid, TripID, passportNO, PassportExpiry, FASscheme, WaitingList, PSEABalance);

            lblResult.Text = "Successfuly Registered \n we will redirect you to home page soon";

            Response.AddHeader("REFRESH", "5;URL=Home.aspx");
        }
    }
}