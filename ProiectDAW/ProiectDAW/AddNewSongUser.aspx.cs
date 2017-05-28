using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectDAW
{
    public partial class AddNewSongUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Overviews.NavigateUrl = "~/UserProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;
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

        protected void UploadButton1(object sender, EventArgs e)
        {
            Guid user_id = new Guid(Request.QueryString["MyParam"].ToString());
            TextBox1.Text = user_id.ToString();

            string Title = TextBoxTitle1.Text;
            string Artist = TextBoxArtist1.Text;
            string Genre = TextBoxGenre1.Text;
            string filetxt = "myfile.txt";
            string Lyrics = TextBoxLyrics.Text;
            Lyrics = Lyrics.Replace(System.Environment.NewLine, "<br>");
            Double[] data;
            byte[] sR = new byte[4];
            string link2 = "/Images/logo2.png";

            string[] lst = Lyrics.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
           
              string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
              if (fileName != "")
              {
                  FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                  link2 = "/Images/" + fileName;
              }

            if (FileUpload2.FileName.EndsWith(".mp3"))
            {

                using (BinaryReader br = new BinaryReader(FileUpload2.PostedFile.InputStream))
                {
                    byte[] bytes = br.ReadBytes((int)FileUpload2.PostedFile.InputStream.Length);
                    data = new Double[(bytes.Length - 44) / 4];//shifting the headers out of the PCM data;
                    /***********Converting and PCM accounting***************/
                    for (int i = 0; i < data.Length - i * 4; i++)
                    {
                        data[i] = (BitConverter.ToInt32(bytes, (1 + i) * 4)) / 65536.0;
                        //65536.0.0=2^n,       n=bits per sample;
                    }
                    /**************assigning sample rate**********************/
                    for (int i = 24; i < 28; i++)
                    {
                        sR[i - 24] = bytes[i];
                    }
                    File.WriteAllLines(@"C:\Users\Alina\Documents\Visual Studio 2012\Projects\ProiectDAW\ProiectDAW\DoubleArrays\myfile.txt", data.Select(d => d.ToString()).ToArray());
                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
                    {

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "insert into tblFiles(Name, user_id, Title, Artist,Genre, ContentType, Data, DoubleV, Lyrics,UploadDate,song_image ) values (@Name,@User_id,@Title, @Artist,@Genre,@ContentType, @Data, @DoubleV,@Lyrics,@UploadDate,@song_image)";

                            cmd.Parameters.AddWithValue("@Name", Path.GetFileName(FileUpload2.PostedFile.FileName));
                            cmd.Parameters.AddWithValue("@User_id", user_id);
                            cmd.Parameters.AddWithValue("@Title", Title);
                            cmd.Parameters.AddWithValue("@Artist", Artist);
                            cmd.Parameters.AddWithValue("@Genre", Genre);
                            cmd.Parameters.AddWithValue("@ContentType", "mp3");
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            cmd.Parameters.AddWithValue("@DoubleV", filetxt);
                            cmd.Parameters.AddWithValue("@Lyrics", Lyrics);
                            cmd.Parameters.AddWithValue("@UploadDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@song_image", link2);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }


                Response.Redirect("~/MyProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey);

                TextBoxTitle1.Text = "";
                TextBoxArtist1.Text = "";
                TextBoxGenre1.Text = "";
                TextBoxLyrics.Text = "";
            }
            else
            {
                LAnswer.Text = "Currently SoundCloud only supports MP3 files. Unsupported file chosen.";
                TextBoxTitle1.Text = "";
                TextBoxArtist1.Text = "";
                TextBoxGenre1.Text = "";
                TextBoxLyrics.Text = "";
            }
        }
        protected void CancelButton(object sender, EventArgs e)
        {
            Response.Redirect("~/MyProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey);

        }
    }
}