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
                DataTable dt = this.GetData();
                StringBuilder html = new StringBuilder();

                html.Append("<div class='row'>");
                html.Append("<hr/>");
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<div class='col-sm-4'>");
                    html.Append("<div class='card'>");
                    html.Append("<div class='card-body'>");
                    html.Append("<img class='card-img-top' src='Images/france.jpg' style='width:250px;height:250px;'>");
                    html.Append("<h5 class='card-title'>");
                    html.Append(row[0].ToString());
                    html.Append("</h5>");
                    html.Append("<p class='card-text'>");
                    html.Append(row[1].ToString());
                    html.Append("</p>");
                    html.Append("<p class='card-text'>");
                    html.Append("$"+row[2].ToString());
                    html.Append("</p>");
                    html.Append("<a href='#' class='btn btn-primary'>Register</a>");
                    html.Append("<br/>");
                    html.Append("<br/>");
                    html.Append("<br/>");
                    html.Append("<br/>");
                    html.Append("</div>");
                    html.Append("</div>");
                    html.Append("</div>");
                }
                html.Append("</div>");

                //Append the HTML string to Placeholder.
                PHTripDetails.Controls.Add(new Literal { Text = html.ToString() });
            }
        }

        private DataTable GetData()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Country, Description, ETripPrice FROM Trip"))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        cmd.Connection = myConn;
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}