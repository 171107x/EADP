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
    public class StudRegDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public int InsertStudReg(String studentAdmin, string tripID, string PassportNO, DateTime PassportExpiry, string FASscheme, string WaitingList, double PSEABalance)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO RegisteredStudent (StudentAdmin, TripID, PassportNO, ");
            sqlStr.AppendLine("PassportExpiry, FASscheme, WaitingList, PSEABalance)");
            sqlStr.AppendLine("VALUES (@paraStudAdmin,@paraTripID, @paraPassportNO, ");
            sqlStr.AppendLine("@paraPassportExpiry, @paraFASscheme, @paraWaitingList, @paraPSEABalance)");


            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);


            sqlCmd.Parameters.AddWithValue("@paraStudAdmin", studentAdmin);
            sqlCmd.Parameters.AddWithValue("@paraTripID", tripID);
            sqlCmd.Parameters.AddWithValue("@paraPassportNO", PassportNO);
            sqlCmd.Parameters.AddWithValue("@paraPassportExpiry", PassportExpiry);
            sqlCmd.Parameters.AddWithValue("@paraFASscheme", FASscheme);
            sqlCmd.Parameters.AddWithValue("@paraWaitingList", WaitingList);
            sqlCmd.Parameters.AddWithValue("@paraPSEABalance", PSEABalance);



            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

           
            myConn.Close();

            return result;

        }

        public List<StudentReg> getStudListInfo()
        {
            List<StudentReg> studentList = new List<StudentReg>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT RegisteredStudent.StudentAdmin, Trip.TripID, RegisteredStudent.PassportNO, RegisteredStudent.PassportExpiry FROM RegisteredStudent");
            //sqlStr.AppendLine("SELECT * FROM RegisteredStudent");
            sqlStr.AppendLine("INNER JOIN Trip");
            sqlStr.AppendLine("ON RegisteredStudent.TripID = Trip.TripID");
            sqlStr.AppendLine("WHERE RegisteredStudent.TripID = 'Korea2018'");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.Fill(ds, "studList");

            int rec_cnt = ds.Tables["studList"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["studList"].Rows)
                {
                    StudentReg myStudList = new StudentReg();

                    myStudList.TripID = Convert.ToString(row["TripID"]);
                    myStudList.studentAdmin = row["StudentAdmin"].ToString();
                    myStudList.PassportNO = Convert.ToString(row["PassportNO"]);
                    myStudList.PassportExpiry = Convert.ToDateTime(row["PassportExpiry"]);

                    studentList.Add(myStudList);
                }
            }
            else
            {
                studentList = null;
            }

            return studentList;
        }
        public StudentReg getTripID(String studentAdmin)
        {
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select * from RegisteredStudent");
            sqlStr.AppendLine("Where StudentAdmin = @paraStudAdmin and TripStatus = 'Accepted';");



            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);



            da.SelectCommand.Parameters.AddWithValue("paraStudAdmin", studentAdmin);


            da.Fill(ds, "TableTD");



            int rec_cnt = ds.Tables["TableTD"].Rows.Count;

            StudentReg myTD = new StudentReg();
            if (rec_cnt > 0)
            {



                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.studentAdmin = row["StudentAdmin"].ToString();
                myTD.TripID = row["TripID"].ToString();



            }
            else
            {
                myTD = null;
            }

            return myTD;
        }

    }
}
