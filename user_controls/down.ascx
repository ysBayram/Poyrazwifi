<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="down.ascx.cs" Inherits="WebPortal_v1.user_controls.down" %>

<asp:Repeater ID="rptDown" runat="server">
    <ItemTemplate>
        <div style="height: 40px; margin-bottom: 10px; background-color: #DEDEE0;">
            <img style="float: left; padding-top: 5px;" width="31" src="../images/icons/31x30/arrow3.png" />
            <a href="<%# Eval("LINK") %>" target="_blank" style="float: left; padding-left: 15px; padding-top: 10px; font-size: larger;"><%# Eval("BASLIK") %></a>
            <a href="<%# Eval("LINK") %>" target="_blank" class="invent-button invent-button-big invent-button-white right" style="margin-bottom: 0px; border-radius: 0px;">İNDİR</a>
        </div>
    </ItemTemplate>
</asp:Repeater>


