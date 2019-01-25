using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace EADP
{
    public partial class ListofStud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudListDAO tdDAO = new StudListDAO();
            List<StudList> tdList = new List<StudList>();
            
            if (!Page.IsPostBack)
            {
                         
                tdList = tdDAO.getTDbyTripID(Session["Code"].ToString());
                GridViewTD.DataSource = tdList;
                GridViewTD.DataBind();
                ProgCode.Text = "<h1>" + Session["Code"].ToString() + "</h1>";
            }
            countStud(Session["Code"].ToString());                    
                      
        }
        
        protected void countStud(string tripid)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select count(*) from RegisteredStudent");
            sqlStr.AppendLine("where TripID = @paraTripID AND TripStatus = 'Accepted';");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraTripID", tripid);

            da.Fill(ds, "TableTD");

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;

            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableTD"].Rows[0];
                lbStudent.Text = row[0].ToString();
            }
        }
        
        protected void gvbind()
        {
            StudListDAO tdDAO = new StudListDAO();
            List<StudList> tdList = new List<StudList>();
            tdList = tdDAO.getTDbyTripID(Session["Code"].ToString());            
            GridViewTD.DataSource = tdList;
            GridViewTD.DataBind();
        }       

        protected void GridViewTD_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accept")
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridViewTD.Rows[rowIndex];

                string studAdmin = row.Cells[1].Text;
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                StringBuilder sqlStr = new StringBuilder();
                int result = 0;
                SqlCommand sqlCmd = new SqlCommand();

                sqlStr.AppendLine("UPDATE RegisteredStudent set TripStatus = @paraStatus ");
                sqlStr.AppendLine("WHERE StudentAdmin = @paraStudentAdmin And TripID = @paraTripID");

                SqlConnection myConn = new SqlConnection(DBConnect);

                sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
                sqlCmd.Parameters.AddWithValue("@paraStatus", "Accepted");
                sqlCmd.Parameters.AddWithValue("@paraStudentAdmin", studAdmin.ToString());
                sqlCmd.Parameters.AddWithValue("@paraTripID", Session["Code"].ToString());

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                myConn.Close();
                StudListDAO tdDAO = new StudListDAO();
                List<StudList> tdList = new List<StudList>();
                tdList = tdDAO.getTDbyTripID(Session["Code"].ToString());
                GridViewTD.DataSource = tdList;
                GridViewTD.DataBind();
                countStud(Session["Code"].ToString());
            }
            if (e.CommandName == "Reject")
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridViewTD.Rows[rowIndex];

                string studAdmin = row.Cells[1].Text;
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                StringBuilder sqlStr = new StringBuilder();
                int result = 0;
                SqlCommand sqlCmd = new SqlCommand();

                sqlStr.AppendLine("UPDATE RegisteredStudent set TripStatus = @paraStatus ");
                sqlStr.AppendLine("WHERE StudentAdmin = @paraStudentAdmin And TripID = @paraTripID");

                SqlConnection myConn = new SqlConnection(DBConnect);

                sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
                sqlCmd.Parameters.AddWithValue("@paraStatus", "Rejected");
                sqlCmd.Parameters.AddWithValue("@paraStudentAdmin", studAdmin.ToString());
                sqlCmd.Parameters.AddWithValue("@paraTripID", Session["Code"].ToString());

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                myConn.Close();
                StudListDAO tdDAO = new StudListDAO();
                List<StudList> tdList = new List<StudList>();
                tdList = tdDAO.getTDbyTripID(Session["Code"].ToString());
                GridViewTD.DataSource = tdList;
                GridViewTD.DataBind();
                countStud(Session["Code"].ToString());
            }
        }
        protected void GridViewTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewTD.SelectedRow;
            Session["studInfo"] = row.Cells[1].Text;
            Response.Redirect("StudentDetails.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select RegisteredStudent.StudentAdmin, Student.StudentName,Student.Gender,Student.School,Student.PEMGroup,Student.Nationality,RegisteredStudent.PassportNO,RegisteredStudent.PassportExpiry,Student.DietConstraint,Student.MedicalHistory,RegisteredStudent.FASscheme,RegisteredStudent.Remarks from Student");
            sqlStr.AppendLine("Inner Join RegisteredStudent");
            sqlStr.AppendLine("on Student.StudentAdmin = RegisteredStudent.StudentAdmin");
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);           
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "StudentList" + Session["Code"].ToString() + ".xls"));
            Response.ContentType = "application/ms-excel";
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");

            int i;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    Response.Write(tab + dr[i].ToString());
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }

        protected void studsearchbtn_Click(object sender, EventArgs e)
        {
            if (tbstudsearch.Text == "")
            {
                StudListDAO tdDAO = new StudListDAO();
                List<StudList> tdList = new List<StudList>();
                tdList = tdDAO.getTDbyTripID(Session["Code"].ToString());
                GridViewTD.DataSource = tdList;
                GridViewTD.DataBind();
            }
            else
            {
                StudListDAO tdDAO = new StudListDAO();
                List<StudList> tdList = new List<StudList>();
                tdList = tdDAO.getTDbyStudentAdmin(tbstudsearch.Text.ToString(), Session["Code"].ToString());
                GridViewTD.DataSource = tdList;
                GridViewTD.DataBind();
            }    
            
        }

        protected void GridViewTD_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "Accepted")
                    e.Row.BackColor = Color.FromName("#7CFC00");
                else if (e.Row.Cells[i].Text == "Rejected")
                    e.Row.BackColor = Color.FromName("#FFD700");
            }
        }
    }
}