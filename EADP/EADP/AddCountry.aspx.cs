using EADP.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP
{
    public partial class AddCountry : System.Web.UI.Page
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                bindgrid();
            }
        }
        private void bindgrid()
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            DataTable dtCountry = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT countryName, countryID FROM Country");

            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);
            da.Fill(dtCountry);
            GridViewCountry.DataSource = dtCountry;
            GridViewCountry.DataBind();
        }
        
        protected void GridViewCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCountry.PageIndex = e.NewPageIndex;
            bindgrid();
        }

        protected void GridViewCountry_RowCommand(object sender, GridViewDeleteEventArgs e)
        {
            
            
                int index;
                //bool bIsConverted = int.TryParse(e.CommandArgument.ToString(), out index);
                //GridViewRow row = GridViewCountry.Rows[index];
                
            
        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (textboxCountry.Text=="")
            {
                Response.Write("Fill in the Country Name");
            }
            else
            {
                string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

                StringBuilder sqlStr = new StringBuilder();
                int result = 0;    // Execute NonQuery return an integer value
                SqlCommand sqlCmd = new SqlCommand();

                sqlStr.AppendLine("INSERT INTO Country (countryName)");
                sqlStr.AppendLine("VALUES (@paraCountryName)");

                SqlConnection myConn = new SqlConnection(DBConnect);

                sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

                sqlCmd.Parameters.AddWithValue("@paraCountryName", textboxCountry.Text);

                myConn.Open();
                result = sqlCmd.ExecuteNonQuery();

                myConn.Close();

                Response.Redirect("AddCountry.aspx");
            }
        }

        protected void GridViewCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridViewCountry_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCountry.EditIndex = e.NewEditIndex;
            bindgrid();
        }

        protected void GridViewCountry_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCountry.EditIndex = -1;
            bindgrid();
        }

        protected void GridViewCountry_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label editlb = GridViewCountry.Rows[e.RowIndex].FindControl("lbCountryID") as Label;
            TextBox edittb = GridViewCountry.Rows[e.RowIndex].FindControl("tbCountryName") as TextBox;

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE [Country] set CountryName=@countryname where CountryID=@countryid";
            cmd.Parameters.AddWithValue("@countryid", editlb.Text);

            cmd.Parameters.AddWithValue("@countryname", edittb.Text);
            cmd.Connection = myConn;
            cmd.ExecuteNonQuery();

            GridViewCountry.EditIndex = -1;
            bindgrid();

        }

        protected void GridViewCountry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string id = GridViewCountry.DataKeys[e.RowIndex].Values["CountryID"].ToString();
            int result;
            myConn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Country where CountryID='"+id+"'", myConn);
            result = cmd.ExecuteNonQuery();
            myConn.Close();

            Response.Redirect("AddCountry.aspx");
        }
    }
}