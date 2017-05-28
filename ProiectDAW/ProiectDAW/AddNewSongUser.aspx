<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewSongUser.aspx.cs" Inherits="ProiectDAW.AddNewSongUser" %>
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
                 <asp:Image ID="profile_picture" runat="server" class="img-circle " style="height:150px; width:150px"/>  
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
            <asp:HyperLink ID="Overviews" runat="server"><b>Overview</b></asp:HyperLink>
            <asp:HyperLink ID="Favorites" runat="server"><b>My Favorites</b></asp:HyperLink>
            <asp:HyperLink ID="ProfileMe" runat="server"><b>My Profile</b></asp:HyperLink>
            <asp:HyperLink ID="NewSong" runat="server"><b>Add Song</b></asp:HyperLink>  
            <asp:HyperLink ID="EditProfileMe" runat="server"><b>Edit Profile</b></asp:HyperLink>
        </nav>
     </div>
  <div style="padding: 10px; margin-left:180px; margin-top:10px;">
      <h4><asp:Label ID="LAnswer" class="label label-danger" runat="server" Text=""></asp:Label></h4>    
      <asp:Label ID="Label55" runat="server" Text="File"></asp:Label><br/>
          <asp:FileUpload ID="FileUpload2" runat="server" />
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <br/>
      <asp:Label ID="Label1" runat="server" Text="Image"></asp:Label><br/>
    <asp:FileUpload ID="FileUpload1" runat="server"  />
    <asp:RegularExpressionValidator ID="regexValidator" runat="server"
     ControlToValidate="FileUpload1"
     ErrorMessage="Only JPEG or JPG images are allowed" 
     ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])$)">
</asp:RegularExpressionValidator>

      <br />
        <asp:Label ID="Label11" runat="server" Text="Title to Display"></asp:Label><br/>
        <asp:TextBox ID="TextBoxTitle1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxTitle1" ErrorMessage="Required Field"></asp:RequiredFieldValidator>

     <br />
        <asp:Label ID="Label22" runat="server" Text="Artist to Display"></asp:Label><br/>
        <asp:TextBox ID="TextBoxArtist1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxArtist1" ErrorMessage="Required Field"></asp:RequiredFieldValidator>

     <br /> 
        <asp:Label ID="Label33" runat="server" Text="Genre"></asp:Label><br/>
        <asp:TextBox ID="TextBoxGenre1" runat="server" placeholder="Trap,Dance,R&B,House..."></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxGenre1" ErrorMessage="Required Field"></asp:RequiredFieldValidator>

     <br /> 
      <asp:Label ID="Label44" runat="server" Text="Lyrics"></asp:Label>
      <br/>
      <asp:TextBox ID="TextBoxLyrics" runat="server" style="width:600px; height:250px;"  TextMode="MultiLine" ></asp:TextBox>
      <asp:TextBox ID="TextBox2" runat="server" Visible="false" style="width:600px; height:250px;" TextMode="MultiLine"></asp:TextBox>
        <br /> <br /> <br /> <br />
         <asp:Button ID="btnUpload1" runat="server" Text="Upload" class = "btn btn-success" onclick="UploadButton1" />
         <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" class = "btn btn-danger" onclick="CancelButton"/>
        <br /> <br /> 
        
</div>
</asp:Content>
