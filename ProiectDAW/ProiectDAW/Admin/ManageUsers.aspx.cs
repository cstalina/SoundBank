using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProiectDAW.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
       
             protected void Page_Load(object sender, EventArgs e)
    {
        //Populating a DataTable from database.
        DataTable dt = this.GetData();

        //Building an HTML string.
        StringBuilder html = new StringBuilder();

        //Table start.
        html.Append("<table border = '5'>");
        html.Append("<table cellpadding = '5'>");


        //Building the Header row.
        html.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
                
             }
        html.Append("</tr>");

        //Building the Data rows.
        foreach (DataRow row in dt.Rows)
        {
            string s = row["UserId"].ToString();
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
                
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                    html.Append("<td>");
                    string delete = "<a href=\"DeleteUser.aspx?MyParam=" + s + "\">Delete</a>";
                    html.Append(delete);
                    html.Append("</td>");
                    html.Append("</tr>");
                
        }

        //Table end.
        html.Append("</table>");

        //Append the HTML string to Placeholder.
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

    }
        
    private DataTable GetData()
    {

        using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AspnetDB.mdf;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT u.UserId, u.UserName, m.Email, u.LastActivityDate FROM Users u , Memberships m   WHERE u.UserId = m.UserId ;"))
            {
                using (SqlDataAdapter sdad = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sdad.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sdad.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
      
    
   }
       
 }
