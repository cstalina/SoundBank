using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectDAW
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Overview.NavigateUrl = "~/UserProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;
                Favorites.NavigateUrl = "~/MyFavorites.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;
                ProfileMe.NavigateUrl = "~/MyProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;
                NewSong.NavigateUrl = "~/AddNewSongUser.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;
                EditProfileMe.NavigateUrl = "~/EditProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;

                Guid user_id = new Guid(Request.QueryString["MyParam"].ToString());
                TextBox1.Text = user_id.ToString();

                profile_picture.ImageUrl = "~/logo2.png";
                string pic_link = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT profile_image from UsersProfile WHERE user_id='" + @user_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    pic_link = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (pic_link != "")
                    this.profile_picture.ImageUrl = pic_link;


                string firstname = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT user_firstname from UsersProfile WHERE user_id='" + @user_id + "'", dataConnection))
                {
                    dataConnection.Open();
                    firstname = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (firstname != "")
                {
                    lb_firstname.Text = firstname;
                    lb_firstname.Visible = true;

                }




                string lastname = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT user_lastname from UsersProfile WHERE user_id='" + @user_id + "'", dataConnection))
                {
                    dataConnection.Open();
                    lastname = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (lastname != "")
                {
                    lb_lastname.Text = lastname;
                    lb_lastname.Visible = true;

                }
            }
        }
        private DataTable GetData()
        {
            throw new NotImplementedException();
        }
      /*  public void ChangePP(object sender, EventArgs e)
        {
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (.jpg)|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            bool? userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK == true)
            {
                // Open the selected file to read.
                System.IO.Stream fileStream = openFileDialog1.File.OpenRead();

                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    // Read the first line from the file and write it the textbox.
                    tbResults.Text = reader.ReadLine();


                    string query = "INSERT INTO UsersProfile(profile_image) " +
                          "Values( '" + link + "')";
                    string query2 = "UPDATE UsersProfile SET  profile_image = @profile_image WHERE user_id = @userGuid ";

                }
                fileStream.Close();
            }
        }*/
        protected void GridView22_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          if (e.CommandName == "Details")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView22.Rows[index];
                string id = row.Cells[1].Text;
                Response.Redirect("~/SongDetails.aspx?MyParam=" + id);
            }

          if (e.CommandName == "EditDetails")
          {
              int index = Convert.ToInt32(e.CommandArgument);
              GridViewRow row = GridView22.Rows[index];
              string id = row.Cells[1].Text;
              Response.Redirect("~/EditSongDetails.aspx?MyParam=" + id);
          }
        }

        protected void GridView1001_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowProfile")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1001.Rows[index];
                string id = row.Cells[0].Text;
                Response.Redirect("~/Profile.aspx?MyParam=" + id);
            }
        }

    }
}