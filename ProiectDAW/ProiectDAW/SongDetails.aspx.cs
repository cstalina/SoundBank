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
    public partial class SongDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string song = Request.QueryString["MyParam"].ToString();
                int song_id = int.Parse(song);
                id.Text = song_id.ToString();
                Guid user = (Guid)Membership.GetUser().ProviderUserKey;
                string user_id = user.ToString();

                string song_image = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT song_image from tblFiles WHERE id='" + @song_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    song_image = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (song_image != "")
                {
                    this.songimage.ImageUrl = song_image;

                }
                string artist = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT Artist from tblFiles WHERE id='" + @song_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    artist = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (artist != "")
                {
                    this.LabelArtist.Text = artist;
                    this.LabelArtist.Visible = true;
                    this.Label2.Visible = true;
                }

                string title = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT Title from tblFiles WHERE id='" + @song_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    title = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (title != "")
                {
                    this.LabelTitle.Text = title;
                    this.LabelTitle.Visible = true;
                    this.Label1.Visible = true;

                }

                string uploaderF = null;
                string uploader = null;

                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT user_id from tblFiles WHERE  id='" + @song_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    uploaderF = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (uploaderF != "")
                {
                    using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                    using (SqlCommand dataCommand = new SqlCommand("SELECT UserName from Users WHERE  UserId='" + @uploaderF + "'", dataConnection))
                    {

                        dataConnection.Open();
                        uploader = Convert.ToString(dataCommand.ExecuteScalar());
                    }
                    if (uploader != "")
                    {
                        this.LabelUploader.Text = uploader;
                        this.LabelUploader.Visible = true;
                        this.Label3.Visible = true;

                        if (uploaderF.ToUpper() == user_id.ToUpper() )
                        LabelUploader.NavigateUrl = "~/MyProfile.aspx?MyParam=" + uploaderF;
                        if (uploaderF.ToUpper() != user_id.ToUpper() )
                        LabelUploader.NavigateUrl = "~/Profile.aspx?MyParam=" + uploaderF;

                    }

                   
                }





                string uploaded = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT UploadDate from tblFiles WHERE id='" + @song_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    uploaded = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (uploaded != "")
                {
                    this.LabelUploadedOn.Text = uploaded;
                    this.LabelUploadedOn.Visible = true;
                    this.Label8.Visible = true;

                }

                string genre = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT Genre from tblFiles WHERE id='" + @song_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    genre = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (genre != "")
                {
                    this.LabelGenre.Text = genre;
                    this.LabelGenre.Visible = true;
                    this.Label4.Visible = true;

                }

                string lyrics = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT Lyrics from tblFiles WHERE id='" + @song_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    lyrics = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (genre != "")
                {
                    this.LabelLyrics.Text = lyrics;
                    this.LabelLyrics.Visible = true;
                    this.Label5.Visible = true;

                }



                string nrpeople = null;
                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT count(user_id) from Favorites WHERE track_id='" + @song_id + "'", dataConnection))
                {

                    dataConnection.Open();
                    nrpeople = Convert.ToString(dataCommand.ExecuteScalar());
                }
                if (nrpeople != null)
                {
                    this.Label6.Visible = true;
                    this.LabelHearted.Text = nrpeople;
                    this.LabelHearted.Visible = true;
                    this.LabelPeople.Visible = true;

                }
            }
        }
        protected void EditDetails(object sender, EventArgs e)
            {
               string song = Request.QueryString["MyParam"].ToString();
               int song_id = int.Parse(song);
               Response.Redirect("~/EditSongDetails.aspx?MyParam=" + song_id);
            }
        protected void GridView123_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if ((e.CommandName == "Details") && (this.GridView123.Rows.Count > 0))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView123.Rows[index];
                string id = row.Cells[0].Text;
                Response.Redirect("~/SongDetails.aspx?MyParam=" + id);
            }

            if ((e.CommandName == "AddToFavorites123") && (this.GridView123.Rows.Count > 0))
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView123.Rows[rowIndex];


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
    }
}