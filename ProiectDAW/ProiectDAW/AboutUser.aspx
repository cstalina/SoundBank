<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AboutUser.aspx.cs" Inherits="ProiectDAW.AboutUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>

    <div  style=" margin-bottom:20px; margin-left:200px; width:400px; margin-right:30px;">
        <asp:Image ID="profileimage" runat="server" style="height:200px; width:200px" CssClass="img-circle person" /> <br /><br />
        <div class="linee">
            
        </div>
        <br />
        <asp:Label ID="LabelFirstName" runat="server" Text="First Name: " Visible="false" ></asp:Label>
        <asp:Label ID="LabelFirstNameValue" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="LabelLastName" runat="server" Text="Last Name: " Visible="false"></asp:Label>
        <asp:Label ID="LabelLastNameValue" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="LabelGender" runat="server" Text="Gender: " Visible="false"></asp:Label>
        <asp:Label ID="LabelGenderValue" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="LabelEmail" runat="server" Text="Email: " Visible="false"></asp:Label>
        <asp:Label ID="LabelEmailValue" runat="server" Text=""  Visible="false"></asp:Label>
        <br />
        <asp:Label ID="LabelMember" runat="server" Text="Member since: " Visible="false"></asp:Label>
        <asp:Label ID="LabelMemberValue" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <asp:Label ID="LabelBio" runat="server" Text="Bio: " Visible="false"></asp:Label>
        <asp:Label ID="LabelBioValue" runat="server" Text="" Visible="false"></asp:Label>
        <br />
    </div>


</asp:Content>
