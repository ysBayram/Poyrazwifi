<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="carusel.ascx.cs" Inherits="WebPortal_v1.user_controls.carusel" %>

<h2>İş Ortaklarımız</h2>
<div class="carousel-container big">
    <div class="arrow-left-box jcarousel-controls"><a class="jcarousel-left jcarousel-prev"></a></div>
    <div class="jcarousel-900">

        <ul class="jcarousel-skin-horizontal1 hidden">
            <asp:Repeater ID="rptCarousel" runat="server">
                <ItemTemplate>
                    <li>
                        <div>
                            <div class="invent-media-container border-standard">
                                <img class="invent-media-element" width="194" height="104" src="<%# Eval("ICERIK") %>" alt="<%# Eval("BASLIK") %>" />
                                <a href="<%# Eval("ICERIK") %>" title="<%# Eval("BASLIK") %>" data-fancybox="625" class="mask">
                                    <div class="hover-icon  invent-hover-lupe"></div>
                                </a>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div class="arrow-right-box jcarousel-controls"><a class="jcarousel-right jcarousel-next"></a></div>
    <div class="clear"></div>
</div>
