<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddSongUser.aspx.cs" Inherits="ProiectDAW.AddSong" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:TextBox ID="TextBox1" visible="false" runat="server"></asp:TextBox>

    <div class="text-center">
        <asp:Image ID="profile_picture" runat="server" class="img-circle person " width="100px" Height="100px"/>      
        <asp:Label ID="lb_firstname" runat="server" Text=""></asp:Label>
        <asp:Label ID="lb_lastname" runat="server" Text=""></asp:Label>     
    </div>
    <div class="CollectionOverview">   
        <nav>
            <asp:HyperLink ID="Favorites" runat="server"><b>My Favorites</b></asp:HyperLink>
            <asp:HyperLink ID="NewSong" runat="server"><b>Add Song</b></asp:HyperLink>  
        </nav>
     </div>
  <div style="padding: 10px; margin-left:180px; margin-top:50px;">
     
   <asp:FileUpload ID="FileUpload2" runat="server" />
        <br/>
        <asp:Label ID="Label11" runat="server" Text="Title to Display"></asp:Label>
        <asp:TextBox ID="TextBoxTitle1" runat="server"></asp:TextBox>
     <br />
        <asp:Label ID="Label22" runat="server" Text="Artist to Display"></asp:Label>
        <asp:TextBox ID="TextBoxArtist1" runat="server"></asp:TextBox>
     <br /> 
        <asp:Label ID="Label33" runat="server" Text="Genre"></asp:Label>
        <asp:TextBox ID="TextBoxGenre1" runat="server"></asp:TextBox>
     <br /> 
      <asp:Label ID="Label44" runat="server" Text="Lyrics"></asp:Label>
      <asp:TextBox ID="TextBoxLyrics" runat="server" style="width:30px; height:50px;" ></asp:TextBox>
      <br />
         <asp:Button ID="btnUpload1" runat="server" Text="Upload" class = "btn btn-success" onclick="UploadButton1" />
   
    </div>
</asp:Content>

