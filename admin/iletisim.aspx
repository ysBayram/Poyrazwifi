<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="WebPortal_v1.admin.iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iPhone">İletişim</h5>
        </div>
        <div class="rowElem">
            <label>İsim :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbIsim"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Tel :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbTel"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Fax :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbFax"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Mail :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbMail"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Adres :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbAdres" TextMode="MultiLine" CssClass="auto"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <asp:Button runat="server" ID="btnKaydet" Text="Kaydet" CssClass="nomargin submitForm redBtn" OnClick="btnKaydet_Click" />
            <div class="fix"></div>
        </div>
    </div>
</asp:Content>
