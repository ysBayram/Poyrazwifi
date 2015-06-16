<%@ Page Title="Sayfa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="syf.aspx.cs" Inherits="WebPortal_v1.syf" %>

<%@ Register Src="~/user_controls/akordiyon.ascx" TagName="Akordiyon" TagPrefix="ucAccd" %>
<%@ Register Src="~/user_controls/team.ascx" TagName="Team" TagPrefix="ucTeam" %>
<%@ Register Src="~/user_controls/comments.ascx" TagName="Comments" TagPrefix="ucComment" %>
<%@ Register Src="~/user_controls/down.ascx" TagName="Download" TagPrefix="ucDown" %>
<%@ Register Src="~/user_controls/carusel.ascx" TagName="Carusel" TagPrefix="ucCarusel" %>
<%@ Register Src="~/user_controls/deste.ascx" TagName="Deste" TagPrefix="ucDeste" %>
<%@ Register Src="~/user_controls/tarife.ascx" TagName="Tarife" TagPrefix="ucTarife" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">    
	<link rel="stylesheet" type="text/css" href="styles/carousel.css" media="screen" />  
	<link rel="stylesheet" type="text/css" href="styles/slidedeck.css"  media="screen" />  
	<script type="text/javascript" src="js/jquery.flowy.js"></script>
	<script type="text/javascript" src="js/jquery.jcarousel.js"></script>
	<script type="text/javascript" src="js/slidedeck.jquery.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
    <header class="page-header">
        <div class="wrapper">
            <h1 class="page-tittle">Sayfa</h1>
        </div>
        <div class="page-header-decoration"></div>
    </header>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphOrtaAlan" runat="server">
    <div id="content" class=" invent-content">
        <div id="div1" style="visibility:visible;" runat="server">
            <ucAccd:Akordiyon ID="ucAccd" runat="server" />
            <br />
        </div>
        <div id="div2" style="visibility:visible;" runat="server">
            <ucTeam:Team ID="ucTeam" runat="server" />
            <br />
        </div>
        <div id="div3" style="visibility:visible;" runat="server">
            <ucComment:Comments ID="ucComment" runat="server" />
            <br />
        </div>
        <div id="div4" style="visibility:visible;" runat="server">
            <ucDown:Download ID="ucDown" runat="server" />
            <br />
        </div>
        <div id="div5" style="visibility:visible;" runat="server">
            <ucDeste:Deste ID="ucDeste" runat="server" />
            <br />
        </div>
        <div id="div6" style="visibility:visible;" runat="server">
            <ucCarusel:Carusel ID="ucCarusel" runat="server" />
            <br />
        </div>
        <div id="div7" style="visibility:visible;" runat="server">
            <ucTarife:Tarife ID="ucTarife" runat="server" />
            <br />
        </div>
        <div id="div8" runat="server" hidden="hidden">
            <br />
        </div>
        <div id="div9" runat="server" hidden="hidden">
            <br />
        </div>
        <div id="div10" runat="server" hidden="hidden">
            <br />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
