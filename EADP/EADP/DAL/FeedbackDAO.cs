using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace EADP.DAL
{
    public class FeedbackDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public int insertFeedbackResponse(String studentAdmin, String tripID, int rate, String comments, String recommends)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO Feedback (StudentAdmin,TripID, Rate, Comments, Recommends)");
            sqlStr.AppendLine("VALUES (@paraStudAdmin,@paraTripID, @paraRate, @paraComments, @paraRecommends)");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraStudAdmin", studentAdmin);
            sqlCmd.Parameters.AddWithValue("@paraTripID", tripID);
            sqlCmd.Parameters.AddWithValue("@paraRate", rate);
            sqlCmd.Parameters.AddWithValue("@paraComments", comments);
            sqlCmd.Parameters.AddWithValue("@paraRecommends", recommends);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

    }
}