using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectDAW.Admin
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["MyParam"].ToString();


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True");

             con.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM UsersProfile WHERE user_id = '" + @id + "';", con))
            {
                cmd.ExecuteNonQuery();
            }
            using (SqlCommand cmd2 = new SqlCommand("DELETE FROM Memberships WHERE UserId = '" + @id + "';", con))
            {
                cmd2.ExecuteNonQuery();
            }
            using (SqlCommand cmd3 = new SqlCommand("DELETE FROM Profiles WHERE UserId = '" + @id + "';", con))
            {
                cmd3.ExecuteNonQuery();
            }
            using (SqlCommand cmd5 = new SqlCommand("DELETE FROM UsersInRoles WHERE UserId = '" + @id + "';", con))
            {
              cmd5.ExecuteNonQuery();
            }
            using (SqlCommand cmd4 = new SqlCommand("DELETE FROM Users WHERE UserId = '" + @id + "';", con))
            {
                cmd4.ExecuteNonQuery();
            }

            Response.Redirect("~/ManageUsers.aspx");

        }
    }
}