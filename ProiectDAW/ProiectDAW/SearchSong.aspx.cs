using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProiectDAW
{
    public partial class SearchSong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Request.Params["q"] != null)
            {
                string query = Server.UrlDecode(Request.Params["q"]);

                SDSSearch.SelectCommand = "SELECT id, Name,Title, Artist, ContentType, Data FROM  tblFiles"
                    + " WHERE Title LIKE @q OR Artist LIKE @q";

                SDSSearch.SelectParameters.Clear();
                SDSSearch.SelectParameters.Add("q", query + "%");
                SDSSearch.DataBind();
            }
        }
    }
}