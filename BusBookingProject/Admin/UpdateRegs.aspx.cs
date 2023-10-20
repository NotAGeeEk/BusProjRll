using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingProject.Admin
{
    public partial class UpdateRegs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineBusBookingConnectionString"].ToString());
            try
            {
                con.Open();

                // Construct the SQL update statement
                string updateQuery = "UPDATE Registration SET Fname = @Fname, Lname = @Lname, Emailid = @Email, Contact = @Contact, CreatedDate = @createdate WHERE RegId = @RegId";

                using (SqlCommand command = new SqlCommand(updateQuery, con))
                {
                    // Add parameters for the query
                    command.Parameters.AddWithValue("@Fname", TextBox1.Text);
                    command.Parameters.AddWithValue("@Lname", TextBox2.Text);
                    command.Parameters.AddWithValue("@Email", TextBox3.Text);
                    command.Parameters.AddWithValue("@Contact", TextBox4.Text);
                    command.Parameters.AddWithValue("@createdate", TextBox5.Text);
                    command.Parameters.AddWithValue("@RegId", TextBox6.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        LblMsg.Text = "Update successful.";
                    }
                    else
                    {

                        LblMsg.Text = "No records were updated.";
                    }
                }
            }
            catch (Exception ex)
            {

                LblMsg.Text = "An error occurred: " + ex.Message;
            }
        }

    }
}