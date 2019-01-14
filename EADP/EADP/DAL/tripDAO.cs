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
    public class tripDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public trip getTrip()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from Trip");
            //sqlCommand.AppendLine("where TripID = 1");

            trip obj = new trip();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            //da.SelectCommand.Parameters.AddWithValue("1", TripID);

            da.Fill(ds, "tripTable");
            int rec_cnt = ds.Tables["tripTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["tripTable"].Rows[0];
                obj.StartDate = Convert.ToDateTime(row["StartDate"]);
                obj.EndDate = Convert.ToDateTime(row["EndDate"]);
            }
            else
            {
                obj = null;
            }

            return obj;
        }

        public List<trip> getTripInfo()
        {
            List<trip> tripList = new List<trip>();
            DataSet ds = new DataSet();
            DataTable tripData = new DataTable();

            StringBuilder sqlStr = new StringBuilder(); 
            sqlStr.AppendLine("SELECT Trip.TripID, Trip.Country, Trip.StartDate, Trip.EndDate, Trip.ETripPrice, Trip.Duration, Trip.Description, Trip.MaxStudent, Staff.StaffName FROM Trip");
            sqlStr.AppendLine("INNER JOIN Staff");
            sqlStr.AppendLine("ON Trip.StaffID = Staff.StaffID");
            sqlStr.AppendLine("where GETDATE() <= Trip.EndDate");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            //da.SelectCommand.Parameters.AddWithValue("1", TripID);
            da.Fill(ds, "TableInfo");

            int rec_cnt = ds.Tables["TableInfo"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableInfo"].Rows)
                {
                    trip myTrip = new trip();

                    myTrip.TripID = Convert.ToString(row["TripID"]);
                    myTrip.Country = row["Country"].ToString();
                    myTrip.StartDate = Convert.ToDateTime(row["StartDate"]);
                    myTrip.EndDate = Convert.ToDateTime(row["EndDate"]);
                    myTrip.ETripPrice = Convert.ToDouble(row["ETripPrice"]);
                    myTrip.Duration = Convert.ToInt16(row["Duration"]);
                    myTrip.Description = row["Description"].ToString();
                    myTrip.MaxStudent = Convert.ToInt16(row["MaxStudent"]);
                    myTrip.StaffName = row["StaffName"].ToString();

                    tripList.Add(myTrip);
                }
            }
            else
            {
                tripList = null;
            }

            return tripList;
        }

        public List<trip> getTripHist()
        {
            List<trip> tripList = new List<trip>();
            DataSet ds = new DataSet();
            DataTable tripData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT Trip.TripID, Trip.Country, Trip.StartDate, Trip.EndDate, Trip.ETripPrice, Trip.Duration, Trip.Description, Trip.MaxStudent, Staff.StaffName FROM Trip");
            sqlStr.AppendLine("INNER JOIN Staff");
            sqlStr.AppendLine("ON Trip.StaffID = Staff.StaffID");
            sqlStr.AppendLine("where Trip.EndDate < GETDATE()");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            //da.SelectCommand.Parameters.AddWithValue("1", TripID);
            da.Fill(ds, "TableInfo");

            int rec_cnt = ds.Tables["TableInfo"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableInfo"].Rows)
                {
                    trip myTrip = new trip();

                    myTrip.TripID = Convert.ToString(row["TripID"]);
                    myTrip.Country = row["Country"].ToString();
                    myTrip.StartDate = Convert.ToDateTime(row["StartDate"]);
                    myTrip.EndDate = Convert.ToDateTime(row["EndDate"]);
                    myTrip.ETripPrice = Convert.ToDouble(row["ETripPrice"]);
                    myTrip.Duration = Convert.ToInt16(row["Duration"]);
                    myTrip.Description = row["Description"].ToString();
                    myTrip.MaxStudent = Convert.ToInt16(row["MaxStudent"]);
                    myTrip.StaffName = row["StaffName"].ToString();

                    tripList.Add(myTrip);
                }
            }
            else
            {
                tripList = null;
            }

            return tripList;
        }

        public int InsertTrip(string TripID, DateTime StartDate, DateTime EndDate, int Duration, string Country, string Description, int MaxStudent, double ETripPrice, int StaffID, string Image)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO Trip (TripID, StartDate, EndDate, Duration, Country, Description, MaxStudent, ETripPrice, StaffID, Image)");
            sqlStr.AppendLine("VALUES (@paraTripID, @paraStartDate, @paraEndDate, @paraDuration, @paraCountry, @paraDescription, @paraMaxStudent, @paraPrice, @paraStaffID, @paraImage)");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraTripID", TripID);
            sqlCmd.Parameters.AddWithValue("@paraStartDate", StartDate);
            sqlCmd.Parameters.AddWithValue("@paraEndDate", EndDate);
            sqlCmd.Parameters.AddWithValue("@paraDuration", Duration);
            sqlCmd.Parameters.AddWithValue("@paraCountry", Country);
            sqlCmd.Parameters.AddWithValue("@paraDescription", Description);
            sqlCmd.Parameters.AddWithValue("@paraMaxStudent", MaxStudent);
            sqlCmd.Parameters.AddWithValue("@paraPrice", ETripPrice);
            sqlCmd.Parameters.AddWithValue("@paraStaffID", StaffID);
            sqlCmd.Parameters.AddWithValue("@paraImage", Image);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public int UpdateTrip(string TripID, DateTime StartDate, DateTime EndDate, int Duration, string Country, string Description, int MaxStudent, double ETripPrice, int StaffID, string Image)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE Trip SET TripID = @paraTripID, StartDate = @paraStartDate, EndDate = @paraEndDate, Duration = @paraDuration, Country = @paraCountry, Description = @paraDesc, MaxStudent = @paraMaxStud, ETripPrice = @paraPrice, StaffID = @paraStaffID, Image = @paraImage");
            sqlStr.AppendLine("WHERE TripID = @paraTripID");
            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraTripID", TripID);
            sqlCmd.Parameters.AddWithValue("@paraStartDate", StartDate);
            sqlCmd.Parameters.AddWithValue("@paraEndDate", EndDate);
            sqlCmd.Parameters.AddWithValue("@paraDuration", Duration);
            sqlCmd.Parameters.AddWithValue("@paraCountry", Country);
            sqlCmd.Parameters.AddWithValue("@paraDesc", Description);
            sqlCmd.Parameters.AddWithValue("@paraMaxStud", MaxStudent);
            sqlCmd.Parameters.AddWithValue("@paraPrice", ETripPrice);
            sqlCmd.Parameters.AddWithValue("@paraStaffID", StaffID);
            sqlCmd.Parameters.AddWithValue("@paraImage", Image);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public int DeleteTrip(string TripID)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE FROM Trip");
            sqlStr.AppendLine("WHERE TripID = @paraTripID");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraTripID", TripID);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

    }
}