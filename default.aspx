<%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebPortal_v1._default" %>

<%@ Register Src="~/user_controls/Manset1.ascx" TagName="Manset1" TagPrefix="ucManset1" %>
<%@ Register Src="~/user_controls/info.ascx" TagName="Contact_Info" TagPrefix="ucInfo" %>
<%@ Register Src="~/user_controls/dyr_hbr.ascx" TagName="Dyr_Hbr" TagPrefix="ucDyr_Hbr" %>
<%@ Register Src="~/user_controls/proj_hizmt.ascx" TagName="Prj_Hzmt" TagPrefix="ucPrj_Hzmt" %>
<%@ Register Src="~/user_controls/carusel.ascx" TagName="Carusel" TagPrefix="ucCarusel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">

    <script type="text/javascript" src="js/jquery.anythingslider.video.js"></script>
    <script type="text/javascript" src="js/jquery.anythingslider.js"></script>
    <link rel="stylesheet" type="text/css" href="styles/anythingslider.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="styles/theme-minimalist-round.css" media="screen" />
    <script type="text/javascript" src="js/jquery.anythingslider.fx.js"></script>    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
    <header class="home-page-header">
        <ucManset1:Manset1 ID="Manset1" runat="server" />
    </header>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphOrtaAlan" runat="server">
    <div class="under-main-header"></div>
    <div id="content" class="invent-content home-page-content">
        <div class="invent-solid-container text-center">
            <h1>Web sitemize Hoşgeldiniz</h1>
            <h2>Kaliteli bir hizmet için <span class="invent-text-red">Buradayız</span></h2>
            <p><span class="invent-text-blue">Seçkin ve Özgün Ürünlerimiz Sayesinde Her Türden Yazılım ve İnternet Hizmetini İtina ile Siz Değerli Müşterilerimize Sunuyoruz</span></p>
        </div>
        <div class="invent-solid-container-bottom"></div>
        <ucPrj_Hzmt:Prj_Hzmt ID="ucPrj_Hzmt" runat="server" />
        <div class="clear"></div>
        <ucCarusel:Carusel ID="ucCarusel" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
    <section id="widgets-container" class="bottom-widgets">
        <div class="widgets-container-border widgets-container-top"></div>

        <div class="wrapper">
            <div class="column-1-4" style="width: 155px;">
                <aside id="text-3" class="widget-container widget_text">
                    <h4 class="widget-title">İletişim</h4>
                    <div class="textwidget">
                        <ucInfo:Contact_Info ID="ucInfo" runat="server" />
                    </div>
                </aside>
            </div>

            <div class="column-1-4">
                <aside id="Aside1" class="widget-container widget_text">
                    <ucDyr_Hbr:Dyr_Hbr ID="ucDyr_Hbr" runat="server" />
                </aside>
            </div>

            <div class="column-1-4" style="width: 270px;">
                <aside id="twitter-1" class="widget-container widget_twitter">
                    <h4 class="widget-title"  style="margin-bottom:0px;">Tweetler</h4>
                    <a class="twitter-timeline" href="https://twitter.com/PoyrazWifi" data-widget-id="387549368875626496" data-chrome="nofooter noborders" lang="tr">@PoyrazWifi kullanıcısından Tweetler</a>
                    <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>
                </aside>
            </div>

            <div id="fb-root"></div>
            <script>(function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return; js = d.createElement(s); js.id = id; js.src = "//connect.facebook.net/en_GB/all.js#xfbml=1&appId=171621146320101"; fjs.parentNode.insertBefore(js, fjs); }(document, 'script', 'facebook-jssdk'));</script>

            <div class="column-1-4 column-last" style="width: 235px;">
                <aside id="flickr-3" class="widget-container widget_flickr">
                    <h4 class="widget-title">Facebook</h4>

                    <div class="fb-like-box" data-href="https://www.facebook.com/pages/Poyrazwifi/204698903020908" data-width="235" data-height="250" data-show-faces="true" data-stream="false" data-header="false" data-border-color="white"></div>

                </aside>
            </div>

            <div class="clear"></div>
        </div>

        <div class="widgets-container-border widgets-container-bottom"></div>
    </section>
</asp:Content>
