<%@ Page Title="Galeri" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="galeri.aspx.cs" Inherits="WebPortal_v1.galeri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
    <header class="page-header">
        <div class="wrapper">
            <h1 class="page-tittle">Galeri</h1>
        </div>
        <div class="page-header-decoration"></div>
    </header>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphOrtaAlan" runat="server">
    <section id="content" class=" invent-content">

        <div class="invent-gallery no-js">
            <ul id="gallery-splitter-1" class="gallery-splitter">
                <li class="gallery-all selected"><a href="#gallery-all" rel="all">Tümü</a></li>
                <asp:Repeater ID="rptAlbum" runat="server">
                    <ItemTemplate>
                        <li class="gallery-<%# Eval("ID") %>"><a href="#gallery-<%# Eval("ID") %>" rel="gallerygroup-<%# Eval("ID") %>"><%# Eval("BASLIK") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="portfolio-1-4 no-description">
                <asp:Repeater ID="rptGaleri" runat="server">
                    <ItemTemplate>
                        <div class="portfolio-element gallery-<%# Eval("ALBUM_ID") %>">
                            <div class="invent-media-container image-left border-standard">
                                <img src="<%# Eval("RES") %>" height="100" width="200" class="invent-media-element attachment-invent-small" alt="<%# Eval("BASLIK") %>" title="<%# Eval("BASLIK") %>" />
                                <a class="mask iframe" href="<%# Eval("LINK") %>" title="<%# Eval("BASLIK") %>" data-fancybox="2">
                                    <div class="hover-icon invent-hover-lupe"></div>
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>                
            </div>
        </div>

    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
