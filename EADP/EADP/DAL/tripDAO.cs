﻿using System;
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

        public trip getTrip(string TripID)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from Trip");
            sqlCommand.AppendLine("where TripID = @paraTripID");

            trip obj = new trip();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraTripID", TripID);

            da.Fill(ds, "tripTable");
            int rec_cnt = ds.Tables["tripTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["tripTable"].Rows[0];
                obj.Country = row["Country"].ToString();
                obj.Description = row["Description"].ToString();
                obj.StartDate = Convert.ToDateTime(row["StartDate"]);
                obj.EndDate = Convert.ToDateTime(row["EndDate"]);
                obj.ETripPrice = Convert.ToInt16(row["ETripPrice"]);
                obj.Image = row["Image"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;
        }
        public List<trip> getListTrip(string TripID)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            List<trip> tripList = new List<trip>();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from Trip");
            sqlCommand.AppendLine("where TripID = @paraTripID");

            trip obj = new trip();

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraTripID", TripID);

            da.Fill(ds, "tripTable");
            int rec_cnt = ds.Tables["tripTable"].Rows.Count;
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
                    myTrip.Image = row["Image"].ToString();
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

        public List<trip> getTripInfo()
        {
            List<trip> tripList = new List<trip>();
            DataSet ds = new DataSet();
            DataTable tripData = new DataTable();

            StringBuilder sqlStr = new StringBuilder(); 
            sqlStr.AppendLine("SELECT Trip.TripID, Trip.Country, Trip.StartDate, Trip.EndDate, Trip.ETripPrice, Trip.Duration, Trip.Description, Trip.MaxStudent, Trip.Image, Staff.StaffName FROM Trip");
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
                    myTrip.Image = row["Image"].ToString();
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
        public List<trip> getTripStudyType()
        {
            List<trip> tripList = new List<trip>();
            DataSet ds = new DataSet();
            DataTable tripData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT Trip.TripID, Trip.Country, Trip.StartDate, Trip.EndDate, Trip.ETripPrice, Trip.Duration, Trip.Description, Trip.MaxStudent, Trip.Image, Staff.StaffName FROM Trip");
            sqlStr.AppendLine("INNER JOIN Staff");
            sqlStr.AppendLine("ON Trip.StaffID = Staff.StaffID");
            sqlStr.AppendLine("where GETDATE() <= Trip.EndDate AND TripType = 'Study Trip'");

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
                    myTrip.Image = row["Image"].ToString();
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
        public List<trip> getTripImmType()
        {
            List<trip> tripList = new List<trip>();
            DataSet ds = new DataSet();
            DataTable tripData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT Trip.TripID, Trip.Country, Trip.StartDate, Trip.EndDate, Trip.ETripPrice, Trip.Duration, Trip.Description, Trip.MaxStudent, Trip.Image, Staff.StaffName FROM Trip");
            sqlStr.AppendLine("INNER JOIN Staff");
            sqlStr.AppendLine("ON Trip.StaffID = Staff.StaffID");
            sqlStr.AppendLine("where GETDATE() <= Trip.EndDate AND TripType = 'Immersion Trip'");

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
                    myTrip.Image = row["Image"].ToString();
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

        public int InsertTrip(string TripID, DateTime StartDate, DateTime EndDate, int Duration, string Country, string Description, int MaxStudent, double ETripPrice, int StaffID, string Image, string TripType)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO Trip (TripID, StartDate, EndDate, Duration, Country, Description, MaxStudent, ETripPrice, StaffID, Image, TripType)");
            sqlStr.AppendLine("VALUES (@paraTripID, @paraStartDate, @paraEndDate, @paraDuration, @paraCountry, @paraDescription, @paraMaxStudent, @paraPrice, @paraStaffID, @paraImage, @paraTripType)");

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
            sqlCmd.Parameters.AddWithValue("@paraTripType", TripType);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }

        public int UpdateTrip(string TripID, DateTime StartDate, DateTime EndDate, int Duration, string Country, string Description, int MaxStudent, double ETripPrice, int StaffID, string Image, string TripType)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE Trip SET TripID = @paraTripID, StartDate = @paraStartDate, EndDate = @paraEndDate, Duration = @paraDuration, Country = @paraCountry, Description = @paraDesc, MaxStudent = @paraMaxStud, ETripPrice = @paraPrice, StaffID = @paraStaffID, Image = @paraImage, TripType = @paraTripType");
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
            sqlCmd.Parameters.AddWithValue("@paraTripType", TripType);

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

        

        public List<StudentReg> getStudList(string TripID)
        {
            List<StudentReg> studList = new List<StudentReg>();
            DataSet ds = new DataSet();
            DataTable tripData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM RegisteredStudent");
            sqlStr.AppendLine("INNER JOIN Trip");
            sqlStr.AppendLine("ON RegisteredStudent.TripID = Trip.TripID");
            sqlStr.AppendLine("where RegisteredStudent.TripID = @paraTripID");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            da.SelectCommand.Parameters.AddWithValue("@paraTripID", TripID);
            da.Fill(ds, "studList");

            int rec_cnt = ds.Tables["studList"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["studList"].Rows)
                {
                    StudentReg myStudList = new StudentReg();

                    myStudList.studentAdmin = Convert.ToString(row["StudentAdmin"]);
                    myStudList.TripID = row["TripID"].ToString();
                    myStudList.PassportNO = row["PassportNO"].ToString();
                    myStudList.PassportExpiry = Convert.ToDateTime(row["PassportExpiry"]);

                    studList.Add(myStudList);
                }
            }
            else
            {
                studList = null;
            }

            return studList;
        }


        public List<trip> getStudyTrip()
        {
            List<trip> studyTripList = new List<trip>();
            DataSet ds = new DataSet();
            DataTable tripData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT Trip.TripID, Trip.Country, Trip.StartDate, Trip.EndDate, Trip.ETripPrice, Trip.Duration, Trip.Description, Trip.MaxStudent, Staff.StaffName FROM Trip");
            sqlStr.AppendLine("INNER JOIN Staff");
            sqlStr.AppendLine("ON Trip.StaffID = Staff.StaffID");
            sqlStr.AppendLine("where Trip.TripType = 'Study Trip' AND GETDATE() <= Trip.EndDate");

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

                    studyTripList.Add(myTrip);
                }
            }
            else
            {
                studyTripList = null;
            }

            return studyTripList;
        }

        public List<trip> getStudyTripHist()
        {
            List<trip> studyTripList = new List<trip>();
            DataSet ds = new DataSet();
            DataTable tripData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT Trip.TripID, Trip.Country, Trip.StartDate, Trip.EndDate, Trip.ETripPrice, Trip.Duration, Trip.Description, Trip.MaxStudent, Staff.StaffName FROM Trip");
            sqlStr.AppendLine("INNER JOIN Staff");
            sqlStr.AppendLine("ON Trip.StaffID = Staff.StaffID");
            sqlStr.AppendLine("where Trip.TripType = 'Study Trip' AND Trip.EndDate < GETDATE()");

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

                    studyTripList.Add(myTrip);
                }
            }
            else
            {
                studyTripList = null;
            }

            return studyTripList;
        }

        public List<trip> getImmersionTripInfo()
        {
            List<trip> tripList = new List<trip>();
            DataSet ds = new DataSet();
            DataTable tripData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT Trip.TripID, Trip.Country, Trip.StartDate, Trip.EndDate, Trip.ETripPrice, Trip.Duration, Trip.Description, Trip.MaxStudent, Trip.Image, Staff.StaffName FROM Trip");
            sqlStr.AppendLine("INNER JOIN Staff");
            sqlStr.AppendLine("ON Trip.StaffID = Staff.StaffID");
            sqlStr.AppendLine("where GETDATE() <= Trip.EndDate AND TripType = 'Immersion Trip'");

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
                    myTrip.Image = row["Image"].ToString();
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

        public List<trip> getImmersionTripHist()
        {
            List<trip> studyTripList = new List<trip>();
            DataSet ds = new DataSet();
            DataTable tripData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT Trip.TripID, Trip.Country, Trip.StartDate, Trip.EndDate, Trip.ETripPrice, Trip.Duration, Trip.Description, Trip.MaxStudent, Staff.StaffName FROM Trip");
            sqlStr.AppendLine("INNER JOIN Staff");
            sqlStr.AppendLine("ON Trip.StaffID = Staff.StaffID");
            sqlStr.AppendLine("where GETDATE() >Trip.EndDate AND Trip.TripType = 'Immersion Trip'");

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

                    studyTripList.Add(myTrip);
                }
            }
            else
            {
                studyTripList = null;
            }

            return studyTripList;
        }
    }
}