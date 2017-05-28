using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectDAW
{
    public partial class AboutUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["MyParam"].ToString();
                string user_id = id;
                TextBox1.Text = user_id.ToString();

                string user_image = null;
                using(SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT profile_image from UsersProfile WHERE user_id='" + @user_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    user_image = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (user_image != "")
                {
                    this.profileimage.ImageUrl = user_image;

                }



                string userFirstName = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT user_firstname from UsersProfile WHERE user_id='" + @user_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    userFirstName = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (userFirstName != "")
                {
                    this.LabelFirstName.Visible = true;
                    this.LabelFirstNameValue.Visible = true;
                    this.LabelFirstNameValue.Text = userFirstName;

                }


                string userLastName = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT user_lastname from UsersProfile WHERE user_id='" + @user_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    userLastName = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (userLastName != "")
                {
                    this.LabelLastName.Visible = true;
                    this.LabelLastNameValue.Visible = true;
                    this.LabelLastNameValue.Text = userLastName;

                }



                string userGender = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT user_gender from UsersProfile WHERE user_id='" + @user_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    userGender= Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (userGender != "")
                {
                    this.LabelGender.Visible = true;
                    this.LabelGenderValue.Visible = true;
                    this.LabelGenderValue.Text = userGender;

                }

                string userBio = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT about FROM UsersProfile WHERE user_id='" + @user_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    userBio = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (userBio != "")
                {
                    this.LabelBio.Visible = true;
                    this.LabelBioValue.Visible = true;
                    this.LabelBioValue.Text = userBio;

                }

                string userEmail = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT Email from Memberships WHERE UserId='" + @user_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    userEmail = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (userEmail != "")
                {
                    this.LabelEmail.Visible = true;
                    this.LabelEmailValue.Visible = true;
                    this.LabelEmailValue.Text = userEmail;

                }

                string userMember = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT CreateDate from Memberships WHERE UserId='" + @user_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    userMember= Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (userMember != "")
                {
                    this.LabelMember.Visible = true;
                    this.LabelMemberValue.Visible = true;
                    this.LabelMemberValue.Text = userMember;

                }

            }
        }
                  
    }
}