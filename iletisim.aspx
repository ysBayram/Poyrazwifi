<%@ Page Title="İletişim" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="WebPortal_v1.iletisim" %>

<%@ Register Src="~/user_controls/Social.ascx" TagName="Social_Network" TagPrefix="ucSocial" %>
<%@ Register Src="~/user_controls/info.ascx" TagName="Contact_Info" TagPrefix="ucInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript" src="js/map.js"></script>
    <script>
        jQuery(function ($) {
            initMap('map-canvas2', {
                lat: 40.717910,
                lng: 29.826866,
                zoom: 16,
                disableDefaultUI: false,
                type: google.maps.MapTypeId.ROADMAP,
                markers: [
					{
					    lat: 40.717910,
					    lng: 29.826866,
					    title: "PoyrazWifi"
					}
                ]
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
    <header class="page-header">
        <div class="wrapper">
            <h1 class="page-tittle">İletişim</h1>
        </div>
        <div class="page-header-decoration"></div>
    </header>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphOrtaAlan" runat="server">
    <div id="content" class=" invent-content">
        <div class="column-2-3">
            <div class="spacer"></div>
            <div class="border-standard map-margins">
                <div id="map-canvas2" class="map-canvas" style="height: 610px; width: 610px;"></div>
            </div>
        </div>
        <div class="column-1-3 column-last">
            <h4>İletişim Bilgileri</h4>
            <ucInfo:Contact_Info ID="ucInfo" runat="server"></ucInfo:Contact_Info>
            <h4>Sosyal Ağlarda <a class="invent-color">BİZ</a></h4>
            <ucSocial:Social_Network ID="ucSocial" runat="server" />
            <div class="full-width left" style="margin: 0px; padding: 0px;">
                <div class="default-form-fieldset">
                    <label><strong>İsim</strong></label>
                    <asp:RequiredFieldValidator ID="rfvName" ControlToValidate="name" runat="server" ErrorMessage="* Kontrol Ediniz!" CssClass="white-form-el-error" ></asp:RequiredFieldValidator>
                    <br />
                    <div class="around-input-background">
                        <div class="around-input-border">
                            <input type="text" runat="server" id="name" value="" class="white-input-decoration white-focus-decoration full-width required" />
                        </div>
                    </div>

                    <label><strong>E-mail</strong></label>
                    <asp:RequiredFieldValidator ID="rfvMail" ControlToValidate="email" runat="server" ErrorMessage="* Kontrol Ediniz!" CssClass="white-form-el-error"></asp:RequiredFieldValidator>
                    <br />
                    <div class="around-input-background">
                        <div class="around-input-border">
                            <input type="text" runat="server" id="email" value="" class="white-input-decoration white-focus-decoration full-width required" />
                        </div>
                    </div>

                    <label><strong>Mesaj</strong></label>
                    <asp:RequiredFieldValidator ID="rfvMessage" ControlToValidate="message" runat="server" ErrorMessage="* Kontrol Ediniz!" CssClass="white-form-el-error"></asp:RequiredFieldValidator>
                    <br />
                    <div class="around-textarea-background">
                        <div class="around-textarea-border">
                            <textarea name="message" id="message" runat="server" class="white-textarea-decoration white-focus-decoration required" rows="12" cols="10"></textarea>
                        </div>
                    </div>
                </div>

                <asp:Button ID="btnGonder" runat="server" OnClick="btnGonder_Click" CssClass="invent-button invent-button-default right" Style="height: auto;" Text="Gönder" />
                <div class="clear"></div>
            </div>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
