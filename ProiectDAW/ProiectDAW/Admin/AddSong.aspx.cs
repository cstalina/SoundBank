using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProiectDAW
{
    public partial class AddSong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     
      /*  protected void UploadButton(object sender, EventArgs e)
        {
              
              try {
                    string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Songs/") + fileName);
                    string Url = "~/Songs/" + fileName;

                    string Title = TextBoxTitle.Text;
                    string Artist = TextBoxArtist.Text;
             

                    string query = "INSERT INTO tracks (track_name, track_artist, track_url)"
                        + " VALUES (@track_name, @track_artist, @track_url)";

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True");

                    con.Open();

                    try
                    {
                        SqlCommand com = new SqlCommand(query, con);
                       
                        com.Parameters.AddWithValue("track_name", Title);
                        com.Parameters.AddWithValue("track_artist", Artist);
                        com.Parameters.AddWithValue("track_url", Url);

                        com.ExecuteNonQuery();

                        // Do this only if insert works:
                        LAnswer.Text = "New song added successfully!";

                      
                        TextBoxTitle.Text = "";
                        TextBoxArtist.Text = "";
                     //   FileUpload1.PostedFile.FileName = "";
                    }
                    catch (Exception ex)
                    {
                        LAnswer.Text = "Database insert error : " + ex.Message;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                catch (SqlException se)
                {
                    LAnswer.Text = "Database connexion error : " + se.Message;
                }
                catch (Exception ex)
                {
                    LAnswer.Text = "Data conversion error : " + ex.Message;
                }
            
        }
       * */
        protected void UploadButton(object sender, EventArgs e)
        {   
            string Title = TextBoxTitle.Text;
            string Artist = TextBoxArtist.Text;
            string Genre = TextBoxGenre.Text;
            string filetxt = "myfile.txt";
            Double[] data;
            byte[] sR = new byte[4];
                using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);
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
                            cmd.CommandText = "insert into tblFiles(Name, Title, Artist,Genre, ContentType, Data, DoubleV) values (@Name,@Title, @Artist,@Genre,@ContentType, @Data, @DoubleV)";

                            cmd.Parameters.AddWithValue("@Name", Path.GetFileName(FileUpload1.PostedFile.FileName));
                            cmd.Parameters.AddWithValue("@Title", Title);
                            cmd.Parameters.AddWithValue("@Artist", Artist);
                            cmd.Parameters.AddWithValue("@Genre", Genre);
                            cmd.Parameters.AddWithValue("@ContentType", "mp3");
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            cmd.Parameters.AddWithValue("@DoubleV", filetxt);
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                Response.Redirect(Request.Url.AbsoluteUri);

                TextBoxTitle.Text = "";
                TextBoxArtist.Text = "";
                TextBoxGenre.Text = "";
            }
           
    }
}