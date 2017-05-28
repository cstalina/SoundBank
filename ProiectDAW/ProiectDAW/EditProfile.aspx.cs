using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using System.Drawing;

namespace ProiectDAW
{
    public partial class EditProfile : System.Web.UI.Page
    {
        string pic_link;
        string First = "";
        string Last = "";
        string GenderB = "";
        string bio = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
                var currentUser = Membership.GetUser(User.Identity.Name);
                Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
                string edid ;

                using (SqlConnection dataConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                using (SqlCommand dataCommand = new SqlCommand("SELECT user_id from UsersProfile WHERE user_id='" + @userGuid + "'", dataConnection))
                {
                    dataConnection.Open();
                     edid = Convert.ToString(dataCommand.ExecuteScalar());
                }
             
                if (edid == "")
                 {
                    string query1 = "INSERT INTO UsersProfile (user_id)"
                           + " VALUES ( @user_id)";
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True");
                    con1.Open();
                      try
                        { 
                            SqlCommand com = new SqlCommand(query1, con1);
                            com.Parameters.AddWithValue("user_id", userGuid);
                            com.ExecuteNonQuery();
                            // Do this only if insert works:
                        }
                        catch (Exception ex)
                        {
                            LAnswer.Text = "Database insert error : " + ex.Message;
                        }
                        finally
                        {
                            con1.Close();
                        }
                    }



                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True");
                con.Open();

                SqlCommand query = new SqlCommand("SELECT user_firstname , user_lastname, user_gender, profile_image, about FROM UsersProfile WHERE user_id='" + userGuid + "'", con);

                SqlDataReader myReader = query.ExecuteReader();

                while (myReader.Read())
                {
                     First = (myReader["user_firstname"].ToString());
                     Last = (myReader["user_lastname"].ToString());
                     GenderB = (myReader["user_gender"].ToString());
                     pic_link = (myReader["profile_image"].ToString());
                     TextBoxBio.Text = (myReader["about"].ToString());
                     TextBoxBio.Text = TextBoxBio.Text.Replace("<br>", System.Environment.NewLine);

                     if (pic_link != "")
                        this.profile_picture.ImageUrl = pic_link;

                     if (GenderB == "Female")
                        Gender.SelectedIndex = 1;
                     else
                        Gender.SelectedIndex = 0;

                }
                con.Close();

                FirstName.Text = First;
                LastName.Text = Last;
                Gender.Text = GenderB;
                 

            } 
           
        }

      
        protected void SaveProfile(object sender, EventArgs e)
        {
            var currentUser = Membership.GetUser(User.Identity.Name);
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;

                      
            string Firstname = FirstName.Text;
            string Lastname = LastName.Text;
            string gender = Gender.SelectedValue;                    
            string link = pic_link;
            string bioo = TextBoxBio.Text;
            string Bio = bioo.Replace(System.Environment.NewLine, "<br>");
       

                    string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (fileName != "")
                    {
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                        link = "~/Images/" + fileName;
                                          
                     using  (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                        {


                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "UPDATE UsersProfile SET profile_image = @profile_image WHERE user_id='" + @userGuid + "'";
                                cmd.Parameters.AddWithValue("@profile_image", link);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
               
                    if (Firstname != "")
                    {
                        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "UPDATE UsersProfile SET user_firstname = @user_firstname WHERE user_id='" + @userGuid + "'";
                                cmd.Parameters.AddWithValue("@user_firstname", Firstname);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                    if (Firstname == "")
                    {
                        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "UPDATE UsersProfile SET user_firstname = @user_firstname WHERE user_id='" + @userGuid + "'";
                                cmd.Parameters.AddWithValue("@user_firstname", Firstname);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }

                    if (Lastname != "")
                    {
                        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "UPDATE UsersProfile SET user_lastname = @user_lastname WHERE user_id='" + @userGuid + "'";
                                cmd.Parameters.AddWithValue("@user_lastname", Lastname);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }

                    if (Lastname == "")
                    {
                        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "UPDATE UsersProfile SET user_lastname = @user_lastname WHERE user_id='" + @userGuid + "'";
                                cmd.Parameters.AddWithValue("@user_lastname", Lastname);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }


                    if (gender != "")
                    {
                        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "UPDATE UsersProfile SET user_gender = @user_gender WHERE user_id='" + @userGuid + "'";
                                cmd.Parameters.AddWithValue("@user_gender", gender);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }

                    if (gender == "")
                    {
                        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "UPDATE UsersProfile SET user_gender = @user_gender WHERE user_id='" + @userGuid + "'";
                                cmd.Parameters.AddWithValue("@user_gender", gender);
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }

                    }
                        if (Bio != "")
                        {


                            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                            {
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.CommandText = "UPDATE UsersProfile SET about = @about WHERE user_id='" + @userGuid + "'";
                                    cmd.Parameters.AddWithValue("@about", Bio);
                                    cmd.Connection = con;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }

                        if (Bio == "")
                        {
                            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
                            {
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.CommandText = "UPDATE UsersProfile SET about= @about WHERE user_id='" + @userGuid + "'";
                                    cmd.Parameters.AddWithValue("@about", Bio);
                                    cmd.Connection = con;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }


                        }
                    
                  
            Response.Redirect("~/MyProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey);


            }
        protected void CancelButton(object sender, EventArgs e)
        {
            Response.Redirect("~/MyProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey);

        }
        
    }
}