using EADP.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP
{
    public partial class EditTrip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbProgCode.Text = string.Empty;
            tbProgYear.Text = string.Empty;
            //tbDuration.Text = string.Empty;
            tbCountry.Text = string.Empty;
            tbLeadStaff.Text = string.Empty;
            tbMaxStud.Text = string.Empty;
            tbPrice.Text = string.Empty;
            imgUpload.Attributes.Clear();
            foreach (var item in Page.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }

            //OR 
            //Response.redirect("EditTrip.aspx");
        }

        private void show_img()
        {
            DirectoryInfo d = new DirectoryInfo(MapPath("~/tripImg/"));
            FileInfo[] r = d.GetFiles();
            DataTable dt = new DataTable();
            dt.Columns.Add("path");

            DataRow row = dt.NewRow();
            /*int lastPos = r.Length - 1;*/
            row["path"] = "~/tripImg/" + r[0].Name;
            dt.Rows.Add(row);

            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string TripID = Convert.ToString(tbProgCode.Text.ToString());
                DateTime StartDate = Convert.ToDateTime(tbProgYear.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(tbEndDate.Text.ToString());
                TimeSpan Diff = EndDate - StartDate;
                int Duration = Convert.ToInt16(Diff.Days.ToString());
                string Country = tbCountry.Text.ToString();
                string Description = Request.Form["taDesc"].ToString();
                int MaxStudent = Convert.ToInt16(tbMaxStud.Text.ToString());
                double ETripPrice = Convert.ToDouble(tbPrice.Text.ToString());
                int StaffID = Convert.ToInt16(tbLeadStaff.Text.ToString());
                string Image = "~/tripImg/" + Guid.NewGuid().ToString() + "" + Path.GetExtension(imgUpload.FileName);

                if(StartDate < DateTime.Now.Date)
                {
                    lblValid.Text = "Invalid Start Date!";
                    tbProgYear.Focus();
                }
                else if(EndDate < DateTime.Now.Date)
                {
                    lblValid.Text = "Invalid End Date!";
                    tbEndDate.Focus();
                }
                else
                {
                    tripDAO newTrip = new tripDAO();
                    newTrip.InsertTrip(TripID, StartDate, EndDate, Duration, Country, Description, MaxStudent, ETripPrice, StaffID, Image);
                    Response.Redirect("TripManagement.aspx");
                }
            }
            else
            {
                lblValid.Text = "ProgCode Already Exist!";
                tbProgCode.Focus();
            }
        }

        protected void btnUpload_Click1(object sender, EventArgs e)
        {
            if (imgUpload.HasFile)
            {
                string path = "~/tripImg/" + Guid.NewGuid().ToString() + "" + Path.GetExtension(imgUpload.FileName);
                imgUpload.SaveAs(MapPath(path));
                show_img();
            }

        }

        protected void ValidateProgCode(object source, ServerValidateEventArgs args)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string TripID = Convert.ToString(tbProgCode.Text.ToString());
            SqlCommand cmd = new SqlCommand("SELECT TripID FROM Trip WHERE TripID ='" + TripID + "'", myConn);
            myConn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    lblValid.Text = "ProgCode Already Exist!";
                    args.IsValid = false;
                    tbProgCode.Focus();
                }
                else
                {
                    lblValid.Text = string.Empty;
                    args.IsValid = true;
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                args.IsValid = false;
            }
        }
    }
}