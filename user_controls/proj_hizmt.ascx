<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="proj_hizmt.ascx.cs" Inherits="WebPortal_v1.user_controls.proj_hizmt" %>

<div class="carousel-container big">
    <div class="arrow-left-box jcarousel-controls"><a class="jcarousel-left jcarousel-prev"></a></div>
    <div class="jcarousel-900" >
        <ul class="jcarousel-skin-horizontal1 hidden">
            <asp:Repeater ID="rptProj_Hizmet" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="column-1-4">
                            <div class="invent-big-color-icon-center">
                                <img src="<%# Eval("RES") %>" alt="" />
                            </div>
                            <h4 class="invent-center-text"><%# Eval("BASLIK") %></h4>
                            <p><%# WebPortal_v1.Facade.Tools.ControlLength(Eval("ICERIK").ToString(),150) %></p>
                            
                            <a class="fancybox invent-read-more" href="#inline<%# Eval("ID") %>">Detaylar İçin Tıklayınız...</a>
                            <div style="display: none;"><div style="width: 500px;" id="inline<%# Eval("ID") %>"><h3><%# Eval("BASLIK") %></h3><p><%# Eval("ICERIK") %></p></div></div>
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

