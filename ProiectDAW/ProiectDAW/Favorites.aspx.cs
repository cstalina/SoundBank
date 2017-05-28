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
    public partial class Favorites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                Guid User = (Guid)Membership.GetUser().ProviderUserKey;
                string profile_id = Request.QueryString["MyParam"].ToString();
                TextBoxProfile.Text = profile_id;
                TextBoxUser.Text = User.ToString();
                FavoritesMe.NavigateUrl = "~/Favorites.aspx?MyParam=" + profile_id;
                ProfileMe.NavigateUrl = "~/Profile.aspx?MyParam=" + profile_id;
                AboutUser1.NavigateUrl = "~/AboutUser.aspx?MyParam=" + profile_id;

                profile_picture.ImageUrl = "~/logo2.png";
                string pic_link = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT profile_image from UsersProfile WHERE user_id='" + @profile_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    pic_link = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (pic_link != "")
                    this.profile_picture.ImageUrl = pic_link;
                string firstname = null;
            using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT user_firstname from UsersProfile WHERE user_id='" + @profile_id + "'", dataConnection))
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
                using (SqlCommand dataCommand = new SqlCommand("SELECT user_lastname from UsersProfile WHERE user_id='" + @profile_id + "'", dataConnection))
                {
                    dataConnection.Open();
                    lastname = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (lastname != "")
                {
                    lb_lastname.Text = lastname;
                    lb_lastname.Visible = true;

                }



                /* FOLLOW UNFOLLOW button value*/
                string FollowUnfollow = null;
                try
                {
                    using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                    using (SqlCommand dataCommand = new SqlCommand("SELECT id from Follow WHERE id_follower='" + @TextBoxUser.Text + "' AND  id_followed = '" + @TextBoxProfile.Text + "'", dataConnection))
                    {
                        dataConnection.Open();
                        FollowUnfollow = Convert.ToString(dataCommand.ExecuteScalar());
                        if (FollowUnfollow != "")
                        {
                            ButtonF.Visible = false;
                            ButtonU.Visible = true;

                        }
                        else
                        {
                            ButtonU.Visible = false;
                            ButtonF.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
      

        protected void Follow(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO Follow (id_follower, id_followed)values (@Follower,@Followed)";

                    cmd.Parameters.AddWithValue("@Follower", TextBoxUser.Text);
                    cmd.Parameters.AddWithValue("@Followed", TextBoxProfile.Text);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ButtonU.Visible = true;
                    ButtonF.Visible = false;
                }
            }

        }
        protected void Unfollow(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE FROM Follow WHERE id_follower='" + @TextBoxUser.Text + "' AND  id_followed = '" + @TextBoxProfile.Text + "'";
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ButtonF.Visible = true;
                    ButtonU.Visible = false;
                }


            }


        }
        protected void GridView22_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView22.Rows[index];
                string id = row.Cells[0].Text;
                Response.Redirect("~/SongDetails.aspx?MyParam=" + id);
            }
            if ((e.CommandName == "AddToFavorites22") && (this.GridView22.Rows.Count > 0))
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView22.Rows[rowIndex];


                //Access Cell values.
                int track_id = int.Parse(row.Cells[0].Text);
                MembershipUser currentUser = Membership.GetUser();

                Guid user_id = (Guid)currentUser.ProviderUserKey;
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "IF NOT EXISTS ( SELECT *  FROM Favorites WHERE track_id = @track_id  AND user_id = @user_id) INSERT INTO Favorites (track_id, user_id) VALUES (@track_id, @user_id ) ";
                        cmd.Parameters.AddWithValue("@track_id", track_id);
                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Connection = con;
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        con.Close();
                        if (a < 0)
                        //     Response.Write(@"<script language='javascript'>$(function() {$( '#dialog' ).dialog();}); setTimeOut(function() {$( '#dialog' ).dialog( 'Already in Favorites' )}, 2000);</script>");
                        //ClientScript.RegisterStartupScript(@"<script language='javascript'>alert('Already in Favorites');</script>");
                        //   ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Already in Favorites');", true);
                        {
                            div1.Visible = true;
                            div2.Visible = false; 
                        }

                        else
                        //    Response.Write(@"<script language='javascript'>$(function() {$( '#dialog' ).dialog();}); setTimeOut(function() {$( '#dialog' ).dialog( 'Added in Favorites' )}, 2000);</script>");
                        //Response.Write(@"<script language='javascript'>alert('Added in Favorites');</script>");
                        // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added in Favorites');", true);
                        {
                            div2.Visible = true;
                            div1.Visible = false;
                        }
                    }

                }

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT genre FROM tblFiles WHERE id = @track_id ";
                        cmd.Parameters.AddWithValue("@track_id", track_id);
                        cmd.Connection = con;
                        con.Open();
                        string genree = cmd.ExecuteScalar().ToString();
                        con.Close();
                        TextBox2.Text = genree;

                    }
                    string genree_text = TextBox2.Text;
                    using (SqlCommand cmd2 = new SqlCommand())
                    {
                        cmd2.CommandText = "IF NOT EXISTS ( SELECT *  FROM GenreSuggest WHERE genre = @genre AND user_id = @user_id  ) INSERT INTO GenreSuggest (genre, user_id) VALUES (@genre, @user_id ) ";
                        cmd2.Parameters.AddWithValue("@genre", genree_text);
                        cmd2.Parameters.AddWithValue("@user_id", user_id);
                        cmd2.Connection = con;
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();

                    }
                }
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