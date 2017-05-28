﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectDAW
{
    public partial class Follow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Overview.NavigateUrl = "~/UserProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;
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
}