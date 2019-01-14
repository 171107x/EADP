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
        public int InsertSurveyAnswers(int surveyQnsID, string q1, string q2, string q3, string q4)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO SurveyQns (SurveyQID, Q1, Q2, Q3, Q4)");
            sqlStr.AppendLine("VALUES (@paraSurveyQID,@paraQ1, @paraQ2, @paraQ3, @paraQ4)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraSurveyQID", surveyQnsID);
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
        public SurveyQ getSurveyQuestions(int surveyQnsID)
        {
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select * from SurveyQns");
            sqlStr.AppendLine("Where SurveyQID = @paraSurveyQID;");



            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);



            da.SelectCommand.Parameters.AddWithValue("paraSurveyQID", surveyQnsID);


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
    }
    }