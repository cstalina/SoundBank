<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ProiectDAW.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %> SoundBank</h1>
    </hgroup>
            <div class="linee" style="margin-top:-5px; margin-bottom:10px;" ></div>

    <section class="contact">
        <header>
            <h3>Phone:</h3>
        </header>
        <p>
            <span >Main:</span>
            <span>0729 873 456</span>
        </p>
        <p>
            <span >After Hours:</span>
            <span>0734 567 894</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span >Support:</span>
            <span><a href="mailto:Support@soundbank.com">contact@soundbank.com</a></span>
        </p>
        <p>
            <span >Marketing:</span>
            <span><a href="mailto:Marketing@soundbank.com">Marketing@soundbank.com</a></span>
        </p>
        <p>
            <span >General:</span>
            <span><a href="mailto:General@soundbank.com">General@soundbank.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Address:</h3>
        </header>
        <p>
            Bd Queen E<br />
            Bucharest, WA 98052-6399
        </p>
    </section>
</asp:Content>