using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Comp229_Assign03
{
    public partial class _Default : Page
    {
        // Building the connection from a string; for an example using the ConnectionStrings in web.config, go to line 29
       // private SqlConnection connection = new SqlConnection("Server=NGAN-PC\\SQLEXPRESS;Initial Catalog=Comp229Assign03;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            // Only build the list on the initial arrival, not after button presses
            /*
               if (!IsPostBack)
            {
                GetClasses();
            }
            */
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            // read the connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["Students"].ConnectionString;

             // Initialize connection
            conn = new SqlConnection(connectionString);
            //create command
            comm = new SqlCommand("Select * from Students;", conn);
            try
            {
                //open connection
                conn.Open();
                //execute the command
                reader = comm.ExecuteReader();
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

        

        protected void Input_button_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlConnection conn;
                SqlCommand comm_add;
                string connectionString = ConfigurationManager.ConnectionStrings["Students"].ConnectionString;

                // Initialize connection
                conn = new SqlConnection(connectionString);
                //create command
                comm_add = new SqlCommand("insert into Students(StudentID,LastName,FirstMidName,EnrollmentDate) values (@StudentID,@LastName,@FirstMidName,@EnrollmentDate)", conn);
                //comm_add.Parameters.AddWithValue("@StudentID", input_StudentID.Text);
                //comm_add.Parameters.AddWithValue("@LastName", input_LastName.Text);
                //comm_add.Parameters.AddWithValue("@FirstMidName", input_FirstMidName.Text);
                //comm_add.Parameters.AddWithValue("@EnrollmentDate", input_EnrollmentDate.SelectedDate);
                comm_add.Parameters.Add("@StudentID", System.Data.SqlDbType.Int);
                comm_add.Parameters["@StudentID"].Value = input_StudentID.Text;
                comm_add.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
                comm_add.Parameters["@LastName"].Value = input_LastName.Text;
                comm_add.Parameters.Add("@FirstMidName", System.Data.SqlDbType.VarChar);
                comm_add.Parameters["@FirstMidName"].Value = input_StudentID.Text;
                comm_add.Parameters.Add("@EnrollmenetDate", System.Data.SqlDbType.Date);
                comm_add.Parameters["@EnrollmentDate"].Value =null;
                try
                {
                    conn.Open();
                    comm_add.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
                
            }
           


        }

        protected void input_EnrollmentDate_SelectionChanged(object sender, EventArgs e)
        {
            Date_Enroll.Text=input_EnrollmentDate.SelectedDate.ToShortDateString();
        }

      
    }
}
      