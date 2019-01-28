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
            
            if (Session["username"] == null)
            {
                Session["page"] = "ExtraStudentDetails.aspx";
                Response.Redirect("LoginStudent.aspx");
            }            
            
            //StudentStatusDAO tdDAO1 = new StudentStatusDAO();
            //StudentStatus tdList = new StudentStatus();
            //StudReg tdlist = new StudReg();
            //tdList = tdDAO1.getdate(Request.QueryString["id"].ToString());
            //DateTime date = tdList.StartDate;

            //lblwaiting.Text = DdlWait.SelectedValue.ToString();
            //lblpassport.Text = tbPassportNo.Text.ToString();
            //if (tbDate.Text.ToString() != null)
            //{
            //    double days = (Convert.ToDateTime(tbDate.Text.ToString()) - Convert.ToDateTime(date)).TotalDays;
            //    if (days < 182.5)
            //    {
            //        lbldate.Text = tbDate.Text.ToString() + " <p style='color: red;'> (Please renew your passport) </p>";
            //    }
            //    else
            //    {
            //        lbldate.Text = tbDate.Text.ToString();
            //    }
            //}

            //lblbalance.Text = TextBox1.Text.ToString();
            //lblfas.Text = DdlFAS.SelectedValue.ToString();
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Session["Code"] = "Korea2018";
            StudentStatusDAO tdDAO1 = new StudentStatusDAO();
            StudentStatus tdList = new StudentStatus();
            tdList = tdDAO1.getdate(Request.QueryString["id"].ToString());
            DateTime date = tdList.StartDate;

            double days = (Convert.ToDateTime(tbDate.Text.ToString()) - Convert.ToDateTime(date)).TotalDays;            
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
            
            string TripID = Request.QueryString["id"].ToString();            
            string passportNO = tbPassportNo.Text.ToString();
            DateTime PassportExpiry = Convert.ToDateTime(tbDate.Text.ToString());
            string FASscheme = DdlFAS.SelectedValue.ToString();
            string WaitingList = DdlWait.SelectedValue.ToString();
            double PSEABalance = Convert.ToDouble(TextBox1.Text.ToString());

            //lblResult.Text = PassportExpiry.ToString();

            StudRegDAO regStudent = new StudRegDAO();
            StudReg tdlist = new StudReg();
            
            if (days < 182.5)
            {
                //lblwarning.Text = "Please renew your passport";
                string message = "Successfuly Registered! we will redirect you to home page soon. Please don't forget to renew your passport.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());                
                regStudent.InsertStudReg(studentid, TripID, passportNO, PassportExpiry, FASscheme, WaitingList, PSEABalance);
                Response.AddHeader("REFRESH", "1;URL=TripStudentView.aspx");
            }
            else
            {
                string message = "Successfuly Registered! We will redirect you to home page soon.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                regStudent.InsertStudReg(studentid, TripID, passportNO, PassportExpiry, FASscheme, WaitingList, PSEABalance);
                Response.AddHeader("REFRESH", "1;URL=TripStudentView.aspx");
            }

            //lblResult.Text = "Successfuly Registered \n we will redirect you to home page soon";

            //Response.AddHeader("REFRESH", "5;URL=TripStudentView.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("TripDetails.aspx?id=" + Request.QueryString["id"].ToString());
        }
    }
}