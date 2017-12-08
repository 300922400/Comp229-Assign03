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

        protected void StudentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRowIndex;
            selectedRowIndex = StudentList.SelectedIndex;
            int StudentID = (int)StudentList.DataKeys[selectedRowIndex].Value;
            SqlConnection conn;
            SqlCommand comm_removal;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings[
            "Students"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm_removal = new SqlCommand("Delete FROM Enrollments " +
             "WHERE StudentID=@StudentID", conn);
            comm_removal.Parameters.Add("StudentID", System.Data.SqlDbType.Int);
            comm_removal.Parameters["StudentID"].Value = StudentID;
            try
            {
                conn.Open();
                reader = comm_removal.ExecuteReader();
                comm_removal.ExecuteNonQuery();
               // StudentList.DataSource = reader;
                //populated with an array of keys coz this is GridView
                //StudentList.DataKeyNames = new string[] { "StudentID" };
                //StudentList.DataBind();
            }

            finally
            {
                conn.Close();
            }
        }

        protected void AddStudentToCourse_Click(object sender, EventArgs e)
        {
            int StudentID = Convert.ToInt32(AddStudent_Course.ToString());
            int courseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            SqlConnection conn;
            SqlCommand comm_addStudent;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings[
            "Students"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm_addStudent = new SqlCommand("Insert into Enrollments (StudentID,CourseID) values " +
             "(@StudentID,@CourseID)", conn);
            comm_addStudent.Parameters.Add("StudentID", System.Data.SqlDbType.Int);
            comm_addStudent.Parameters["StudentID"].Value = StudentID;
            comm_addStudent.Parameters.Add("CourseID", System.Data.SqlDbType.Int);
            comm_addStudent.Parameters["CourseID"].Value = courseID;
            try
            {
                conn.Open();
                reader = comm_addStudent.ExecuteReader();
                comm_addStudent.ExecuteNonQuery();
                
            }

            finally
            {
                conn.Close();
            }
        }
    }
}