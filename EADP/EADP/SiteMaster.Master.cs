using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Label1.Text = Session["username"].ToString();
            }
            else if (Session["teacher"] != null)
            {
                Label1.Text = Session["teacher"].ToString();
            }
        }
        protected void Logout_OnClick(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["teacher"] = null;
            Response.Redirect("LoginStudent.aspx");
        }
    }
}