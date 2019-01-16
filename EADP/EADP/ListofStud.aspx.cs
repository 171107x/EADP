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

namespace EADP
{
    public partial class ListofStud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["Code"] = "Korea2018";
                StudListDAO tdDAO = new StudListDAO();
                List<StudList> tdList = new List<StudList>();
                tdList = tdDAO.getTDbyTripID(Session["Code"].ToString());
                GridViewTD.DataSource = tdList;
                GridViewTD.DataBind();
                ProgCode.Text = "<h1>" + Session["Code"].ToString() + "</h1>";
            }
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select count(*) from RegisteredStudent");
            sqlStr.AppendLine("where TripID = @paraTripID AND TripStatus = 'Accepted';");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraTripID", Session["Code"].ToString());

            da.Fill(ds, "TableTD");

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;

            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableTD"].Rows[0];
                lbStudent.Text = row[0].ToString();

            }
            else
            {
                // do nothing
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
        protected void GridViewTD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;")
                    e.Row.Cells[i].BackColor = Color.Orange;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //TableCell cell = e.Row.Cells[1];
                //string admin = cell.Text;
                //string status = "";
                ////Check your condition here
                //string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

                //DataSet ds = new DataSet();
                //DataTable tdData = new DataTable();

                //StringBuilder sqlStr = new StringBuilder();
                //sqlStr.AppendLine("select TripStatus from RegisteredStudent");
                //sqlStr.AppendLine("where StudentAdmin = @paraTripID;");

                //SqlConnection myConn = new SqlConnection(DBConnect);
                //SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

                //da.SelectCommand.Parameters.AddWithValue("paraTripID", admin);

                //da.Fill(ds, "TableTD");

                //int rec_cnt = ds.Tables["TableTD"].Rows.Count;

                //if (rec_cnt > 0)
                //{
                //    DataRow row = ds.Tables["TableTD"].Rows[0];                    
                //    status = row["StudentAdmin"].ToString();

                //}
                //else
                //{
                //    // do nothing
                //}
                //for (int i = 0; i < e.Row.Cells.Count; i++)
                //{
                //    if (e.Row.Cells[i].Text == status)
                //        e.Row.Cells[i].BackColor = Color.Orange;
                //}
            }

            
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
                sqlStr.AppendLine("WHERE StudentAdmin = @paraStudentAdmin");

                SqlConnection myConn = new SqlConnection(DBConnect);

                sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
                sqlCmd.Parameters.AddWithValue("@paraStatus", "Accepted");
                sqlCmd.Parameters.AddWithValue("@paraStudentAdmin", studAdmin.ToString());

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                myConn.Close();
                StudListDAO tdDAO = new StudListDAO();
                List<StudList> tdList = new List<StudList>();
                tdList = tdDAO.getTDbyTripID(Session["Code"].ToString());
                GridViewTD.DataSource = tdList;
                GridViewTD.DataBind();
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
                sqlStr.AppendLine("WHERE StudentAdmin = @paraStudentAdmin");

                SqlConnection myConn = new SqlConnection(DBConnect);

                sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
                sqlCmd.Parameters.AddWithValue("@paraStatus", "Rejected");
                sqlCmd.Parameters.AddWithValue("@paraStudentAdmin", studAdmin.ToString());

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                myConn.Close();
                StudListDAO tdDAO = new StudListDAO();
                List<StudList> tdList = new List<StudList>();
                tdList = tdDAO.getTDbyTripID(Session["Code"].ToString());
                GridViewTD.DataSource = tdList;
                GridViewTD.DataBind();
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
            string attachment = "attachment; filename=StudentDetails.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
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
            try
            {                
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection myConn = new SqlConnection(DBConnect);

                SqlDataAdapter da;
                DataSet ds = new DataSet();
                //Create Adapter
                StringBuilder sqlCommand = new StringBuilder();

                sqlCommand.AppendLine("select * from [Student] where StudentAdmin = @StudentAdmin");

                da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
                da.SelectCommand.Parameters.AddWithValue("StudentAdmin", tbstudsearch.Text);

                da.Fill(ds);
                int rec_cnt = ds.Tables[0].Rows.Count;
                if (rec_cnt > 0)
                {
                    GridViewTD.DataSource = ds;
                    GridViewTD.DataBind();

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}