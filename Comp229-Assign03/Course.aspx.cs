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
            SqlCommand comm_course;
            SqlDataReader reader1;
            SqlDataReader reader2;
            // read the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["Students"].ConnectionString;

            // Initialize connection
            conn = new SqlConnection(connectionString);
            //create command
            comm_students = new SqlCommand("SELECT Students.StudentID,Students.FirstMidName,Students.LastName FROM Enrollments JOIN Students on Enrollments.StudentID = Students.StudentID WHERE Enrollments.CourseID = @CourseID", conn);
            // add parameter into command
            comm_course = new SqlCommand("SELECT CourseID,Title FROM Courses WHERE CourseID = @CourseID", conn);
            comm_students.Parameters.Add("@CourseID", System.Data.SqlDbType.Int);
            comm_students.Parameters["@CourseID"].Value = courseID;
            comm_course.Parameters.Add("@CourseID", System.Data.SqlDbType.Int);
            comm_course.Parameters["@CourseID"].Value = courseID;
            try
            {
                //open connection
                conn.Open();
                //execute the command
                reader1 = comm_students.ExecuteReader();
                // bind the reader to DataList
                StudentList.DataSource = reader1;
                StudentList.DataBind();
                reader1.Close();

                reader2 = comm_course.ExecuteReader();
                CourseInfo.DataSource = reader2;
                CourseInfo.DataBind();
                //Close the reader
                reader2.Close();

            }
            finally
            {
                //close connection
                conn.Close();
            }
        }

       
        protected void AddStudentToCourse_Click(object sender, EventArgs e)
        {
            int StudentID = Convert.ToInt32((studentId.SelectedValue));
            int courseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            SqlConnection conn;
            SqlCommand comm_addStudent;
            string connectionString = ConfigurationManager.ConnectionStrings[
            "Students"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm_addStudent = new SqlCommand("Insert into Enrollments (StudentID,CourseID) values " +
             "(@StudentID,@CourseID)" , conn);
            comm_addStudent.Parameters.Add("StudentID", System.Data.SqlDbType.Int);
            comm_addStudent.Parameters["StudentID"].Value = StudentID;
            comm_addStudent.Parameters.Add("CourseID", System.Data.SqlDbType.Int);
            comm_addStudent.Parameters["CourseID"].Value = courseID;
            try
            {
                conn.Open();
                comm_addStudent.ExecuteNonQuery(); ;
                Response.Redirect("Course.aspx");
            }

            finally
            {
                conn.Close();
            }
        }

        protected void StudentList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRowIndex;
            selectedRowIndex = e.RowIndex;
            int StudentID = (int)StudentList.DataKeys[selectedRowIndex].Values["StudentID"];
            SqlConnection conn;
            SqlCommand comm_removal;
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
                comm_removal.ExecuteNonQuery();
            }

            finally
            {
                conn.Close();
            }
        }
    }
}