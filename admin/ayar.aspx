<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="ayar.aspx.cs" Inherits="WebPortal_v1.admin.ayar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
    <script type="text/javascript" src="js/plugins/ui/prettyPhoto/jquery.prettyPhoto.js"></script>  
    <script src="js/plugins/ui/prettyPhoto/jquery.js" type="text/javascript" charset="utf-8"></script> 
    <link rel="stylesheet" href="css/prettyPhoto.css" type="text/css" media="screen" title="prettyPhoto main stylesheet" charset="utf-8" />
    <script type="text/javascript" charset="utf-8">
        $(document).ready(function () {
            $("a[rel^='prettyPhoto']").prettyPhoto({ social_tools: false });            
        });
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iCog3">Ayarlar</h5>
        </div>
        <div class="rowElem">
            <label>Logo :</label><div class="formRight">
                <asp:FileUpload ID="fuLogo" runat="server" />
                <a runat="server" id="Logo" rel="prettyPhoto">Logoyu incelemek için tıklayınız.</a>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Başlık :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbTitle"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Tanımlama :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbDescp"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Anahtar Kelimeler :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbKeyWord" TextMode="MultiLine" CssClass="auto"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Slogan :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbSlogan"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Tema Renk  :</label>
            <div class="formRight">
                <input type="text" class="colorpick" id="colorpickerField" name="colorpickerField" value="fd4b30" />
                <label for="colorpickerField" class="pick"></label>
                <div class="fix"></div> 
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <asp:Button runat="server" ID="btnKaydet" Text="Kaydet" CssClass="nomargin submitForm redBtn" OnClick="btnKaydet_Click" />
            <div class="fix"></div>
        </div>
    </div>
</asp:Content>
