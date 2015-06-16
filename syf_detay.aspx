<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="syf_detay.aspx.cs" Inherits="WebPortal_v1.syf_detay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
    <header class="page-header">
        <div class="wrapper">
            <h1 id="title1" runat="server" class="page-tittle">Sayfa Detay</h1>
        </div>
        <div class="page-header-decoration"></div>
    </header>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphOrtaAlan" runat="server">
    <section id="content" class="invent-content">
        <div>
            <div id="icerik" runat="server">İçerik İçerik.</div>
        </div>
        <div class="column-1-2">
            <div id="divvideo" runat="server" style="display:none;">
                <div class="video you-tube video-decoration border-standard">
                    <iframe id="video" runat="server" width="450" height="225" src="#"></iframe>
                </div>
            </div>
        </div>
        <div class="column-1-2 column-last">
            <div id="divresim" runat="server" style="display:none;">
                <div class="post-image-title border-standard invent-media-container">
                    <img id="resim1" runat="server" src="#" class="invent-media-element attachment-post-thumbnail wp-post-image post-image" alt=""/>
                    <a id="resim2" runat="server" class="mask" href="#" title="" data-fancybox="2">
                        <div class="hover-icon invent-hover-lupe"></div>
                    </a>
                </div>
            </div>
        </div>        
        <div class="clear"></div>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server"></asp:Content>
