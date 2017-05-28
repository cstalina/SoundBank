using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectDAW
{
    public partial class GenrePreferences : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Overview.NavigateUrl = "~/UserProfile.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;
            Favorites.NavigateUrl = "~/MyFavorites.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;
            Genre.NavigateUrl = "~/GenrePreferences.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;
            AddGenres.NavigateUrl = "~/AddGenre.aspx?MyParam=" + (Guid)Membership.GetUser().ProviderUserKey;

            Guid user_id = new Guid(Request.QueryString["MyParam"].ToString());
            TextBox1.Text = user_id.ToString();
        }
    }
}