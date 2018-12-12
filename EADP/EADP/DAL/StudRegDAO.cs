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
            int result = 0;    
            SqlCommand sqlCmd = new SqlCommand();
            
            sqlStr.AppendLine("INSERT INTO RegisteredStudent (StudentAdmin, TripID, Nationality, MobileNO, ");
            sqlStr.AppendLine("PassportNO,PassportExpiry,DietConstraint,MedicalHistory,FASscheme,Remarks)");
            sqlStr.AppendLine("VALUES (@paraStudAdmin,@paraTripID, @paraNationality, @paraMobileNO,");
            sqlStr.AppendLine("@paraPassportNO,@paraPassportExpiry,@paraDiet,@paraMedHist,@paraFAS,@paraRemarks)");
                                   

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            
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

            

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

           
            myConn.Close();

            return result;

        }
    }
}
