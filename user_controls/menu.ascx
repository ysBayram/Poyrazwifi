<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="WebPortal_v1.user_controls.menu" %>

<ul id="nav" class="sf-menu lavaLampWithImage">
    <li style="margin-right:20px; margin-left:-25px;"><img style="padding-top:7px;" src="../images/icons/31x30/arrow1.png" /><img style="padding-top:7px; margin-left:-18px;" src="../images/icons/31x30/arrow1.png" /><img style="padding-top:7px; margin-left:-18px;" src="../images/icons/31x30/arrow1.png" /></li>
    <asp:Repeater ID="rptMenu" runat="server" OnItemDataBound="rptMenu_ItemDataBound">
        <ItemTemplate>
            <li>
                <a href='<%# Eval("LINK") %>'><%# Eval("ISIM") %></a>
                <ul>                    
                    <asp:Repeater ID="rptAltmenu" runat="server">
                        <ItemTemplate>
                            <li>
                                <a href='<%# Eval("LINK") %>'><%# Eval("ISIM") %></a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </li>
        </ItemTemplate>
    </asp:Repeater>   
</ul>
