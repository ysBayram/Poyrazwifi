<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="social.aspx.cs" Inherits="WebPortal_v1.admin.social" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">

    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iSignPost">Sosyal Ağlar</h5>
        </div>
        <div class="rowElem">
            <label>Tür :</label><div class="formRight">
                <asp:DropDownList ID="ddlTur" runat="server" OnSelectedIndexChanged="ddlTur_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:CheckBox ID="cbActive" runat="server" Text="Aktif" TextAlign="Left" CssClass="mr30 floatright" />
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
            <asp:Button runat="server" ID="btnKaydet" Text="Güncelle" CssClass="nomargin submitForm redBtn" OnClick="btnKaydet_Click" />
            <div class="fix"></div>
        </div>
    </div>

</asp:Content>
