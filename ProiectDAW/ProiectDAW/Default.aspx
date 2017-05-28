
<%@ Page Title="SoundBank - Hear the world’s sounds" MaintainScrollPositionOnPostBack="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProiectDAW._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <script>
        $("id=some-div").hover(
        function () {
            $(this).append($("Add to Favorites"));
        });
      
</script>
   
  <style type="text/css">
       .alert {
            width: 100%;
            position: fixed;
            top:0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }
    </style>
  
   <header style="background:black; height:10px; width:1000px; margin-left:0px; "/>

    <section class="featured">
        <div class="content-wrapper">
                <div class="float-left">
                <h1 class="site-title">
                    
                    <a id="A1" runat="server" href="~/"><asp:Image ID="Image1" runat="server" ImageURL="~\Images\logo2.png" width="50px"/>&nbsp; SoundBank</a>
                </h1>
            </div>
            <div class="float-right">
                 <section id="login">
                    <asp:LoginView ID="LoginView1" runat="server" ViewStateMode="Disabled">
                        <AnonymousTemplate>
                            <ul>
                                <li><a id="registerLink" runat="server" href="~/Account/Register.aspx">Register</a></li>
                                <li><a id="loginLink" runat="server" href="~/Account/Login.aspx">Log in</a></li>
                            </ul>
                        </AnonymousTemplate>
                        <LoggedInTemplate>

                            <p>
                                Hello, <a id="A2" runat="server" class="username" href="~/Account/Manage.aspx" title="Manage your account">
                                    <asp:LoginName ID="LoginName1" runat="server" CssClass="username" /></a>!
                                <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" />
      
                                 </p>

                        </LoggedInTemplate>
                    </asp:LoginView>
                  
                </section>
             
                <nav >
                    <ul id="menu">
                        <li><a id="A3" runat="server" href="~/">Home</a></li>
                        <li><a id="A4" runat="server" href="~/About.aspx">About</a></li>
                        <li><asp:HyperLink ID="ProfileMe" runat="server">My Profile</asp:HyperLink></li>
                        <li><a id="A5" runat="server" href="~/Contact.aspx">Contact</a></li>
                        <li Visible= '<%#  (User.IsInRole("Site Admin")) %>'><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/ManageUsers.aspx">Admin Panel</asp:HyperLink>
                    </ul>
                </nav>
          
            </div>
         


      <br />
      <br />
      <br />  <br />  <br />  <br />
      <br />
      <br />  <br />
      <br />
      
            <hgroup>
                  <h1 style="text-align:center">SoundBank</h1>
                     <br/>                      
                      <h2>Find the music you love. Discover new tracks!</h2>
            </hgroup>
            <br />
            <br />
                  <asp:TextBox ID="TextBox1" runat="server" placeholder="Search by title, artist, lyrics or genre" style=" border-radius: 25px;
    border: 2px solid #f2f2f2;" ></asp:TextBox>
                    </div>
                </section>
        
    <div class="suggestiontext">
        <h2 style="text-align:center; color:#777; font:serif;">What's trending</h2>
     </div>
    <br />
    <div class="sth"></div>
      <div class="gridsh" style="width:750px;">
     
              <asp:GridView ID="GridView123" runat="server" AllowPaging="True" 
                HeaderText="123"  emptydatatext="No match"  AutoGenerateColumns="False" 
                EditRowStyle-Height="25" 
                OnRowCommand ="GridView123_RowCommand" Height="389px" 
                style="margin-top: -1px; margin-bottom: 150px; font-size:16px; margin-left:20px; "
                Width="400px"   DataKeyNames="id" DataSourceID="SqlDataSource123">
      
                <Columns>
                     <asp:BoundField DataField="id" HeaderText="id"  SortExpression="id" InsertVisible="False">
                          <ItemStyle CssClass="hidden"/>
                          <HeaderStyle CssClass="hidden"/>
                     </asp:BoundField>
             
                     <asp:ImageField DataImageUrlField="song_image" ControlStyle-CssClass="img-rounded" readonly="true" SortExpression="song_image">
                           <ControlStyle Width="50px" Height="50px" />
                     </asp:ImageField>
                                      
                  <asp:TemplateField ShowHeader="False" >
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" Style="text-decoration:none; font-size:16px;"  CausesValidation="False" CommandName="Details"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text='<%# Bind("Title") %>'></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ShowHeader="False" >
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Style="text-decoration:none;  font-size:16px;"  CausesValidation="False" CommandName="Details"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text='<%# Bind("Artist") %>'></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                     <asp:BoundField DataField="Genre" HeaderText=""  SortExpression="id" >
                          <ItemStyle CssClass="hidden"/>
                          <HeaderStyle CssClass="hidden"/>
                     </asp:BoundField>
                     <asp:BoundField DataField="Lyrics" HeaderText=""  SortExpression="id" >
                          <ItemStyle CssClass="hidden"/>
                          <HeaderStyle CssClass="hidden"/>
                     </asp:BoundField>
                     <asp:TemplateField>
                            <ItemTemplate>
                             <object type="application/x-shockwave-flash" data='dewplayer-vol.swf?mp3=FileCS.ashx?Id=<%# Eval("Id") %>'
                                    width="240" height="20" id="dewplayer">
                                    <param name="wmode" value="transparent" />
                                    <param name="movie" value='dewplayer-vol.swf?mp3=FileCS.ashx?Id=<%# Eval("Id") %>'/>
                                </object>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataNavigateUrlFields="Id" Text = "" ControlStyle-CssClass="fa fa-download" DataNavigateUrlFormatString = "~/FileCS.ashx?Id={0}" HeaderText="" />
                    <asp:TemplateField ShowHeader="False">
                             <ItemTemplate>
                                 <asp:LinkButton ID="LinkButton1" runat="server" Visible= '<%#  (User.IsInRole("Site Admin")) %>' class="fa fa-times" aria-hidden="true" style="color:red; " CausesValidation="False" CommandName="Delete" Text="" ></asp:LinkButton>
                             </ItemTemplate>
                     </asp:TemplateField>  <asp:TemplateField ShowHeader="False">
                           <ItemTemplate>
                              <div id="some-div">             
                                   <asp:LinkButton ID="LinkButton2" class="fa fa-heart" OnClientClick="return false;" aria-hidden="false" style="color: #ff4d94; font-size:15px; margin-left:5px;" runat="server" 
                                               Visible= '<%# (User.Identity.IsAuthenticated) %>' CausesValidation="False" Text=""
                                               CommandName="AddToFavorites123" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" >
                                   </asp:LinkButton>                               
                              </div>

                          </ItemTemplate>
                     </asp:TemplateField>
                     
              </Columns>
                  <PagerStyle HorizontalAlign = "center" />
               
            </asp:GridView>
        
    </div>
    <asp:SqlDataSource ID="SqlDataSource123" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        DeleteCommand="DELETE FROM [tblFiles] WHERE [id] = @id" 
        InsertCommand="INSERT INTO [tblFiles] ([Title], [Artist]) VALUES (@Title, @Artist)" 
        SelectCommand="SELECT [id], [Title], [Artist], [Genre], [Lyrics], [song_image] FROM [tblFiles]  ORDER BY NEWID()" 
        FilterExpression = "[Title] LIKE '%{0}%' OR [Artist] LIKE '%{0}%'  OR [Genre] LIKE '%{0}%' OR [Lyrics] LIKE '%{0}%' "
        UpdateCommand="UPDATE [tblFiles] SET [Title] = @Title, [Artist] = @Artist WHERE [id] = @id">
          <FilterParameters>
             <asp:ControlParameter Name="" ControlID="TextBox1" PropertyName="Text" />
           </FilterParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Artist" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Artist" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
     </asp:SqlDataSource>
    <div id="dialog" title="Basic dialog"></div>
    <asp:TextBox ID="TextBox3" runat="server" visible="false"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" visible="false" ></asp:TextBox>
                 
     <div runat="server" id="suggestions">
      
        <div class="suggestiontext">
            <h2 style="text-align:center; color:#777; font:sans-serif; ">Suggestions</h2>
        </div>

    <div class ="suggest" style="width:200px; text-align:center;" >
     
        <asp:GridView ID="GridView1" runat="server"  
            AutoGenerateColumns="False"  emptydatatext="No suggestions. Add favorites songs." 
            OnRowCommand ="GridView1_RowCommand" 
            style=" font-size:14px; margin-left:0px; "

            DataKeyNames="id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" >
                    <ItemStyle CssClass="hidden"/>
                  <HeaderStyle CssClass="hidden"/>
                </asp:BoundField>
                  <asp:TemplateField ShowHeader="False" >
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Style="text-decoration:none;"  CausesValidation="False" CommandName="Details"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text='<%# Bind("Title") %>'></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                
                <asp:BoundField DataField="Artist" HeaderText="" SortExpression="Artist" >
                      <ItemStyle CssClass="hidden"/>
                  <HeaderStyle CssClass="hidden"/>
                 </asp:BoundField>
                <asp:BoundField DataField="Genre" HeaderText=""  SortExpression="Genre" >
                    <ItemStyle CssClass="hidden"/>
                  <HeaderStyle CssClass="hidden"/>
                 </asp:BoundField>
                 <asp:TemplateField>
                    <ItemTemplate>
                    <object type="application/x-shockwave-flash" data='dewplayer-vol.swf?mp3=FileCS.ashx?Id=<%# Eval("Id") %>'
                            width="240" height="20" id="dewplayer">
                            <param name="wmode" value="transparent" />
                            <param name="movie" value='dewplayer-vol.swf?mp3=FileCS.ashx?Id=<%# Eval("Id") %>'/>
                        </object>
                    </ItemTemplate>
                   </asp:TemplateField>
             
            </Columns>
        </asp:GridView>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
              SelectCommand="SELECT TOP 10 t.id, t.Title, t.Artist, t.Genre FROM tblFiles t
                             INNER JOIN GenreSuggest AS g ON g.genre = t.Genre
                             WHERE g.user_id = @current_user
                             ORDER BY NEWID()
                             ">


           <SelectParameters>
             <asp:ControlParameter Name="current_user" ControlID="TextBox3" PropertyName="Text" />
           </SelectParameters>
        </asp:SqlDataSource>
</div>
 </div>   
  <footer></footer>  
    
</asp:Content>


