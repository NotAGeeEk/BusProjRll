using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace BusBookingProject.Admin
{
    public partial class DeleteSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialization and any other tasks on page load
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineBusBookingConnectionString"].ConnectionString;

            if (int.TryParse(TextBox1.Text, out int busId))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // First, execute the stored procedure to delete bus details
                        using (SqlCommand deleteCommand = new SqlCommand("uspDeleteBusDetailsByBusID", connection))
                        {
                            deleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
                            deleteCommand.Parameters.AddWithValue("@BusID", busId);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();
                            Response.Redirect("BusDetailsReport.aspx");
                        }

                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that might occur during the database operation
                        LblMsg.Text = "An error occurred: " + ex.Message;
                    }
                }
            }
            else
            {
                // Invalid input for BusID
                LblMsg.Text = "Please enter a valid BusID.";
            }
        }
    }
}