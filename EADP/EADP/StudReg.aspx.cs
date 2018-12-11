﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP.DAL;


namespace EADP
{
    public partial class StudReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "<h1>Program Registration</h1>";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string adminNO = tbAdmin.Text.ToString();
            string tripID = "Korea2018";
            string nationality = tbNationality.Text.ToString();
            string mobileNO = tbMobileNo.Text.ToString();
            string passportNO = tbPassport.Text.ToString();
            DateTime passportE = Convert.ToDateTime(tbPassportE.Text);
            string dietConstraint = tbDiet.Text.ToString();
            string medHist = tbMedical.Text.ToString();
            string remarks = tbRemarks.Text.ToString();
            string fas = "FASOP";

            StudReg studObj = new StudReg();
            StudRegDAO studDAO = new StudRegDAO();
            studDAO.InsertStudReg(adminNO, tripID, nationality, mobileNO, passportNO, passportE, dietConstraint, medHist,fas ,remarks);

        }
    }
}