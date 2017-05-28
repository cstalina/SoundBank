<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="ProiectDAW.SearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
    <h4 style="margin-left:170px;">Search results for 
    <asp:Label ID="LabelSearch" runat="server" Text=" "></asp:Label></h4>
    <br /> <br /> <br /> <br />
       <div class="gridsh" style="width:1000px; margin-left:150px; margin-top:-40px; border-top: 2px solid #666666">
     
              <asp:GridView ID="GridView123" runat="server" AllowPaging="True" 
                HeaderText="123"  emptydatatext="No match"  AutoGenerateColumns="False" 
                EditRowStyle-Height="5" 
                OnRowCommand ="GridView123_RowCommand" Height="200px" 
                style="margin-top:-30px; margin-bottom: 150px; font-size:16px; margin-left:20px; "
                Width="150px" DataKeyNames="user_id" DataSourceID="SqlDataSource123">
      
                <Columns>
                     <asp:BoundField DataField="user_id" HeaderText="id"  SortExpression="id" InsertVisible="False">
                          <ItemStyle CssClass="hidden"/>
                          <HeaderStyle CssClass="hidden"/>
                     </asp:BoundField>
                                  <asp:ImageField DataImageUrlField="profile_image" ControlStyle-CssClass="img-circle" readonly="true" SortExpression="song_image">
                           <ControlStyle Width="50px" Height="50px" />
                     </asp:ImageField>
                                      
                  <asp:TemplateField ShowHeader="False" >
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" Style="text-decoration:none; font-size:16px;"  CausesValidation="False" CommandName="Details"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text='<%# Bind("user_firstname") %>'></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField ShowHeader="False" >
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" Style="text-decoration:none;  font-size:16px;"  CausesValidation="False" CommandName="Details"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text='<%# Bind("user_lastname") %>'></asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>

                        </Columns>
                  <PagerStyle HorizontalAlign = "center" />
               
            </asp:GridView>

    </div>
    <asp:SqlDataSource ID="SqlDataSource123" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
        SelectCommand="SELECT [user_id], [profile_image], [user_lastname], [user_firstname] FROM [UsersProfile] ORDER BY [user_id] DESC" 
        FilterExpression = "[user_lastname] LIKE '%{0}%' OR [user_firstname] LIKE '%{0}%'"
         
        >
         <FilterParameters>
             <asp:ControlParameter Name="" ControlID="TextBox1" PropertyName="Text" />
           </FilterParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Artist" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Artist" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
     </asp:SqlDataSource>

</asp:Content>
