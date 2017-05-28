using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectDAW
{
    public partial class AddGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid user_id = new Guid(Request.QueryString["MyParam"].ToString());
            TextBox1.Text = user_id.ToString();
        }


    }
}