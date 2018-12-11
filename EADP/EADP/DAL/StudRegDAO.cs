using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace EADP.DAL
{
    public class StudRegDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public int InsertStudReg(String studentAdmin, string tripID, string nationality, string MobileNO, string PassportNO, DateTime PassportExpiry, string DietConstraint, string MedicalHistory, string FASscheme, string Remarks)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO RegisteredStudent (StudentAdmin, TripID, Nationality, MobileNO, ");
            sqlStr.AppendLine("PassportNO,PassportExpiry,DietConstraint,MedicalHistory,FASscheme,Remarks)");
            sqlStr.AppendLine("VALUES (@paraStudAdmin,@paraTripID, @paraNationality, @paraMobileNO,");
            sqlStr.AppendLine("@paraPassportNO,@paraPassportExpiry,@paraDiet,@paraMedHist,@paraFAS,@paraRemarks)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraStudAdmin", studentAdmin);
            sqlCmd.Parameters.AddWithValue("@paraTripID", tripID);
            sqlCmd.Parameters.AddWithValue("@paraNationality", nationality);
            sqlCmd.Parameters.AddWithValue("@paraMobileNO", MobileNO);
            sqlCmd.Parameters.AddWithValue("@paraPassportNO", PassportNO);
            sqlCmd.Parameters.AddWithValue("@paraPassportExpiry", PassportExpiry);
            sqlCmd.Parameters.AddWithValue("@paraDiet", DietConstraint);
            sqlCmd.Parameters.AddWithValue("@paraMedHist", MedicalHistory);   
            sqlCmd.Parameters.AddWithValue("@paraFAS", FASscheme);
            sqlCmd.Parameters.AddWithValue("@paraRemarks", Remarks);

            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }
    }
}
