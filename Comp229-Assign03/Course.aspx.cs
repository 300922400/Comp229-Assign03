using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp229_Assign03
{
    public partial class Course : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int courseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            SqlConnection conn;
            SqlCommand comm_course;
            SqlCommand comm_students;
            SqlDataReader reader;
            // read the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["Students"].ConnectionString;

            // Initialize connection
            conn = new SqlConnection(connectionString);
            //create command
            comm_students = new SqlCommand("SELECT Students.StudentID,Students.FirstMidName,Students.LastName FROM Enrollments JOIN Students on Enrollments.StudentID = Students.StudentID WHERE Enrollments.CourseID = @CourseID", conn);
            // add parameter into command
            comm_students.Parameters.Add("@CourseID", System.Data.SqlDbType.Int);
            comm_students.Parameters["@CourseID"].Value = courseID;
            try
            {
                //open connection
                conn.Open();
                //execute the command
                reader = comm_students.ExecuteReader();
                // bind the reader to DataList
                StudentList.DataSource = reader;
                StudentList.DataBind();
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