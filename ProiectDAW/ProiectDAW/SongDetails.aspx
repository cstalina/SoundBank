<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SongDetails.aspx.cs" Inherits="ProiectDAW.SongDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <div id="div1" runat="server" class="alert alert-warning fade in"  visible="false" style=" text-align:right; margin-right:150px; float:left; margin-left:0px; width:200px;">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
 
            <strong>Already in Favorites!</strong> 

        </div>
            <div id="div2" runat="server" class="alert alert-success fade in" visible="false" style=" text-align:right; margin-left:0px; float:left; margin-right:150px; width:200px;">
      <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Added in Favorites!</strong> 

        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    <div  style=" margin-bottom:20px; margin-left:200px; width:400px; margin-right:30px; float:left;">

    <asp:TextBox ID="id" runat="server" Visible="false"></asp:TextBox>
      
    <asp:Image ID="songimage" class="img-rounded" runat="server" style="height:150px; width:150px" /> <br />
      
        <asp:GridView ID="GridView123" runat="server" AllowPaging="True" 
                HeaderText="123"  emptydatatext="No match"  AutoGenerateColumns="False" 
                EditRowStyle-Height="25" 
                OnRowCommand ="GridView123_RowCommand" Height="389px" 
                style="margin-top: -260px; margin-bottom: -90px; font-size:16px; margin-left:0px;" DataKeyNames="id" 
                DataSourceID="SqlDataSource123">
      
                <Columns>
                     <asp:BoundField DataField="id" HeaderText="id"  SortExpression="id" InsertVisible="False">
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
                     </asp:TemplateField>
                       <asp:TemplateField ShowHeader="False">
                           <ItemTemplate>
                              <div id="some-div">             
                                   <asp:LinkButton ID="LinkButton2" class="fa fa-heart" aria-hidden="false" style="color: #ff4d94; font-size:15px; margin-left:5px;" runat="server" 
                                               Visible= '<%# (User.Identity.IsAuthenticated) %>' CausesValidation="False" Text=""
                                               CommandName="AddToFavorites123" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" >
                                   </asp:LinkButton>                               
                              </div>
                          </ItemTemplate>
                     </asp:TemplateField>
              </Columns>
       </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource123" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT [id] FROM [tblFiles] WHERE [id]=@id" >
            <SelectParameters>
             <asp:ControlParameter Name="id" ControlID="id" PropertyName="Text" />
           </SelectParameters>     
     </asp:SqlDataSource>
          <br />
    <asp:Label ID="Label1" runat="server" Text="Title:" Visible="false" style="font-size:20px;" ></asp:Label>
    <asp:Label ID="LabelTitle" runat="server" Visible="false" style="font-size:16px;"></asp:Label><br />

    <asp:Label ID="Label2" runat="server" Text="Artist:" Visible="false" style="font-size:20px;"></asp:Label>
    <asp:Label ID="LabelArtist" runat="server" Visible="false" style="font-size:16px;"></asp:Label><br />

    <asp:Label ID="Label3" runat="server" Text="Uploaded by " Visible="false" style="font-size:20px;"></asp:Label>
    <asp:HyperLink ID="LabelUploader" runat="server" Visible="false"  style=" text-decoration:none; color:black; font-size:16px;"></asp:HyperLink>
    <asp:Label ID="Label8" runat="server" Text="On " Visible="false" style="font-size:20px;"></asp:Label>
    <asp:Label ID="LabelUploadedOn" runat="server" Visible="false"  style="font-size:16px;"></asp:Label><br />

   
    <asp:Label ID="Label4" runat="server" Text="Genre:" Visible="false" style="font-size:20px;"></asp:Label>
    <asp:Label ID="LabelGenre" runat="server" Visible="false"  style="font-size:16px;"></asp:Label><br />

     <asp:Label ID="Label6" runat="server" Text="Liked by" Visible="false" style="font-size:20px;"></asp:Label>
    <asp:Label ID="LabelHearted" runat="server" Visible="false" style="font-size:16px;" ></asp:Label>
    <asp:Label ID="LabelPeople" runat="server" Text="people" Visible="false" style="font-size:20px;"></asp:Label><br />
     </div>
    <div style="float:left; width:400px; margin-right:140px;" >
    <asp:Label ID="Label5" runat="server" Text="Lyrics" Visible="false" style="font-size:20px;"></asp:Label><br/><br/>
    <asp:Label ID="LabelLyrics" runat="server" style="height:auto; font-size:16px;" Visible="false" ></asp:Label><br />
            <br /><br />
    <br />


    </div>
    <br /><br />
    <br />
    <asp:TextBox ID="TextBox2" Visible="false" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox3" Visible="false" runat="server"></asp:TextBox>
</asp:Content>
