<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddSong.aspx.cs" Inherits="ProiectDAW.AddSong" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <div style="padding: 10px; margin-left:180px; margin-top:50px;">
     
   <asp:FileUpload ID="FileUpload1" runat="server" />
        <br/>
        <asp:Label ID="Label1" runat="server" Text="Title to Display"></asp:Label>
        <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
     <br />
        <asp:Label ID="Label2" runat="server" Text="Artist to Display"></asp:Label>
        <asp:TextBox ID="TextBoxArtist" runat="server"></asp:TextBox>
     <br /> 
        <asp:Label ID="Label3" runat="server" Text="Genre"></asp:Label>
        <asp:TextBox ID="TextBoxGenre" runat="server"></asp:TextBox>
     <br /> 
         <asp:Button ID="btnUpload" runat="server" Text="Upload" class = "btn btn-success" onclick="UploadButton" />
   
    </div>
</asp:Content>

