using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Text;
using NAudio.Wave;
using System.IO;
using System.Timers;
using System.Web.Providers.Entities;
using NAudio;
using NAudio.CoreAudioApi;
using System.Threading;
using System.Web.Security;
namespace ProiectDAW
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    ProfileMe.Visible = true;
                    ProfileMe.NavigateUrl = "~/MyProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;
                }

                else
                    ProfileMe.Visible = false;
                    suggestions.Visible = false;
 
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Guid user_id = (Guid)Membership.GetUser().ProviderUserKey;
                    TextBox3.Text = user_id.ToString();
                    suggestions.Visible = true;
                 }

                if (User.IsInRole("Site Admin"))
                {
                 
                    HyperLink2.Visible = true;
                    suggestions.Visible = false;


                }
                else
                {
                    
                    HyperLink2.Visible = false;
                }

                /*
                            if (this.GridView123.Rows.Count > 0)
                            {
                                this.GridView1111.Visible = false;
                                this.GridView123.Visible = true;
                            }
                            if (this.GridView123.Rows.Count == 0)
                            {
                                this.GridView1111.Visible = true;
                                this.GridView123.Visible = false;
                            }
                           */
            }
        }

        protected void SearchSong(object sender, EventArgs e)
        {
            //BindGridView123(Request.Form["q"]);
        }

    /*    private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Id, Title, Artist from tblFiles";
                    cmd.Connection = con;
                    con.Open();
                    GridView112.DataSource = cmd.ExecuteReader();
                    GridView112.DataBind();
                    con.Close();
                }
            }
        }

        */

     /*  protected void Button2_Click(object sender, EventArgs e)
        {
         
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True");
            String str = "SELECT Title , Artist FROM tblFiles WHERE (Title LIKE  '%'+ @search + '%' OR Artist LIKE  '%'+ @search + '%') ";
            SqlCommand xp = new SqlCommand(str, con);
            xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = TextBox1.Text;

            con.Open();
            xp.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = xp;
            DataSet ds = new DataSet();
            da.Fill(ds, "track_name");
            GridView2.DataSource = ds;
            GridView2.DataBind();

            con.Close();
           
            
        }

        */
    /*    protected void DeleteSong(object sender, EventArgs e)
        {

          //  string wam = GridView1.DataKeys[e.RowIndex].Value.ToString();
          //  int id = Int32.Parse(wam);

         //   var id = GridView112.DataKeys[rowIndex].Values["id"];

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE from tblFiles WHERE id=@id";
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", id);                 
                    con.Close();
                }
            }


        }*/

        protected void Recognize(object sender, EventArgs e)
        {
            Server.Transfer("Recognize.aspx", true);

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)

        {

            if ((e.CommandName == "Details") && (this.GridView123.Rows.Count > 0) )
                
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string id = row.Cells[0].Text;
                Response.Redirect("~/SongDetails.aspx?MyParam=" + id);
            }
        
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
                            {  //     Response.Write(@"<script language='javascript'>$(function() {$( '#dialog' ).dialog();}); setTimeOut(function() {$( '#dialog' ).dialog( 'Already in Favorites' )}, 2000);</script>");
                                //ClientScript.RegisterStartupScript(@"<script language='javascript'>alert('Already in Favorites');</script>");
                                // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Already in Favorites');", true);
                                div1.Visible = true;
                                div2.Visible = false;
                            }
                            else
                            { //    Response.Write(@"<script language='javascript'>$(function() {$( '#dialog' ).dialog();}); setTimeOut(function() {$( '#dialog' ).dialog( 'Added in Favorites' )}, 2000);</script>");
                                //Response.Write(@"<script language='javascript'>alert('Added in Favorites');</script>");
                                // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added in Favorites');", true);
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
            
        /*
       
        public NAudio.Wave.WaveIn waveSource = null;
        public NAudio.Wave.WaveFileWriter waveFile = null;
        public NAudio.Wave.WaveFileWriter waveWriter = null;
       
     
        protected void RecordButtonClick(object sender, EventArgs e)
        {
            RecordButton.Enabled = false;
            StopButton.Enabled = true;
          

            waveSource =  new NAudio.Wave.WaveIn();

            waveSource.WaveFormat = new NAudio.Wave.WaveFormat(44100, 1);

            waveSource.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(waveSource_RecordingStopped);

            waveFile = new NAudio.Wave.WaveFileWriter(@"D:\Temp\Test2.wav", waveSource.WaveFormat);



            //System.Timers.Timer t = new System.Timers.Timer(15000);
            //t.Elapsed += new ElapsedEventHandler(StopButtonClick);        
            waveSource.StartRecording();       
            //t.Start(); 

        }
        protected void StopButtonClick(object sender, EventArgs e)
        {
            StopButton.Enabled = false;
            waveSource.StopRecording();

         /*   if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }
            if (waveSource != null)
            {
                waveSource.StopRecording();
                waveSource.Dispose();
                waveSource = null;
            }
            if (waveWriter != null)
            {
                waveWriter.Dispose();
                waveWriter = null;
            }*/
    /*    }

        void waveSource_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (waveWriter == null) return;
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }

        
            RecordButton.Enabled = true;
        }

        */



        // pentru recunoastere 
        // transformare in array de double 
        public static Double[] prepare(String wavePath, out int SampleRate)
        {
            Double[] data;
            byte[] wave;
            byte[] sR = new byte[4];
            System.IO.FileStream WaveFile = System.IO.File.OpenRead(wavePath);
            wave = new byte[WaveFile.Length];
            data = new Double[(wave.Length - 44) / 4];//shifting the headers out of the PCM data;
            WaveFile.Read(wave, 0, Convert.ToInt32(WaveFile.Length));//read the wave file into the wave variable
            /***********Converting and PCM accounting***************/
            for (int i = 0; i < data.Length - i * 4; i++)
            {
                data[i] = (BitConverter.ToInt32(wave, (1 + i) * 4)) / 65536.0;
                //65536.0.0=2^n,       n=bits per sample;
            }
            /**************assigning sample rate**********************/
            for (int i = 24; i < 28; i++)
            {
                sR[i - 24] = wave[i];
            }
            SampleRate = BitConverter.ToInt32(sR, 0);
            return data;
        }


       
     
    }
    

  }
   

