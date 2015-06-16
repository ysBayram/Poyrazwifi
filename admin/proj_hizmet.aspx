<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="proj_hizmet.aspx.cs" Inherits="WebPortal_v1.admin.proj_hizmet" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iCreate">Proje & Hizmet Yönetimi</h5>
        </div>
        <div class="rowElem">
            <label>Resim :</label><div class="formRight">
                <asp:RadioButtonList ID="rbtnRes" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem><img src="../images/icons/big/coffee.png" style="background-color:gray;" /></asp:ListItem>
                    <asp:ListItem><img src="../images/icons/big/help.png" style="background-color:gray;" /></asp:ListItem>
                    <asp:ListItem><img src="../images/icons/big/settings.png" style="background-color:gray;" /></asp:ListItem>
                    <asp:ListItem><img src="../images/icons/big/target.png" style="background-color:gray;" /></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Başlık :</label>
            <div class="formRight">
                <asp:TextBox runat="server" ID="tbBaslik" CssClass="topDir"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Özet Bilgi :</label>
            <div class="formRight">
                <asp:TextBox runat="server" ID="tbIcerik" TextMode="MultiLine" CssClass="auto topDir"></asp:TextBox>
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
            <div class="table" runat="server">
                <div class="head">
                    <h5 class="iFrames">Projeler & Hizmetler</h5>
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
                        <asp:Repeater ID="rptProj_Hizmet" runat="server" OnItemCommand="rptProj_Hizmet_ItemCommand">
                            <ItemTemplate>
                                <tr class="gradeA even">
                                    <td><%# Eval("BASLIK") %></td>
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
