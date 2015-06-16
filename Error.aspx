<%@ Page Title="Hata Sayfası" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebPortal_v1.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
    <header class="page-header">
        <div class="wrapper">
            <h1 class="page-tittle">Hata 404</h1>
        </div>
        <div class="page-header-decoration"></div>
    </header>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphOrtaAlan" runat="server">
    <div id="content" class=" invent-content">
        <img src="images/error.png" alt="" class="image-center image-no-decoration">
        <div class="invent-center-text">
            <h2>Sayfa Bulunamadı...</h2>
            <p>
                Url Adresini Kontrol Ediniz veya Anasayfaya Gitmek için tıklayınız...<a href="Anasayfa">Anasayfa</a>.
            </p>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
