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
    public partial class EditSongDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                string song = Request.QueryString["MyParam"].ToString();
                int song_id = int.Parse(song);
                TextBox1.Text = song_id.ToString();
                string picture;

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True");
                    con.Open();
                SqlCommand query = new SqlCommand("SELECT Title , Artist, Genre, Lyrics, song_image FROM tblFiles WHERE id='" + song_id + "'", con);

                SqlDataReader myReader = query.ExecuteReader();

                while (myReader.Read())
                {
                    TextBoxTitle1.Text = (myReader["Title"].ToString());
                    TextBoxArtist1.Text = (myReader["Artist"].ToString());
                    TextBoxGenre1.Text = (myReader["Genre"].ToString());
                    TextBoxLyrics.Text = (myReader["Lyrics"].ToString());
                    TextBoxLyrics.Text = TextBoxLyrics.Text.Replace("<br>",System.Environment.NewLine);

                    picture = (myReader["song_image"].ToString());
                    if (picture != "")
                        this.song_picture.ImageUrl = picture;

                 }
                con.Close();

            }

        }

        protected void Save(object sender, EventArgs e)
        {
            var currentUser = Membership.GetUser(User.Identity.Name);
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
            string song = Request.QueryString["MyParam"].ToString();
            int song_id = int.Parse(song);
            TextBox1.Text = song_id.ToString();

            string title = TextBoxTitle1.Text;
            string artist = TextBoxArtist1.Text;
            string genre = TextBoxGenre1.Text;
            string lyrics = TextBoxLyrics.Text;
            lyrics = lyrics.Replace(System.Environment.NewLine, "<br>");
            string pic = song_picture.ImageUrl;


            string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            if (fileName != "")
            {
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                pic = "~/Images/" + fileName;

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))

                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE tblFiles SET song_image = @song_image WHERE id='" + @song_id + "'";
                        cmd.Parameters.AddWithValue("@song_image", pic);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
       
            if (artist == "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE tblFiles SET Artist = @Artist WHERE id='" + @song_id + "'";
                        cmd.Parameters.AddWithValue("@Artist", artist);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

            if (artist != "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE tblFiles SET Artist = @Artist WHERE id='" + @song_id + "'";
                        cmd.Parameters.AddWithValue("@Artist", artist);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            if (title != "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))

                { 
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE tblFiles SET Title = @Title WHERE id='" + @song_id + "'";
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            if (title == "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE tblFiles SET Title = @Title WHERE id='" + @song_id + "'";
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }

            if (genre != "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE tblFiles SET Genre = @genre WHERE id='" + @song_id + "'";
                        cmd.Parameters.AddWithValue("@Genre", genre);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            if (genre == "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE tblFiles SET Genre = @genre WHERE id='" + @song_id + "'";
                        cmd.Parameters.AddWithValue("@Genre", genre);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            if (lyrics!= "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE tblFiles SET Lyrics = @Lyrics WHERE id='" + @song_id + "'";
                        cmd.Parameters.AddWithValue("@Lyrics", lyrics);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            if (lyrics == "")
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPDATE tblFiles SET Lyrics = @Lyrics WHERE id='" + @song_id + "'";
                        cmd.Parameters.AddWithValue("@Lyrics", lyrics);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            Response.Redirect("~/SongDetails.aspx?MyParam=" + song_id);


        }
        protected void Cancel(object sender, EventArgs e)
        {
            string song = Request.QueryString["MyParam"].ToString();
            int song_id = int.Parse(song);
            Response.Redirect("~/SongDetails.aspx?MyParam=" + song_id);

        }
        
    }
}