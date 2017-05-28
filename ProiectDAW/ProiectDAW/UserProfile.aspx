<%@ Page Title="Collection" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="ProiectDAW.UserProfile" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:TextBox ID="TextBoxProfile" visible="false" runat="server"></asp:TextBox>
 <asp:TextBox ID="TextBoxUser"  visible="false" runat="server"></asp:TextBox>
       <div class="text-center" style="margin:0 auto;">
              <div class="show-image1">
                 <asp:Image ID="profile_picture" runat="server" class="img-circle " style="height:150px; width:145px"/>       
              </div>  
           </div> 
            <div class="text-center">
                 <br><h3>       
                 <asp:Label ID="lb_firstname" runat="server" Text=""></asp:Label>
                 <asp:Label ID="lb_lastname" runat="server" Text=""></asp:Label>     
                </h3>
            </div>
    <div class="CollectionOverview">
   
       <nav>
          
            <asp:HyperLink ID="Overview" runat="server"><b>Overview</b></asp:HyperLink>
            <asp:HyperLink ID="Favorites" runat="server"><b>My Favorites</b></asp:HyperLink>
            <asp:HyperLink ID="ProfileMe" runat="server"><b>My Profile</b></asp:HyperLink>
            <asp:HyperLink ID="NewSong" runat="server"><b>Add Song</b></asp:HyperLink>  
            <asp:HyperLink ID="EditProfileMe" runat="server"><b>Edit Profile</b></asp:HyperLink>
        </nav>    
  </div> 
    <div class="overview">
        <div id="div1" runat="server" class="alert alert-warning fade in"  visible="false" style=" text-align:right; margin-right:150px; margin-left:800px; width:200px;">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
 
            <strong>Already in Favorites!</strong> 

        </div>
            <div id="div2" runat="server" class="alert alert-success fade in" visible="false" style=" text-align:right; margin-left:800px; margin-right:150px; width:200px;">
      <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Added in Favorites!</strong> 

        </div>
    <p><b>Overview</b></p>
        
    <div class="gridsh" >
     
     <asp:GridView ID="GridView22" runat="server" AllowPaging="True"  
         style="margin-top: 6px; margin-left:50px; margin-bottom: 150px;" Width="698px " 
         AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1"
             emptydatatext="No Files" 
         OnRowCommand="GridView22_RowCommand" >
         <Columns>
       <asp:BoundField DataField="id" HeaderText="id"  SortExpression="id" InsertVisible="False">
                          <ItemStyle CssClass="hidden"/>
                          <HeaderStyle CssClass="hidden"/>
                     </asp:BoundField>                        <asp:ImageField DataImageUrlField="song_image" ControlStyle-CssClass="img-rounded" readonly="true" SortExpression="song_image">
                           <ControlStyle Width="50px" Height="50px" />
                     </asp:ImageField>
                         <asp:TemplateField ShowHeader="False" >
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Style="text-decoration:none;  font-size:16px;"  CausesValidation="False" CommandName="Details"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text='<%# Bind("Title") %>'></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ShowHeader="False" >
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Style="text-decoration:none;  font-size:16px;"  CausesValidation="False" CommandName="Details"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text='<%# Bind("Artist") %>'></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
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
                                   
                </asp:TemplateField>                 

                     <asp:TemplateField ShowHeader="False">
                           <ItemTemplate>           
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                   <ContentTemplate>                    
                              <div id="some-div">  
                                             
                                   <asp:LinkButton ID="LinkButton2" class="fa fa-heart" aria-hidden="false" style="color: #ff4d94; font-size:15px; margin-left:5px;" runat="server" 
                                               Visible= '<%# (User.Identity.IsAuthenticated) %>' CausesValidation="False" Text=""
                                               CommandName="AddToFavorites22" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" >
                                   </asp:LinkButton>  
                                 
                              </div>      
                                        </ContentTemplate>                            
                                  </asp:UpdatePanel>                                  
                          </ItemTemplate>
                     </asp:TemplateField>
         </Columns>
        <PagerStyle HorizontalAlign = "center" />
        <EditRowStyle  Height="25px"></EditRowStyle>

    </asp:GridView>
         
        </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString%>"
        DeleteCommand="DELETE FROM [Favorites] WHERE [track_id] = @id" 
        InsertCommand="INSERT INTO [tblFiles] ([Title], [Artist]) VALUES (@Title, @Artist)" 
        SelectCommand="SELECT t.id, t.Title, t.Artist, t.song_image FROM tblFiles t INNER JOIN Follow AS f ON  f.id_followed = t.user_id  WHERE f.id_follower = @current_user "
        UpdateCommand="UPDATE [tblFiles] SET [Title] = @Title, [Artist] = @Artist WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Artist" Type="String" />
        </InsertParameters>
         <SelectParameters>
             <asp:ControlParameter Name="current_user" ControlID="TextBoxUser" PropertyName="Text" />
           </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Artist" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
      
    </div>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>


    <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>




     <div class="suggest" style="float:left; width:150px">
          <strong>Who to follow</strong>
     
       <asp:GridView ID="GridView1001" OnRowCommand="GridView1001_RowCommand" runat="server" 
           AllowPaging="True" 
           style="margin-top: 6px; margin-left:15px;  margin-bottom: 150px;" Width="60px " 
           AutoGenerateColumns="False" DataKeyNames="user_id" DataSourceID="SqlDataSource1001">
         <Columns>
             
             <asp:BoundField DataField="user_id" HeaderText="" InsertVisible="False"  ReadOnly="True" SortExpression="user_id" >
                  <ItemStyle CssClass="hidden" /> 
                  <HeaderStyle CssClass="hidden"/>
             </asp:BoundField>

             <asp:ImageField DataImageUrlField="profile_image" ControlStyle-CssClass="img-circle" readonly="true" SortExpression="song_image">
                    <ControlStyle Width="50px"  Height="50px"/>
             </asp:ImageField>

 <asp:TemplateField ShowHeader="False" >
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" Style="text-decoration:none; font-size:16px;"  CausesValidation="False" CommandName="ShowProfile"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text='<%# Bind("user_firstname") %>'></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ShowHeader="False" >
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Style="text-decoration:none;  font-size:16px;"  CausesValidation="False" CommandName="ShowProfile"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text='<%# Bind("user_lastname") %>'></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
             <asp:TemplateField ShowHeader="False">
                 
             </asp:TemplateField>
                
         </Columns>
        
         <PagerStyle HorizontalAlign = "center" />
        <EditRowStyle  Height="50px" Width="150px" BorderWidth="15px"></EditRowStyle>

    </asp:GridView>

   </div>

     <asp:SqlDataSource ID="SqlDataSource1001" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
        SelectCommand="SELECT TOP 10 user_id, profile_image, user_firstname, user_lastname FROM UsersProfile WHERE user_id <> @current_user  ORDER BY NEWID() ">
           <SelectParameters>
             <asp:ControlParameter Name="current_user" ControlID="TextBoxUser" PropertyName="Text" />
           </SelectParameters>
      </asp:SqlDataSource>

    </asp:Content>

