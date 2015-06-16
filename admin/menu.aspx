<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="WebPortal_v1.admin.menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iBlocks">Menu Yönetimi</h5>
        </div>
        <div class="rowElem">
            <label>Kategori :</label><div class="formRight">
                <asp:RadioButtonList ID="rbtnKat" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnKat_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Selected="True" Value="0">Üst Kategori</asp:ListItem>
                    <asp:ListItem Value="1">Alt Kategori</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:DropDownList ID="ddlUstSec" runat="server" Visible="false" ToolTip="Lütfen Üst Kategori Seçiniz!"></asp:DropDownList>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>İsim :</label>
            <div class="formRight">
                <asp:TextBox runat="server" ID="tbIsim"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Link :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbLink"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <asp:Button runat="server" ID="btnKaydet" Text="Kaydet" CssClass="nomargin submitForm redBtn" OnClick="btnKaydet_Click" />
            <div class="fix"></div>
        </div>
        <br />
    </div>
        <div class="rowElem" style="padding:0px;">
            <div id="divTable" class="table" runat="server">
                <div class="head">
                    <h5 class="iFrames">Menu Yönetimi</h5>
                </div>
                <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">
                    <thead>
                        <tr>
                            <th>İsim</th>
                            <th>Link</th>
                            <th>Düzenle</th>
                            <th>Sil</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptMenu" runat="server" OnItemCommand="rptMenu_ItemCommand">
                            <ItemTemplate>
                                <tr class="gradeA even">
                                    <td><%# Eval("ISIM") %></td>
                                    <td><%# Eval("LINK") %></td>
                                    <td class="center">
                                        <asp:ImageButton ID="IbtnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("ID") %>' ImageUrl="~/admin/images/icons/color/pencil.png" />
                                    </td>
                                    <td class="center">
                                        <asp:ImageButton ID="IbtnSil" runat="server" CommandName="Sil" CommandArgument='<%# Eval("ID") %>' ImageUrl="~/admin/images/icons/color/cross.png" OnClientClick="return confirm('Silme işlemini onaylıyor musunuz?');" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div class="fix"></div>
        </div>

</asp:Content>
