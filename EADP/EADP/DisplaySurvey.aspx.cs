using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace EADP
{
    public partial class DisplaySurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            SurveyQ tdList = new SurveyQ();
            SurveyQDAO tdDAO = new SurveyQDAO();
            List<SurveyQ> surveyList = new List<SurveyQ>();
            surveyList = tdDAO.getSurveyID();
            GridView1.DataSource = surveyList;
            GridView1.DataBind();
            BtnSurvey.Visible = false;
            if (GridView1.Rows.Count < 1)
            {
                Label1.Text = "<h1 style='text-align:center;'>There are no Surveys at the moment. Create a Survey below!</h1>";
                BtnSurvey.Visible = true;
                GridView1.Enabled = false;

            }
            else
            {
                Label1.Text = "<h2> Current List of Surveys </h2>";
            }
            
        }

     

        protected void Click_Delete(object sender, GridViewDeleteEventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string Id = GridView1.Rows[e.RowIndex].Cells[0].Text;
            int result;
            myConn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM SurveyQns WHERE SurveyQID ='" + Id + "'", myConn);
            result = cmd.ExecuteNonQuery();
            myConn.Close();
            if (result == 1)
            {
                SurveyQ surveyObj = new SurveyQ();
                SurveyQDAO tdDAO = new SurveyQDAO();
                List<SurveyQ> tdList = new List<SurveyQ>();
                tdList = tdDAO.getSurveyID();
                GridView1.DataSource = tdList;
                GridView1.DataBind();
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Session["SurveyID"] = row.Cells[0].Text;
            Response.Redirect("EditSurvey.aspx");
        }

        protected void BtnSurvey_Click(object sender, EventArgs e)
        {
            Response.Redirect("Createsurvey.aspx");
        }
    }
}