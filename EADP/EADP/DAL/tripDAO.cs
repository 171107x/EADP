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

        /*       public trip getTripById(int TripID)
               {
                   SqlDataAdapter da;
                   DataSet ds = new DataSet();

                   StringBuilder sqlCommand = new StringBuilder();
                   sqlCommand.AppendLine("Select * from Trip");
                   //sqlCommand.AppendLine("where TripID = 1");

                   trip obj = new trip();

                   SqlConnection myConn = new SqlConnection(DBConnect);
                   da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
                  // da.SelectCommand.Parameters.AddWithValue("1", TripID);

                   da.Fill(ds, "tripTable");
                   int rec_cnt = ds.Tables["tripTable"].Rows.Count;
                   if (rec_cnt > 0)
                   {
                       DataRow row = ds.Tables["tripTable"].Rows[0];
                       obj.Country = row["Country"].ToString();
                       obj.Description = row["Description"].ToString();
                   }
                   else
                   {
                       obj = null;
                   }

                   return obj;
               }
               */
        public List<trip> getTripInfo()
        {
            List<trip> tdList = new List<trip>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From trip");
            //sqlStr.AppendLine("where TripID = 1");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            //da.SelectCommand.Parameters.AddWithValue("1", TripID);
            da.Fill(ds, "TableInfo");

            int rec_cnt = ds.Tables["TableInfo"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableInfo"].Rows)
                {
                    trip myTD = new trip();

                    myTD.TripID = Convert.ToString(row["TripID"]);
                    myTD.Country = row["Country"].ToString();
                    myTD.StartDate = Convert.ToDateTime(row["StartDate"]);
                    myTD.EndDate = Convert.ToDateTime(row["EndDate"]);
                    myTD.ETripPrice = Convert.ToDouble(row["ETripPrice"]);

                    tdList.Add(myTD);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }

        public int InsertTrip(string TripID, DateTime StartDate, DateTime EndDate, string Country, double ETripPrice)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO Trip (TripID, StartDate, EndDate, Country, ETripPrice)");
            sqlStr.AppendLine("VALUES (@paraTripID, @paraStartDate, @paraEndDate, @paraCountry, @paraPrice)");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraTripID", TripID);
            sqlCmd.Parameters.AddWithValue("@paraStartDate", StartDate);
            sqlCmd.Parameters.AddWithValue("@paraEndDate", EndDate);
            sqlCmd.Parameters.AddWithValue("@paraCountry", Country);
            sqlCmd.Parameters.AddWithValue("@paraPrice", ETripPrice);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }
    }
}