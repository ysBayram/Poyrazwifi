<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Social.ascx.cs" Inherits="WebPortal_v1.user_controls.Social" %>

<ul id="social" class="invent-social-list">
    <asp:Repeater ID="rptSocial" runat="server">
        <ItemTemplate>
            <li><a class="invent-social-list-el invent-social-<%#Eval("TUR") %>" href="<%#Eval("LINK") %>" title="<%#Eval("TUR") %>" target="_blank"><span class="invent-social-icon"></span></a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
