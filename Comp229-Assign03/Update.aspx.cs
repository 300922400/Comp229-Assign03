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
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            int StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["Students"].ConnectionString;

            // Initialize connection
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("Select Students.FirstMidName,Students.LastName,Students.EnrollmentDate from Students WHERE StudentID = @StudentID", conn);
            // pass parameter into command
            comm.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
            comm.Parameters["@StudentID"].Value = StudentID;
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    update_FirstMidName.Text = reader["FirstMidName"].ToString();
                    update_LastName.Text = reader["LastName"].ToString();
                    Update_date.Text = ((DateTime)reader["EnrollmentDate"]).ToString("yyyy-MM-dd");
                }
                reader.Close();
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Update_button_Click(object sender, EventArgs e)
        {
            int StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
            SqlConnection conn;
            SqlCommand comm;
            string connectionString =
            ConfigurationManager.ConnectionStrings[
            "Students"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand(
            "UPDATE Students SET FirstMidName=@FirstMidName, LastName=@LastName, " +
            "EnrollmentDate=@EnrollmentDate" +
            " WHERE StudentID=@StudentID", conn);
            comm.Parameters.Add("@FirstMidName",
            System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@FirstMidName"].Value = update_FirstMidName.Text;
            comm.Parameters.Add("@LastName",
            System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@LastName"].Value = update_LastName.Text;
            comm.Parameters.Add("@EnrollmentDate",
            System.Data.SqlDbType.Date);
            comm.Parameters["@EnrollmentDate"].Value = Convert.ToDateTime(Update_date.Text);
            
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
          
            finally
            {
                conn.Close();
            }
           
        }

    }
}
