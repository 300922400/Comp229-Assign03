﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03
{
    public partial class Student : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
            SqlConnection conn;
            SqlCommand comm_enrollment;
            SqlDataReader reader;
            // read the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["Students"].ConnectionString;

            // Initialize connection
            conn = new SqlConnection(connectionString);
            //create command
            comm_enrollment = new SqlCommand("SELECT Enrollments.Grade, Courses.Title, Courses.Credits  FROM Enrollments JOIN Courses on Enrollments.CourseID = Courses.CourseID WHERE Enrollments.StudentID = @StudentID", conn);
            // add parameter into command
            comm_enrollment.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
            comm_enrollment.Parameters["@StudentID"].Value = StudentID;
   
            try
            {
                //open connection
                conn.Open();
                //execute the command
                reader = comm_enrollment.ExecuteReader();
                // bind the reader to DataList
                Student_Info.DataSource = reader;
                Student_Info.DataBind();
                //Close the reader
                reader.Close();


            }
            finally
            {
                //close connection
                conn.Close();
            }
        }

    }
}
