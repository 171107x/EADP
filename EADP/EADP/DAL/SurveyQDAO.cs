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
    public class SurveyQDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public int InsertSurveyAnswers(string q1, string q2, string q3, string q4)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO SurveyQns ( Q1, Q2, Q3, Q4)");
            sqlStr.AppendLine("VALUES (@paraQ1, @paraQ2, @paraQ3, @paraQ4)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraQ1", q1);
            sqlCmd.Parameters.AddWithValue("@paraQ2", q2);
            sqlCmd.Parameters.AddWithValue("@paraQ3", q3);
            sqlCmd.Parameters.AddWithValue("@paraQ4", q4);


            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }
        public SurveyQ getSurveyQuestions()
        {
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select * from SurveyQns");
            sqlStr.AppendLine("Where SurveyQID = (select min(SurveyQID) from SurveyQns);");



            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);





            da.Fill(ds, "TableTD");



            int rec_cnt = ds.Tables["TableTD"].Rows.Count;

            SurveyQ myTD = new SurveyQ();
            if (rec_cnt > 0)
            {



                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.q1 = row["Q1"].ToString();
                myTD.q2 = row["Q2"].ToString();
                myTD.q3 = row["Q3"].ToString();
                myTD.q4 = row["Q4"].ToString();
            }
            else
            {
                myTD = null;
            }

            return myTD;
        }
        public List<SurveyQ> getSurveyID()
        {
            List<SurveyQ> List = new List<SurveyQ>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select * from SurveyQns");



            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);




            da.Fill(ds, "TableTD");



            int rec_cnt = ds.Tables["TableTD"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableTD"].Rows)
                {
                    SurveyQ slist = new SurveyQ();
                    slist.SurveyQID = row["SurveyQID"].ToString();
                    List.Add(slist);
                }
            }

            else
            {
                List = null;
            }

            return List;

        }
        public int updateSurvey(int surveyQnsID,string q1, string q2, string q3, string q4)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            int result;
            myConn.Open();
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();
            sqlStr.AppendLine("UPDATE SurveyQns");
            sqlStr.AppendLine("SET Q1 = @paraQ1,");
            sqlStr.AppendLine("Q2 = @paraQ2,");
            sqlStr.AppendLine("Q3 = @paraQ3,");
            sqlStr.AppendLine("Q4 = @paraQ4");
            sqlStr.AppendLine("Where SurveyQID = @paraSurveyQID");
            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraSurveyQID", surveyQnsID);
            sqlCmd.Parameters.AddWithValue("@paraQ1", q1);
            sqlCmd.Parameters.AddWithValue("@paraQ2", q2);
            sqlCmd.Parameters.AddWithValue("@paraQ3", q3);
            sqlCmd.Parameters.AddWithValue("@paraQ4", q4);
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

    }
}