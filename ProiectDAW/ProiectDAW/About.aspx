<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ProiectDAW.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %> SoundBank</h1>
     
    </hgroup>
    <div class="linee" style="margin-top:-5px; margin-bottom:10px;" ></div>
    <article>
         <h3>SoundBank is the world’s leading social sound platform where anyone can listen sounds and share them everywhere.</h3>

    </article>

    <aside>
      
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>

    <p>SoundBank is a global online audio distribution platform based in Bucharest, Romania, that enables its users to listen, upload and find the music they love.</p>
</asp:Content>