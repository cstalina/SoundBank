<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Follow.aspx.cs" Inherits="ProiectDAW.Follow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:TextBox ID="TextBox1" visible="false" runat="server"></asp:TextBox>
      <div class="text-center" style="margin:0 auto;">
              <div class="show-image1">
                 <asp:Image ID="profile_picture" runat="server" class="img-circle " style="max-height:150px; width:145px"/>       
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
            <asp:HyperLink ID="Favorites" runat="server"><b>My Favorites</b></asp:HyperLink>
            <asp:HyperLink ID="ProfileMe" runat="server"><b>My Profile</b></asp:HyperLink>
            <asp:HyperLink ID="NewSong" runat="server"><b>Add Song</b></asp:HyperLink>  
            <asp:HyperLink ID="EditProfileMe" runat="server"><b>Edit Informations</b></asp:HyperLink>
        </nav>
      
    </div>  


</asp:Content>
