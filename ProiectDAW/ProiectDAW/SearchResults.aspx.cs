using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectDAW
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string search = Request.QueryString["MyParam"].ToString();
            TextBox1.Text = search;
            LabelSearch.Text = search; 
        }
        protected void GridView123_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                Guid user = (Guid)Membership.GetUser().ProviderUserKey;
                string user_id = user.ToString();
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView123.Rows[index];
                string id = row.Cells[0].Text;
                if (id.ToUpper() != user_id.ToUpper())                  
                    Response.Redirect("~/Profile.aspx?MyParam=" + id);
                else if (id.ToUpper() == user_id.ToUpper())
                    Response.Redirect("~/MyProfile.aspx?MyParam=" + id);

            }
        }
    }
}