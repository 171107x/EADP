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
    public class StudListDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public List<StudList> getTDbyTripID(string tripID)
        {
            List<StudList> tdList = new List<StudList>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select* from RegisteredStudent");
            sqlStr.AppendLine("INNER JOIN Student");
            sqlStr.AppendLine("ON RegisteredStudent.StudentAdmin = Student.StudentAdmin");
            sqlStr.AppendLine("where TripID = @paraCustId;");
            


            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 

            da.SelectCommand.Parameters.AddWithValue("paraCustId", tripID);

            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableTD"].Rows)
                {
                    StudList myTD = new StudList();

                    // Step 8 Set attribute of timeDeposit instance for each row of record in TableTD

                    myTD.studentAdmin = row["StudentAdmin"].ToString();
                    myTD.studentName = row["StudentName"].ToString();
                    myTD.gender = row["Gender"].ToString();
                    myTD.diploma = row["School"].ToString();
                    myTD.pemGroup = row["PEMGroup"].ToString();
                    myTD.nationality = row["Nationality"].ToString();
                    myTD.passportNo = row["PassportNO"].ToString();
                    myTD.passportE = Convert.ToDateTime(row["PassportExpiry"]);
                    myTD.DietConstraint = row["DietConstraint"].ToString();
                    myTD.MedicalHistory = row["MedicalHistory"].ToString();
                    myTD.FASscheme = row["FASscheme"].ToString();
                    myTD.Remarks = row["Remarks"].ToString();

                    //  Step 9: Add each timeDeposit instance to array list
                    tdList.Add(myTD);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }
        public StudList getTDbyStudAdmin(string StudAdmin)
        {
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select RegisteredStudent.StudentAdmin, Student.StudentName,Student.Gender,Student.School,Student.PEMGroup,RegisteredStudent.Nationality,RegisteredStudent.PassportNO,RegisteredStudent.PassportExpiry,RegisteredStudent.DietConstraint,RegisteredStudent.MedicalHistory,RegisteredStudent.FASscheme,RegisteredStudent.Remarks from Student");
            sqlStr.AppendLine("Inner Join RegisteredStudent");
            sqlStr.AppendLine("on Student.StudentAdmin = RegisteredStudent.StudentAdmin");
            sqlStr.AppendLine("AND RegisteredStudent.StudentAdmin = @paraCustId;");         
            
            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 

            da.SelectCommand.Parameters.AddWithValue("paraCustId", StudAdmin);

            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;

            StudList myTD = new StudList();
            if (rec_cnt > 0)
            {
                

                // Step 8 Set attribute of timeDeposit instance for each row of record in TableTD
                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.studentAdmin = row["StudentAdmin"].ToString();
                myTD.studentName = row["StudentName"].ToString();
                myTD.gender = row["Gender"].ToString();
                myTD.diploma = row["School"].ToString();
                myTD.pemGroup = row["PEMGroup"].ToString();
                myTD.nationality = row["Nationality"].ToString();
                myTD.passportNo = row["PassportNO"].ToString();
                myTD.passportE = Convert.ToDateTime(row["PassportExpiry"]);
                myTD.DietConstraint = row["DietConstraint"].ToString();
                myTD.MedicalHistory = row["MedicalHistory"].ToString();
                myTD.FASscheme = row["FASscheme"].ToString();
                myTD.Remarks = row["Remarks"].ToString();

                    //  Step 9: Add each timeDeposit instance to array list
                  
                
            }
            else
            {
                myTD = null;
            }

            return myTD;
        }
    }
}