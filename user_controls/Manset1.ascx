<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Manset1.ascx.cs" Inherits="WebPortal_v1.user_controls.Manset1" %>

<div class="home-page-slider-color">
    <div class="home-page-slider-background">
        <div class="slider-margins home-page-slider-container any-slider-container">

            <ul class="any-slider anythingSliderFx">
                <asp:Repeater ID="rptManset" runat="server">
                    <ItemTemplate>
                        <li>
                            <div runat="server" class="any-slide-video video-decoration border-slider" visible='<%# (Eval("TIP").ToString() == "3") %>'>
                                <iframe src="<%# Eval("VID") %>" width="560" height="360" frameborder="0"></iframe>
                            </div>
                            <div runat="server" class="any-slide-text" visible='<%# (Eval("TIP").ToString() == "3") %>'>
                                <h1><%# Eval("BASLIK") %></h1>
                                <div class="slide-content">
                                    <p><%# Eval("ICERIK") %></p>
                                    <a href="<%# Eval("LINK") %>" class="invent-button invent-button-big invent-button-default left"><span>Detay İçin Tıkla!</span></a>
                                </div>
                            </div>

                            <div runat="server" visible='<%# (Eval("TIP").ToString() == "2") %>' class="any-slide-video video-decoration border-slider">
                                <iframe src="<%# Eval("VID") %>" width="930" height="370"></iframe>
                            </div>
                            <div runat="server" visible='<%# (Eval("TIP").ToString() == "1") %>'>
                                <a href="<%# Eval("LINK") %>">
                                    <img src="<%# Eval("RES") %>" alt="" width="940" height="380" /></a>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>                
            </ul>

        </div>
    </div>
</div>
<div class="slider-decoration-bottom"></div>
