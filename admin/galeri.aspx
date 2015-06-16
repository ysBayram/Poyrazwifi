<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="galeri.aspx.cs" Inherits="WebPortal_v1.admin.galeri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iPreview">Galeri Yönetimi</h5>
        </div>
        <div class="rowElem">
            <label>Albüm :</label><div class="formRight">
                <asp:DropDownList ID="ddlAlbum" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAlbum_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem" id="divRes" runat="server">
            <label>Resim :</label>
            <div class="formRight">
                <asp:FileUpload ID="fuRes" runat="server"/>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem" id="divVid" runat="server">
            <label>Video :</label>
            <div class="formRight">
                <asp:TextBox runat="server" ID="tbVid" ></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Başlık :</label>
            <div class="formRight">
                <asp:TextBox runat="server" ID="tbBaslik"></asp:TextBox>
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
            <div class="table" id="TableMansetler" runat="server">
                <div class="head">
                    <h5 class="iFrames">Galeri Nesneleri</h5>
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
                        <asp:Repeater ID="rptGaleri" runat="server" OnItemCommand="rptGaleri_ItemCommand">
                            <ItemTemplate>
                                <tr class="<%# rowStyle(Eval("ALBUM_ID").ToString()) %>">
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
