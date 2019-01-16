using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace EADP.DAL
{
    public class StudentStatusDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public List<StudentStatus> getStudentStatus(string studentadmin)
        {
            List<StudentStatus> tdList = new List<StudentStatus>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select Image,StartDate, TripStatus, StudentAdmin, Country from Trip");
            sqlStr.AppendLine("inner join RegisteredStudent");
            sqlStr.AppendLine("On RegisteredStudent.TripID = Trip.TripID");
            sqlStr.AppendLine("where RegisteredStudent.StudentAdmin = @paraStudentAdmin;");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            da.SelectCommand.Parameters.AddWithValue("paraStudentAdmin", studentadmin);


            da.Fill(ds, "TableTD");


            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableTD"].Rows)
                {
                    StudentStatus myTD = new StudentStatus();

                    myTD.Image = row["Image"].ToString();
                    myTD.StartDate = Convert.ToDateTime(row["StartDate"]);
                    myTD.TripStatus = row["TripStatus"].ToString();
                    myTD.StudentAdmin = row["StudentAdmin"].ToString();
                    myTD.Country = row["Country"].ToString();



                    tdList.Add(myTD);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }
    }
}