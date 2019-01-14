using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;
using System.Data;

namespace EADP
{
    public partial class ProfilePic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("LoginStudent.aspx");
            }
        }
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string uploadFileName = "";
            string uploadFilePath = "";            
            if (FU1.HasFile)
            {
                string ext = Path.GetExtension(FU1.FileName).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".png")
                {
                    uploadFileName = Guid.NewGuid().ToString() + ext;
                    uploadFilePath = Path.Combine(Server.MapPath("~/ProfilePic"), uploadFileName);
                    try
                    {
                        FU1.SaveAs(uploadFilePath);
                        imgUpload.ImageUrl = "~/ProfilePic/" + uploadFileName;
                        panCrop.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = "Error! Please try again.";
                    }
                }
                else
                {
                    lblMsg.Text = "Selected file type not allowed!";
                }
            }
            else
            {
                
                lblMsg.Text = "Please select file first!";
            }
        }

        protected void btnCrop_Click(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/ProfilePic"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            
            if (File.Exists(filePath))
            {
                System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath);
                Rectangle CropArea = new Rectangle(
                    Convert.ToInt32(X.Value),
                    Convert.ToInt32(Y.Value),
                    Convert.ToInt32(W.Value),
                    Convert.ToInt32(H.Value));
                try
                {
                    Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                    using (Graphics g = Graphics.FromImage(bitMap))
                    {
                        g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                    }
                    cropFileName = "crop_" + fileName;
                    cropFilePath = Path.Combine(Server.MapPath("~/ProfilePic"), cropFileName);
                    bitMap.Save(cropFilePath);
                    //if (System.IO.File.Exists(delFilePath))
                    //{
                    //    System.IO.File.Delete(delFilePath);
                    //}
                    StudList tdList = new StudList();
                    StudListDAO tdDAO = new StudListDAO();
                    tdList = tdDAO.getRegbyStudAdmin(Session["username"].ToString());


                    SqlConnection myConn = new SqlConnection(DBConnect);
                    StringBuilder sqlCommand = new StringBuilder();

                    SqlDataAdapter da;
                    DataSet ds = new DataSet();
                    sqlCommand.AppendLine("Select * from ProfilePic where StudentAdmin = @paraStudAdmin");


                    da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
                    da.SelectCommand.Parameters.AddWithValue("@paraStudAdmin", tdList.studentAdmin.ToString());
                    da.Fill(ds, "stud_table");
                    int rec_cnt = ds.Tables["stud_table"].Rows.Count;

                    if (rec_cnt > 0)
                    {
                        StringBuilder sqlImg = new StringBuilder();
                        int resultImg = 0;
                        SqlCommand sqlCmdImg = new SqlCommand();

                        sqlImg.AppendLine("UPDATE ProfilePic set Image = @paraImage ");
                        sqlImg.AppendLine("WHERE StudentAdmin = @paraStudentAdmin");

                        sqlCmdImg = new SqlCommand(sqlImg.ToString(), myConn);

                        string Imagepath = "crop_" + fileName.ToString();
                        string Image = "~/ProfilePic/" + Imagepath;

                        sqlCmdImg.Parameters.AddWithValue("@paraImage", Image);
                        sqlCmdImg.Parameters.AddWithValue("@paraStudentAdmin", tdList.studentAdmin.ToString());

                        myConn.Open();
                        resultImg = sqlCmdImg.ExecuteNonQuery();

                        myConn.Close();

                        Response.Redirect("Account.aspx");
                    }
                    else
                    {

                        StringBuilder sqlStr = new StringBuilder();
                        int result = 0;
                        SqlCommand sqlCmd = new SqlCommand();

                        sqlStr.AppendLine("INSERT INTO ProfilePic (StudentAdmin, Image)");
                        sqlStr.AppendLine("VALUES (@paraStudAdmin,@paraImage)");

                        sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

                        string Imagepath = "crop_" + fileName.ToString();
                        string Image = "~/ProfilePic/" + Imagepath;

                        sqlCmd.Parameters.AddWithValue("@paraStudAdmin", tdList.studentAdmin.ToString());
                        sqlCmd.Parameters.AddWithValue("@paraImage", Image);

                        myConn.Open();
                        result = sqlCmd.ExecuteNonQuery();

                        myConn.Close();

                        Response.Redirect("Account.aspx");
                    }


                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}