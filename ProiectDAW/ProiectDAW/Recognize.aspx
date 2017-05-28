<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recognize.aspx.cs" Inherits="ProiectDAW.Recognize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="padding: 10px; margin-left:180px; margin-top:50px;">
     <p> Upload your sample to find the song </p>
     <asp:FileUpload ID="FileUpload1" runat="server" />
       <br /> 
         <asp:Button ID="btnUpload" runat="server" Text="Upload"  onclick="prepare" />
    </div>
</asp:Content>
