<%@ Page Title="Genre Preferences" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenrePreferences.aspx.cs" Inherits="ProiectDAW.GenrePreferences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" visible="false" runat="server"></asp:TextBox>

    <div class="CollectionOverview">
   <!-- <div class="ppicture">
    <asp:Label ID="lb_firstname" runat="server" Text=""></asp:Label>
    <asp:Label ID="lb_lastname" runat="server" Text=""></asp:Label>
     </div>
   
    <asp:Image ID="profile_picture" runat="server" width="200px" Height="200px"/>
    <br />
    <br />
    <br />
    -->
        <nav>
        <asp:HyperLink ID="Overview" runat="server"><b>Overview</b></asp:HyperLink>
        <asp:HyperLink ID="Favorites" runat="server"><b>My Favorites</b></asp:HyperLink>
        <asp:HyperLink ID="Genre" runat="server"><b>Genre Preferences</b></asp:HyperLink>
            </nav>
  </div> 
    <div class="overview">
    <p><b>Genre Preferences</b></p>
        <asp:HyperLink ID="AddGenres" runat="server">Add Genres</asp:HyperLink>
        </div>



</asp:Content>
