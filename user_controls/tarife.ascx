<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tarife.ascx.cs" Inherits="WebPortal_v1.user_controls.tarife" %>

<div class="table-decoration">
    <h3>Faturasız Tarifeler</h3>
    <table>
        <thead>
            <tr>
                <th><strong>Tarife Adı</strong></th>
                <th><strong>Download / Upload</strong></th>
                <th><strong>Kota</strong></th>
                <th><strong>Fiyat</strong></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptFtarife" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("AD") %></td>
                        <td><%# Eval("DOWN") %> Mbit/<%# Eval("UP") %> Mbit</td>
                        <td><%# Eval("KOTA") %> gb</td>
                        <td><%# Eval("UCRET") %> TL</td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>                        
        </tbody>
    </table>    
    <h3>Simetrik Tarifeler</h3>
    <table>
        <thead>
            <tr>
                <th><strong>Tarife Adı</strong></th>
                <th><strong>Download / Upload</strong></th>
                <th><strong>Kota</strong></th>
                <th><strong>Fiyat</strong></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptStarife" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("AD") %></td>
                        <td><%# Eval("DOWN") %> Mbit/<%# Eval("UP") %> Mbit</td>
                        <td><%# Eval("KOTA") %> gb</td>
                        <td><%# Eval("UCRET") %> TL</td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>                        
        </tbody>
    </table>    

</div>
