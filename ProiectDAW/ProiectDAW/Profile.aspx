<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ProiectDAW.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:TextBox ID="TextBoxProfile" visible="false" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBoxUser"  visible="false" runat="server"></asp:TextBox>
    <div style="text-align:right; margin-right:150px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
           <ContentTemplate>
            <asp:Button ID="ButtonF" runat="server" Text="Follow"  class="btn btn-default" onClick="Follow"/>
            <asp:Button ID="ButtonU" runat="server" Text="Unfollow" class="btn btn-success" onClick="Unfollow" />
            </ContentTemplate>
         </asp:UpdatePanel>  
      </div> 
          <div class="text-center" style="margin:0 auto;">
              <div class="show-image1">
                 <asp:Image ID="profile_picture" runat="server" class="img-circle person" style="height:150px; width:150px;"/>  
             </div>  
           </div> 
            <div class="text-center" style="margin-top:-10px;">
                 <br><h3>       
                 <asp:Label ID="lb_firstname" runat="server" Text=""></asp:Label>
                 <asp:Label ID="lb_lastname" runat="server" Text=""></asp:Label>     
                </h3>
   
           </div>
        <div class="CollectionOverview">   
            <nav>
                <asp:HyperLink ID="FavoritesMe" runat="server"><b>Favorites</b></asp:HyperLink>
                <asp:HyperLink ID="ProfileMe" runat="server"><b>Profile</b></asp:HyperLink>
                <asp:HyperLink ID="AboutUser1" runat="server"><b>About</b></asp:HyperLink>

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
       <p><b>Songs</b></p>
        
    <div class="gridsh" >
        
       <asp:GridView ID="GridView22" OnRowCommand="GridView22_RowCommand" runat="server" AllowPaging="True"
            emptydatatext="No Uploaded Files" style="margin-top: 6px; margin-left:50px;  margin-bottom: 150px;" Width="720px " AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
         <Columns>

              <asp:BoundField DataField="id" HeaderText="" InsertVisible="False"  ReadOnly="True" SortExpression="id" >
                  <ItemStyle CssClass="hidden"/>
                  <HeaderStyle CssClass="hidden"/>
             </asp:BoundField>
               <asp:ImageField DataImageUrlField="song_image" ControlStyle-CssClass="img-rounded" readonly="true" SortExpression="song_image">
                           <ControlStyle Width="50px"  Height="50px"/>
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
           
            <asp:HyperLinkField DataNavigateUrlFields="Id" Text = "" DataNavigateUrlFormatString = "~/FileCS.ashx?Id={0}" ControlStyle-CssClass="fa fa-download" HeaderText="" />
            
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

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        DeleteCommand="DELETE FROM [tblFiles] WHERE [id] = @id" 
        InsertCommand="INSERT INTO [tblFiles] ([Title], [Artist]) VALUES (@Title, @Artist)" 
        SelectCommand="SELECT id, song_image, Title, Artist FROM tblFiles WHERE user_id = @user "
        UpdateCommand="UPDATE [tblFiles] SET [Title] = @Title, [Artist] = @Artist WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
         <SelectParameters>
             <asp:ControlParameter Name="user" ControlID="TextBoxProfile" PropertyName="Text" />
           </SelectParameters>
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
      
    </div>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    
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
                    <ControlStyle Width="50px" Height="50px" />
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
             <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>

</asp:Content>
