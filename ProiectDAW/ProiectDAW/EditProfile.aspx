<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="ProiectDAW.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 49%;
            height: 135px;
        }
        .auto-style2 {
            width: 100px;
        }
        .auto-style3 {
            width: 167px;
        }
        .auto-style4 {
            width: 100px;
            height: 65px;
        }
        .auto-style5 {
            width: 167px;
            height: 65px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h3>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hello,
        <asp:LoginName ID="LoginName1" runat="server" />!
    </h3>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Image ID="profile_picture" runat="server" style="max-height:170px; width:auto"/> <br />
    <asp:FileUpload ID="FileUpload1" runat="server"  />
    <asp:RegularExpressionValidator ID="regexValidator" runat="server"
     ControlToValidate="FileUpload1"
     ErrorMessage="Only JPEG, JPG or PNG images are allowed" 
     ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([Pp][Nn][Gg])$)">
</asp:RegularExpressionValidator>
    <table class="auto-style1" >
      
        <tr>
            <td class="auto-style2">First Name </td>
            <td class="auto-style3">
                <asp:TextBox ID="FirstName" runat="server" ></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style2">Last Name </td>
            <td class="auto-style3">
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td >Gender</td>
            <td >
                <asp:RadioButtonList ID="Gender" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" style="font-size:10px;">
                     <asp:ListItem  Value="Male" Text="Male"></asp:ListItem>
                     <asp:ListItem  Value="Female" Text="Female"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>Bio </td>
            <td>
                  <asp:TextBox ID="TextBoxBio" runat="server" style="width:400px; height:250px;"  TextMode="MultiLine" ></asp:TextBox>
                </td>
        </tr>
        <tr></tr>
        <tr>
            <td>
                <asp:Button ID="Button2" background="none" runat="server" Text="Save" class = "btn btn-success" OnClick="SaveProfile" />
             </td>

            <td>     
               <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" class = "btn btn-danger" onclick="CancelButton"/>
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:Label ID="LAnswer" runat="server" Text=""></asp:Label>
</asp:Content>
