using EADP.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI.DataVisualization.Charting;

namespace EADP
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                //Session["new"] = "Statistics";
                Response.Redirect("LoginStudent.aspx");
            }
            if (!IsPostBack)
            {
                GetStudentChartInfo();
            }
            StudList studList = new StudList();
            StudListDAO studDAO = new StudListDAO();
            studList = studDAO.getRegbyStudAdmin(Session["Username"].ToString());
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                myConn.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(StudentAdmin)  FROM Feedback  WHERE StudentAdmin = @paraStudAdmin", myConn);
                cmd.Parameters.AddWithValue("@paraStudAdmin", studList.studentAdmin.ToString());
                int UserExist = (int)cmd.ExecuteScalar();
                if (UserExist < 1)
                {
                    Label1.Text = "<h3>You currently have a feedback form that is uncompleted! Complete it <a href='Feedback.aspx'>here</a></h3>";
                }
                else
                {
                    Label1.Visible = false;
                }
                myConn.Close();


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
        protected void GetWeatherInfo(object sender, EventArgs e)
        {
            string appId = "233ea45064c2ad346eb05db29cff9e64";
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?appid={1}&q={0}&units=metric&cnt=1", TxtCity.Text.Trim(), appId);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherInfo weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(json);
                lblCity_Country.Text = weatherInfo.city.name + "," + weatherInfo.city.country;
                imgCountryflag.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfo.city.country.ToLower());
                lblDescription.Text = weatherInfo.list[0].weather[0].description;
                imgWeathericon.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfo.list[0].weather[0].icon);
                lblTempMin.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].main.temp_min, 1));
                lblTempMax.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].main.temp_max, 1));
                lblTemperature.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].main.temp, 1));
                lblHumidity.Text = weatherInfo.list[0].main.humidity.ToString();
                tblWeather.Visible = true;

            }
            if (IsPostBack)
            {
                GetStudentChartInfo();
            }
        }
        public class WeatherInfo
        {
            public City city { get; set; }
            public List<List> list { get; set; }

        }

        public class City
        {
            public string name { get; set; }
            public string country { get; set; }

        }

        public class Main
        {
            public double temp { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int humidity { get; set; }
        }

        public class Weather
        {
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class List
        {
            public Main main { get; set; }
            public int humidity { get; set; }
            public List<Weather> weather { get; set; }
        }

        protected void BtnSurvey_Click(object sender, EventArgs e)
        {
            Response.Redirect("Survey.aspx");
        }


    }
}