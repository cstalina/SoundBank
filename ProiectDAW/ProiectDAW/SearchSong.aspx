<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="SearchSong.aspx.cs" Inherits="ProiectDAW.SearchSong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:SqlDataSource ID="SDSSearch" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT track_id, track_name, track_artist, track_url FROM tracks ">
    </asp:SqlDataSource>

    <asp:Label ID="LSelect" runat="server" Text=""></asp:Label>
    <br />
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SDSSearch">
        <HeaderTemplate>
            Search results:
        </HeaderTemplate>
        <ItemTemplate>
            <div style="padding: 10px; background-color: #e6ff99">
                         
                <div>
                    Title: <%# DataBinder.Eval(Container.DataItem, "track_name")%>
                </div>
                <div>
                    Artist: <%# DataBinder.Eval(Container.DataItem, "track_artist")%>
                </div>
                 <div>
                     Url: <%# DataBinder.Eval(Container.DataItem, "track_url")%>
                </div>
                 
                
             </div>
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
    </asp:Repeater>
</asp:Content>

