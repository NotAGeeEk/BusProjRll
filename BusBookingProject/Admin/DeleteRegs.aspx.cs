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
    public partial class DeleteRegs : System.Web.UI.Page
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
                string BUS = TextBox1.Text;
                string query = "DELETE FROM Registration WHERE regId = @PNRNo";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PNRNo", BUS);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {

                    Response.Write("City deleted successfully.");
                    LblMsg.Text = "Update successful.";
                }
                else
                {

                    Response.Write("City not found or not deleted.");
                    LblMsg.Text = "Not Update ";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}