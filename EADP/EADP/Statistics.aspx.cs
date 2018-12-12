using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

namespace EADP
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudentChartInfo();
            }
        }
        private void GetStudentChartInfo()
        {
            DataTable dt = new DataTable();
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                myConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT q1Ans as Name, COUNT(StudentAdmin) AS Total  FROM SurveyAns GROUP BY q1Ans", myConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                myConn.Close();
            }
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }

            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Legends[0].Enabled = true;
        }

        protected void BtnSurvey_Click(object sender, EventArgs e)
        {
            Response.Redirect("Survey.aspx");
        }
    }
}