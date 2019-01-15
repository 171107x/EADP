using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace EADP.DAL
{
    public class SurveyDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public int InsertSurveyAnswers(String surveyAnsID, String studentAdmin, string q1Ans, string q2Ans, string q3Ans, string q4Ans, string q5Ans, string q6Ans, string q7Ans)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to Survey Table using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO SurveyAns (SurveyAnsID,StudentAdmin, q1Ans, q2Ans, q3Ans, q4Ans, q5Ans, q6Ans, q7Ans)");
            sqlStr.AppendLine("VALUES (@paraSurveyAnsID,@paraStudAdmin,@paraq1Ans, @paraq2Ans, @paraq3Ans, @paraq4Ans, @paraq5Ans, @paraq6Ans, @paraq7Ans)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraSurveyAnsID", surveyAnsID);
            sqlCmd.Parameters.AddWithValue("@paraStudAdmin", studentAdmin);
            sqlCmd.Parameters.AddWithValue("@paraq1Ans", q1Ans);
            sqlCmd.Parameters.AddWithValue("@paraq2Ans", q2Ans);
            sqlCmd.Parameters.AddWithValue("@paraq3Ans", q3Ans);
            sqlCmd.Parameters.AddWithValue("@paraq4Ans", q4Ans);
            sqlCmd.Parameters.AddWithValue("@paraq5Ans", q5Ans);
            sqlCmd.Parameters.AddWithValue("@paraq6Ans", q6Ans);
            sqlCmd.Parameters.AddWithValue("@paraq7Ans", q7Ans);

            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }
    }
}