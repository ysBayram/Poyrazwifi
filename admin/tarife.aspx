<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="tarife.aspx.cs" Inherits="WebPortal_v1.admin.tarife" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iCreate">Tarife Yönetimi</h5>
        </div>
        <div class="rowElem">
            <label>Tarife Tür :</label>
            <div class="formRight">
                <asp:RadioButton ID="rbFtr" runat="server" GroupName="tarife" Text="Faturasız" /> <asp:RadioButton ID="rbStr" runat="server" GroupName="tarife" Text="Simetrik" />
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Tarife Adı :</label>
            <div class="formRight">
                <asp:TextBox runat="server" ID="tbAd" ></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <div class="widgets">
                <div class="left">
                    <label>Download Limiti :</label>
                    <asp:TextBox runat="server" ID="tbDown"></asp:TextBox>
                    <br />
                    <label>Kota Limiti :</label>
                    <asp:TextBox runat="server" ID="tbKota"></asp:TextBox>
                </div>
                <div class="right">
                    <label>Upload Limiti :</label>
                    <asp:TextBox runat="server" ID="tbUp"></asp:TextBox>
                    <br />
                    <label>Ucret :</label>
                    <asp:TextBox runat="server" ID="tbUcret"></asp:TextBox>
                </div>
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
            <div id="Div1" class="table" runat="server">
                <div class="head">
                    <h5 class="iFrames">Tarifeler</h5>
                </div>
                <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">
                    <thead>
                        <tr>
                            <th>Başlık</th>
                            <th>Düzenle</th>
                            <th>Sil</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptTarife" runat="server" OnItemCommand="rptTarife_ItemCommand">
                            <ItemTemplate>
                                <tr class="gradeA even">
                                    <td><%# Eval("AD") %></td>
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
