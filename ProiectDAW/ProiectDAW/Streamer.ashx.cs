using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace ProiectDAW
{
    /// <summary>
    /// Summary description for Streamer
    /// </summary>
    public class Streamer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            int id = int.Parse(context.Request.QueryString["track_id"]);
            string artist;
            string name;
       

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Music.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select * from tracks where track_id=@track_id";
                    cmd.Parameters.AddWithValue("@track_id", id);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                  //  bytes = (byte[])sdr["track_url"];
                    name = sdr["track_name"].ToString();
                    artist = sdr["track_artist"].ToString();
                    con.Close();
                }
            }
            context.Response.Clear();
            context.Response.Buffer = true;
        //    context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
          // context.Response.track_artist = artist;
           // context.Response.BinaryWrite(bytes);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}