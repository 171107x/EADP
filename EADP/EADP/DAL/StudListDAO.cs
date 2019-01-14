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

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select* from RegisteredStudent");
            sqlStr.AppendLine("INNER JOIN Student");
            sqlStr.AppendLine("ON RegisteredStudent.StudentAdmin = Student.StudentAdmin");
            sqlStr.AppendLine("where TripID = @paraCustId;");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            da.SelectCommand.Parameters.AddWithValue("paraCustId", tripID);


            da.Fill(ds, "TableTD");


            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableTD"].Rows)
                {
                    StudList myTD = new StudList();


                    myTD.studentAdmin = row["StudentAdmin"].ToString();
                    myTD.studentName = row["StudentName"].ToString();
                    myTD.gender = row["Gender"].ToString();
                    myTD.school = row["School"].ToString();
                    myTD.pemGroup = row["PEMGroup"].ToString();
                    myTD.nationality = row["Nationality"].ToString();
                    myTD.passportNo = row["PassportNO"].ToString();
                    myTD.passportE = Convert.ToDateTime(row["PassportExpiry"]);
                    myTD.DietConstraint = row["DietConstraint"].ToString();
                    myTD.MedicalHistory = row["MedicalHistory"].ToString();
                    myTD.FASscheme = row["FASscheme"].ToString();
                    myTD.Remarks = row["Remarks"].ToString();


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

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select RegisteredStudent.StudentAdmin, Student.StudentName,Student.Gender,Student.School,Student.PEMGroup,Student.Nationality,RegisteredStudent.PassportNO,RegisteredStudent.PassportExpiry,Student.DietConstraint,Student.MedicalHistory,RegisteredStudent.FASscheme,RegisteredStudent.Remarks from Student");
            sqlStr.AppendLine("Inner Join RegisteredStudent");
            sqlStr.AppendLine("on Student.StudentAdmin = RegisteredStudent.StudentAdmin");
            sqlStr.AppendLine("AND RegisteredStudent.StudentAdmin = @paraCustId;");



            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);



            da.SelectCommand.Parameters.AddWithValue("paraCustId", StudAdmin);


            da.Fill(ds, "TableTD");



            int rec_cnt = ds.Tables["TableTD"].Rows.Count;

            StudList myTD = new StudList();
            if (rec_cnt > 0)
            {


                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.studentAdmin = row["StudentAdmin"].ToString();
                myTD.studentName = row["StudentName"].ToString();
                myTD.gender = row["Gender"].ToString();
                myTD.school = row["School"].ToString();
                myTD.pemGroup = row["PEMGroup"].ToString();
                myTD.nationality = row["Nationality"].ToString();
                myTD.passportNo = row["PassportNO"].ToString();
                myTD.passportE = Convert.ToDateTime(row["PassportExpiry"]);
                myTD.DietConstraint = row["DietConstraint"].ToString();
                myTD.MedicalHistory = row["MedicalHistory"].ToString();
                myTD.FASscheme = row["FASscheme"].ToString();
                myTD.Remarks = row["Remarks"].ToString();




            }
            else
            {
                myTD = null;
            }

            return myTD;
        }
        public StudList getRegbyStudAdmin(string Email)
        {
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select * from Student");
            sqlStr.AppendLine("Where Email = @paraCustId;");



            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);



            da.SelectCommand.Parameters.AddWithValue("paraCustId", Email);


            da.Fill(ds, "TableTD");



            int rec_cnt = ds.Tables["TableTD"].Rows.Count;

            StudList myTD = new StudList();
            if (rec_cnt > 0)
            {



                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.studentAdmin = row["StudentAdmin"].ToString();
                myTD.studentName = row["StudentName"].ToString();
                myTD.gender = row["Gender"].ToString();
                myTD.school = row["School"].ToString();
                myTD.DOB = Convert.ToDateTime(row["DOB"].ToString());
                myTD.pemGroup = row["PEMGroup"].ToString();


            }
            else
            {
                myTD = null;
            }

            return myTD;
        }
        public StudList getSearchbyStudAdmin(string Email)
        {
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("select * from Student");
            sqlStr.AppendLine("Where StudentAdmin = @paraCustId;");



            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);



            da.SelectCommand.Parameters.AddWithValue("paraCustId", Email);


            da.Fill(ds, "TableTD");



            int rec_cnt = ds.Tables["TableTD"].Rows.Count;

            StudList myTD = new StudList();
            if (rec_cnt > 0)
            {



                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.studentAdmin = row["StudentAdmin"].ToString();
                myTD.studentName = row["StudentName"].ToString();
                myTD.gender = row["Gender"].ToString();
                myTD.school = row["School"].ToString();
                myTD.DOB = Convert.ToDateTime(row["DOB"].ToString());
                myTD.pemGroup = row["PEMGroup"].ToString();


            }
            else
            {
                myTD = null;
            }

            return myTD;
        }

    }
}