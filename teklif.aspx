<%@ Page Title="Teklif Forumları" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="teklif.aspx.cs" Inherits="WebPortal_v1.teklif" %>

<%@ Register Src="~/user_controls/tarife.ascx" TagName="Tarife" TagPrefix="ucTarife" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript">
        function rbvalidate() {
            if ($('input[type=radio]:checked').size() == 0) { alert("Lütfen Tarife Seçiniz!"); }
        }</script>
    <script type="text/javascript">
        function SetUniqueRadioButton(nameregex, current) {
            re = new RegExp(nameregex);
            for (i = 0; i < document.forms[0].elements.length; i++) {
                elm = document.forms[0].elements[i]
                if (elm.type == 'radio') { elm.checked = false; }
            }
            current.checked = true;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
    <header class="page-header">
        <div class="wrapper">
            <h1 class="page-tittle">Teklif Forumları</h1>
        </div>
        <div class="page-header-decoration"></div>
    </header>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphOrtaAlan" runat="server"><br />
    <asp:CheckBox ID="cbBasvuru" runat="server" Text="Başvuru Talep Forumu" Font-Size="X-Large" AutoPostBack="true" Checked="true" OnCheckedChanged="cbBasvuru_CheckedChanged"/><br /><br />
    <asp:CheckBox ID="cbAriza" runat="server" Text="Arıza Tespit Talep Forumu" Font-Size="X-Large" AutoPostBack="true" OnCheckedChanged="cbAriza_CheckedChanged"/>
    <div id="content" class=" invent-content">
        <h3 id="baslik"></h3>
        <div class="column-1-2">
            <div class="full-width left" style="margin: 0px; padding: 0px;">
                <div class="default-form-fieldset">
                    <br />
                    <label><strong>İsim</strong></label>
                    <asp:RequiredFieldValidator ID="rfvName" ControlToValidate="name" runat="server" ErrorMessage="* Kontrol Ediniz!" CssClass="white-form-el-error"></asp:RequiredFieldValidator>
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

                    <label><strong>İrtibat No</strong></label>
                    <asp:RequiredFieldValidator ID="rfvTel" ControlToValidate="tel" runat="server" ErrorMessage="* Kontrol Ediniz!" CssClass="white-form-el-error"></asp:RequiredFieldValidator>
                    <br />
                    <div class="around-input-background">
                        <div class="around-input-border">
                            <input type="text" runat="server" id="tel" value="" class="white-input-decoration white-focus-decoration full-width required" />
                        </div>
                    </div>

                    <label><strong>Adres</strong></label>
                    <asp:RequiredFieldValidator ID="rfvAdres" ControlToValidate="adres" runat="server" ErrorMessage="* Kontrol Ediniz!" CssClass="white-form-el-error"></asp:RequiredFieldValidator>
                    <br />
                    <div class="around-textarea-background">
                        <div class="around-textarea-border">
                            <textarea name="adres" id="adres" runat="server" class="white-textarea-decoration white-focus-decoration required" rows="3" cols="10"></textarea>
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
                <asp:Button ID="btnGonder" runat="server" CssClass="invent-button invent-button-default right" Style="height: auto;" Text="Gönder" OnClientClick="rbvalidate()" OnClick="btnGonder_Click" />
                <div class="clear"></div>
            </div>
        </div>
        <div class="column-1-2 column-last">
            <div class="table-decoration" id="TableTarife" runat="server">
                <h3>Faturasız Tarifeler</h3>
                <table>
                    <thead>
                        <tr>
                            <th><strong>Tarife Adı</strong></th>
                            <th><strong>Download / Upload</strong></th>
                            <th><strong>Kota</strong></th>
                            <th><strong>Fiyat</strong></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptFtarife" runat="server" OnItemDataBound="rptFtarife_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="rbtn" runat="server" GroupName="tarife" Text='<%# Eval("AD") %>' /></td>
                                    <td><%# Eval("DOWN") %> Mbit/<%# Eval("UP") %> Mbit</td>
                                    <td><%# Eval("KOTA") %> gb</td>
                                    <td><%# Eval("UCRET") %> TL</td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <h3>Simetrik Tarifeler</h3>
                <table>
                    <thead>
                        <tr>
                            <th><strong>Tarife Adı</strong></th>
                            <th><strong>Download / Upload</strong></th>
                            <th><strong>Kota</strong></th>
                            <th><strong>Fiyat</strong></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptStarife" runat="server" OnItemDataBound="rptStarife_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="rbtn" runat="server" GroupName="tarife" Text='<%# Eval("AD") %>' /></td>
                                    <td><%# Eval("DOWN") %> Mbit/<%# Eval("UP") %> Mbit</td>
                                    <td><%# Eval("KOTA") %> gb</td>
                                    <td><%# Eval("UCRET") %> TL</td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <div id="sagBanner" runat="server" style="display:none;">
                <div style="background-image:url('images/WebPortal/res/sayfa/banner.jpg'); height:580px; width:460px;">

                </div>
            </div>
        </div>
        <div class="clear"></div>        
    </div>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
