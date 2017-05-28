<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DeleteSong.aspx.cs" Inherits="ProiectDAW.DeleteSong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="PConfirm" runat="server">
        <h4>
            Do you wish to delete  <asp:Label ID="LTitle" runat="server" Text=""></asp:Label>?
        </h4>
        <br />
        <asp:Button ID="DeleteButton" runat="server" Text="Yes" Width="50" OnClick="DeleteButton_Click" /><span style="padding-left: 20px;"></span>
        <asp:Button ID="CancelButton" runat="server" Text="No"  Width="50" OnClick="CancelButton_Click" />
    </asp:Panel>
    <div style="padding: 10px">
        <asp:Label ID="LAnswer" runat="server" Text=""></asp:Label>
        <br />
        <asp:HyperLink ID="HLHomepage" runat="server" NavigateUrl="~/Index.aspx" Visible="false">Back to My Songs</asp:HyperLink>
    </div>
</asp:Content>

