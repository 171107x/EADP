﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;

namespace EADP
{
    public partial class LoginStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            //Create Adapter
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("Select * from Staff where Email = @paraEmail and Password = @paraPassword");

            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraEmail", tbEmail.Text);
            da.SelectCommand.Parameters.AddWithValue("paraPassword", Encryption.MD5Hash(tbPassword.Text));
            

            // fill dataset
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt > 0)
            {
                Session["username"] = tbEmail.Text;
                Response.Redirect("home.aspx");

            }
            else
            {
                Response.Redirect("wrong.aspx");
            }
        }
    }
}