using EADP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP
{
    public partial class regStudList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudRegDAO studDAO = new StudRegDAO();

            List<StudentReg> studentList = new List<StudentReg>();
            studentList = studDAO.getStudListInfo();
            GVStudList.DataSource = studentList;
            GVStudList.DataBind();

        }
    }
}