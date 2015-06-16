<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="profil.aspx.cs" Inherits="WebPortal_v1.admin.profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/plugins/forms/old_Validate/jquery-1.6.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iAdminUser">Profil</h5>
        </div>
        <div class="rowElem">
            <label>Kullanıcı Ad :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbK_Ad" CssClass="validate[required]"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Şifre :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbPass" CssClass="validate[required]" TextMode="Password"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Mail :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbMail" CssClass="validate[required]"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <asp:Button runat="server" ID="btnKaydet" Text="Kaydet" CssClass="nomargin submitForm redBtn" OnClick="btnKaydet_Click" />
            <div class="fix"></div>
        </div>
    </div>
</asp:Content>
