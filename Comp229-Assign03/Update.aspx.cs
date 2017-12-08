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

        }

        protected void Update_button_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string connectionString = ConfigurationManager.ConnectionStrings["Students"].ConnectionString;

            // Initialize connection
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("Select FirstMidName,LastName,EnrollmentDate WHERE StudentID = @StudentID", conn);
            comm.Parameters.Add("@FirstMidName", System.Data.SqlDbType.VarChar);
            //comm.Parameters ["@StudentID"].Value =  phan custid
            try
            {
                conn.Open();
                reader = comm.ExecuteReader();
                if(reader.Read())
                {
                    update_FirstMidName.Text = reader["FirstMidName"].ToString();
                    update_LastName.Text = reader["LastName"].ToString();
                    Update_date.Text = reader["EnrollmentDate"].ToString();

                }
                reader.Close();
                Update_button.Enabled = true;
            }
                finally
            {
                conn.Close();
            }
        }
    }
}