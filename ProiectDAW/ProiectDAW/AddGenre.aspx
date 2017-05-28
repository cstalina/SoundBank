<%@ Page Title="Add Genres" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGenre.aspx.cs" Inherits="ProiectDAW.AddGenre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:TextBox ID="TextBox1" visible="false" runat="server"></asp:TextBox>
    <div class="CollectionOverview">
        <h2 style="color:black;">Choose Genres </h2>
        <br />
        <br />
        <br />
        </div>

    <div class="overview" style="font-size:1.2em; ">

    <asp:Label ID="Blues" runat="server" Text=" Blues"></asp:Label>
    <asp:CheckBox ID="CheckBoxBlues" runat="server" />
    <br/>  <br/>
    
    <asp:Label ID="Classical" runat="server" Text="Classical"></asp:Label>
    <asp:CheckBox ID="CheckBoxClassical" runat="server" />
     <br/>  <br/>
    
    <asp:Label ID="Country" runat="server" Text="Country"></asp:Label>
    <asp:CheckBox ID="CheckBoxCountry" runat="server" />
     <br/>  <br/>
    <asp:Label ID="Dance" runat="server" Text="Dance"></asp:Label>
    <asp:CheckBox ID="CheckBoxDance" runat="server" />
     <br/>  <br/>
    <asp:Label ID="Electronic" runat="server" Text="Electronic "></asp:Label>
    <asp:CheckBox ID="CheckBoxElectronic" runat="server" />
     <br/>  <br/>
    <asp:Label ID="HipHopRap" runat="server" Text="HipHop/Rap"></asp:Label>
    <asp:CheckBox ID="CheckBoxHipHopRap" runat="server" />
        <br/>  <br/>
    <asp:Label ID="Jazz" runat="server" Text="Jazz"></asp:Label>
    <asp:CheckBox ID="CheckBoxJazz" runat="server" /> 
       <br/>  <br/>
    <asp:Label ID="Latin" runat="server" Text="Latin"></asp:Label>
    <asp:CheckBox ID="CheckBoxLatin" runat="server" />    
    <br/>  <br/>
    <asp:Label ID="Opera" runat="server" Text="Opera"></asp:Label>
    <asp:CheckBox ID="CheckBoxOpera" runat="server" /> 
       <br/>  <br/>
    <asp:Label ID="Pop" runat="server" Text="Pop"></asp:Label>
    <asp:CheckBox ID="CheckBoxPop" runat="server" />
          <br/>  <br/>
    <asp:Label ID="RBSoul" runat="server" Text="R&B/Soul"></asp:Label>
    <asp:CheckBox ID="CheckBoxRBSoul" runat="server" />  
        <br/>  <br/>
    <asp:Label ID="Reggae" runat="server" Text="Reggae"></asp:Label>
    <asp:CheckBox ID="CheckBoxReggae" runat="server" />   
       <br/>  <br/>
    <asp:Label ID="Rock" runat="server" Text="Rock"></asp:Label>
    <asp:CheckBox ID="CheckBoxRock" runat="server" />   
       <br/>  <br/>
    <asp:Label ID="Trap" runat="server" Text="Trap"></asp:Label>
    <asp:CheckBox ID="CheckBoxTrap" runat="server" />
      <br/>  <br/>
    <asp:Label ID="OtherGenre" runat="server" Text="Others"></asp:Label>
    <asp:CheckBox ID="CheckBoxOtherGenre" runat="server" />
           <br/>  <br/>


    <asp:Button ID="AddGenres" runat="server" Text="Save" OnClick="AddGenres" />

</div>
</asp:Content>
