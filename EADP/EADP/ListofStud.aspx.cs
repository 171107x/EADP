using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;

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
    }
}