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

namespace EADP
{
    public partial class ListofStud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Code"] = "Korea2018";
            StudListDAO tdDAO = new StudListDAO();
            List<StudList> tdList = new List<StudList>();
            tdList = tdDAO.getTDbyTripID(Session["Code"].ToString());
            GridViewTD.DataSource = tdList;
            GridViewTD.DataBind();
            ProgCode.Text = "<h1>" + Session["Code"].ToString() + "</h1>";
            
        }

        protected void GridViewTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewTD.SelectedRow;
            // In this grid, the first cell (index 0) contains
            // the TD Account.
            Session["studInfo"] = row.Cells[0].Text;
            Response.Redirect("StudentDetails.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select RegisteredStudent.StudentAdmin, Student.StudentName,Student.Gender,Student.School,Student.PEMGroup,RegisteredStudent.Nationality,RegisteredStudent.PassportNO,RegisteredStudent.PassportExpiry,RegisteredStudent.DietConstraint,RegisteredStudent.MedicalHistory,RegisteredStudent.FASscheme,RegisteredStudent.Remarks from Student");
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

    }
}