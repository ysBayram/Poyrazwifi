<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="akordiyon.ascx.cs" Inherits="WebPortal_v1.user_controls.akordiyon" %>

<h3>Akordiyon</h3>
<hr />

<div class="acc-style4 accordion invent-accordion">
    <asp:Repeater ID="rptAkordiyon" runat="server">
        <ItemTemplate>
            <div class="acc-section">
                <h3><span class="invent-color"><%# Eval("BASLIK") %></span></h3>
                <div class="acc-content"><div><p><%# Eval("ICERIK") %></p></div></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
