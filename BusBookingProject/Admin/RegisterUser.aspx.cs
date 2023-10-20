using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusBookingProject.Admin
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            string connectionString = "Server=DESKTOP-TSI347T;Database=OnlineBusBooking;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Registration", con))
                {
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridViewUsers.DataSource = dt;
                        GridViewUsers.DataBind();
                    }
                }
            }
        }

        protected void GridViewUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewUsers.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridViewUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewUsers.EditIndex = -1;
            BindGridView();
        }

        protected void GridViewUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userID = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value);
            GridViewRow row = GridViewUsers.Rows[e.RowIndex];

            string firstName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string lastName = ((TextBox)row.Cells[2].Controls[0]).Text;
            string email = ((TextBox)row.Cells[3].Controls[0]).Text;

            string connectionString = "Server=DESKTOP-TSI347T;Database=OnlineBusBooking;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Registration SET Fname = @FirstName, Lname = @LastName, EmailId = @Email WHERE regId = @UserID", con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.ExecuteNonQuery();
                }
            }

            GridViewUsers.EditIndex = -1;
            BindGridView(); // Rebind the GridView to show updated data
        }


        protected void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int regId = Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value);

            string connectionString = "Server=DESKTOP-TSI347T;Database=OnlineBusBooking;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Registration WHERE regId = @regId", con))
                {
                    cmd.Parameters.AddWithValue("@regId", regId);
                    cmd.ExecuteNonQuery();
                }
            }

            BindGridView();


        }
    }
}