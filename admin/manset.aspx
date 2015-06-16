<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="manset.aspx.cs" Inherits="WebPortal_v1.admin.manset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iSignPost">Manşet Yönetimi</h5>
        </div>
        <div class="rowElem">
            <label>Tür :</label><div class="formRight">
                <asp:DropDownList ID="ddlTur" runat="server" AutoPostBack="true" OnLoad="ddlTur_Load">
                    <asp:ListItem>Tür Seçiniz!</asp:ListItem>
                    <asp:ListItem>Resim</asp:ListItem>
                    <asp:ListItem>Video</asp:ListItem>
                    <asp:ListItem>Video + İçerik</asp:ListItem>
                </asp:DropDownList>
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
            <label>Link :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbLink" CssClass="topDir"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Resim :</label><div class="formRight">
                <asp:FileUpload ID="fuRes" runat="server" CssClass="topDir"/>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Video :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbVid" CssClass="topDir"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>İçerik :</label>
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
            <div class="table" id="TableMansetler" runat="server">
                <div class="head">
                    <h5 class="iFrames">Manşetler</h5>
                </div>
                <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">
                    <thead>
                        <tr>
                            <th>Başlık</th>
                            <th>Link</th>
                            <th>Düzenle</th>
                            <th>Sil</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptManset" runat="server" OnItemCommand="rptManset_ItemCommand">
                            <ItemTemplate>
                                <tr class="<%# rowStyle(Eval("TIP").ToString()) %>">
                                    <td><%# Eval("BASLIK") %></td>
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
