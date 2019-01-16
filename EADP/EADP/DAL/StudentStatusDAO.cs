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
        public List<StudentStatus> getStudentStatus(string studentadmin, DateTime CurrentDate)
        {
            List<StudentStatus> tdList = new List<StudentStatus>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select Trip.TripID, Image,StartDate, TripStatus, StudentAdmin, Country from Trip");
            sqlStr.AppendLine("inner join RegisteredStudent");
            sqlStr.AppendLine("On RegisteredStudent.TripID = Trip.TripID");
            sqlStr.AppendLine("where RegisteredStudent.StudentAdmin = @paraStudentAdmin AND StartDate > @paraCurrentDate;");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            da.SelectCommand.Parameters.AddWithValue("paraStudentAdmin", studentadmin);
            da.SelectCommand.Parameters.AddWithValue("paraCurrentDate", CurrentDate);

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
                    myTD.Country = row["TripID"].ToString();



                    tdList.Add(myTD);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }
        public StudentStatus getStudentdate(string studentadmin, DateTime CurrentDate)
        {
            StudentStatus myTD = new StudentStatus();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select Trip.TripID, Image,StartDate, TripStatus, StudentAdmin, Country from Trip");
            sqlStr.AppendLine("inner join RegisteredStudent");
            sqlStr.AppendLine("On RegisteredStudent.TripID = Trip.TripID");
            sqlStr.AppendLine("where RegisteredStudent.StudentAdmin = @paraStudentAdmin AND StartDate > @paraCurrentDate;");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            da.SelectCommand.Parameters.AddWithValue("paraStudentAdmin", studentadmin);
            da.SelectCommand.Parameters.AddWithValue("paraCurrentDate", CurrentDate);

            da.Fill(ds, "TableTD");


            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableTD"].Rows[0];
                

                myTD.Image = row["Image"].ToString();
                myTD.StartDate = Convert.ToDateTime(row["StartDate"]);
                myTD.TripStatus = row["TripStatus"].ToString();
                myTD.StudentAdmin = row["StudentAdmin"].ToString();
                myTD.Country = row["TripID"].ToString();                
                   
            }
            else
            {
                myTD = null;
            }

            return myTD;
        }
        public StudentStatus getdate(string TripID)
        {
            StudentStatus myTD = new StudentStatus();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select StartDate from Trip");            
            sqlStr.AppendLine("where TripID = @paraTripID;");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);
            
            da.SelectCommand.Parameters.AddWithValue("paraTripID", TripID);

            da.Fill(ds, "TableTD");


            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableTD"].Rows[0];
               
                myTD.StartDate = Convert.ToDateTime(row["StartDate"]);
                
            }
            else
            {
                myTD = null;
            }

            return myTD;
        }
    }
}
