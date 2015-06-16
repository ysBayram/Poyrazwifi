<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dyr_hbr.ascx.cs" Inherits="WebPortal_v1.user_controls.dyr_hbr" %>

<h4 class="widget-title">Duyuru / Haber</h4>
<asp:Repeater ID="rptDyr_Hbr" runat="server">
    <ItemTemplate>
        <strong><%# Eval("BASLIK") %></strong>
        <p>
            <%# WebPortal_v1.Facade.Tools.ControlLength(Eval("ICERIK").ToString(), 70) %>
        </p>
        <a style="color: rgb(253, 75, 48)" href="detay-<%# Eval("BASLIK") %>-<%# Eval("ID") %>"><strong>Devamı için tıkla...</strong></a><hr style="margin-bottom: 0px;" />
    </ItemTemplate>
</asp:Repeater>
