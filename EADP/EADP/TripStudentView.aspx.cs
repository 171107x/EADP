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
    public partial class TripStudentView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //DataTable dt = this.GetData();
                //StringBuilder html = new StringBuilder();

                //html.Append("<div class='row'>");
                //html.Append("<hr/>");
                //foreach (DataRow row in dt.Rows)
                //{
                //    html.Append("<div class='col-sm-6'>");
                //    html.Append("<div class='card'>");
                //    html.Append("<div class='card-body'>");
                //    html.Append("<img class='card-img-top col-sm-4' src='Images/wallpaper2.jpg' style='width:300px;height:250px;'>");
                //    html.Append("<h3 class='card-title bold'>");
                //    html.Append(row[0].ToString());
                //    html.Append("</h3>");
                //    html.Append("<p class='card-text'>");
                //    html.Append(row[1].ToString());
                //    html.Append("</p>");
                //    html.Append("<p class='card-text'>");
                //    html.Append("Price: $"+row[2].ToString());
                //    html.Append("</p>");
                //    html.Append("<br/><br/><br/><br/><br/>");
                //    html.Append("<button class='btn btn-primary float-right' onclick='btnDetails_Click'>More details</button>");
                //    //html.Append("<asp:Button class='btn btn-primary float-right' runat='server' Text='More Details' onclick='btnDetails_Click'/>");
                //    //html.Append("<br/><br/><br/><br/>");
                //    html.Append("</div>");
                //    html.Append("</div>");
                //    html.Append("</div>");
                //}
                //html.Append("</div>");

                //Append the HTML string to Placeholder.
                //PHTripDetails.Controls.Add(new Literal { Text = html.ToString() });

                trip tripOjb = new trip();
                tripDAO tripDAO = new tripDAO();

                List<trip> tripList = new List<trip>();
                tripList = tripDAO.getTripInfo();
                TripList.DataSource = tripList;
                TripList.DataBind();
            }
        }

        //private DataTable GetData()
        //{
        //    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //    using (SqlConnection myConn = new SqlConnection(DBConnect))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT Country, Description, ETripPrice FROM Trip WHERE Country ='Australia'"))
        //        {
        //            using (SqlDataAdapter da = new SqlDataAdapter())
        //            {
        //                cmd.Connection = myConn;
        //                da.SelectCommand = cmd;
        //                using (DataTable dt = new DataTable())
        //                {
        //                    da.Fill(dt);
        //                    return dt;
        //                }
        //            }
        //        }
        //    }
        //}

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            //TripList.SelectedItemTemplate = 
            //Session["SScountry"] = 
            //Lbl_description.Text = Session["SScountry"].ToString();
            Response.Redirect("TripDetais.aspx");
        }
    }
}