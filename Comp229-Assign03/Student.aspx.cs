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
    public partial class Student : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm_enrollment;
            SqlCommand comm_course;
            SqlDataReader reader;
            // read the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["Students"].ConnectionString;

            // Initialize connection
            conn = new SqlConnection(connectionString);
            //create command
            comm_enrollment = new SqlCommand("SELECT EnrollmentID,Grade FROM Enrollments JOIN Students USING (StudentID) WHERE ([StudentID] = @StudentID)", conn);
            comm_course = new SqlCommand("SELECT Title,Credits FROM Enrollments JOIN Courses USING (CourseID)", conn);
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
}