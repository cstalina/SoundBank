<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSongDetails.aspx.cs" Inherits="ProiectDAW.EditSongDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>

        <div style="padding: 10px; margin-left:80px; margin-top:50px;">
        <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>
        <asp:Image ID="song_picture" runat="server" style="max-height:170px; width:auto"/> <br />
        <asp:Label ID="Label1" runat="server" Text="Image"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server"  style="width:600px;" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
         ControlToValidate="FileUpload1"
         ErrorMessage="Only JPEG or JPG images are allowed" 
         ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])$)">
        </asp:RegularExpressionValidator>

          <br /><br />
        <asp:Label ID="Label11" runat="server" Text="Title to Display" ></asp:Label>
            <br />
        <asp:TextBox ID="TextBoxTitle1" runat="server" style="width:600px;"></asp:TextBox>
          <br /><br />
        <asp:Label ID="Label22" runat="server" Text="Artist to Display"></asp:Label>
            <br />
        <asp:TextBox ID="TextBoxArtist1" runat="server" style="width:600px;"></asp:TextBox>
          <br /><br />
        <asp:Label ID="Label33" runat="server" Text="Genre"></asp:Label>
            <br /><asp:TextBox ID="TextBoxGenre1" runat="server" style="width:600px;"></asp:TextBox>
          <br /><br />
        <asp:Label ID="Label44" runat="server" Text="Lyrics"></asp:Label>
           <br /> <asp:TextBox ID="TextBoxLyrics" runat="server" style="width:600px; height:250px;"  TextMode="MultiLine" ></asp:TextBox>
           <br /><br />
        <asp:Button ID="btnSave" runat="server" Text="Save" class = "btn btn-success" onclick="Save" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class = "btn btn-danger" onclick="Cancel" />

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


</asp:Content>
