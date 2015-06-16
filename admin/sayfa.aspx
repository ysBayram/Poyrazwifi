<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="sayfa.aspx.cs" ValidateRequest ="false" Inherits="WebPortal_v1.admin.sayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iCreate" id="title" runat="server">Sayfa Yönetimi</h5>
        </div>
        <div class="rowElem">
            <label>Başlık :</label>
            <div class="formRight">
                <asp:TextBox runat="server" ID="tbBaslik"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Resim :</label><div class="formRight">
                <asp:FileUpload ID="fuRes" runat="server"/>
            </div>
            <div class="fix"></div>
        </div>
        <div class="rowElem">
            <label>Video :</label><div class="formRight">
                <asp:TextBox runat="server" ID="tbVid"></asp:TextBox>
            </div>
            <div class="fix"></div>
        </div>
        <div>            
            <fieldset>
                <div class="widget">    
                    <div class="head"><h5 class="iPencil">İçerik</h5></div>
                    <textarea class="wysiwyg" rows="5" cols="1" runat="server" ID="tbIcerik"></textarea>                
                </div>
            </fieldset>
        </div>
        <div class="rowElem">
            <asp:Button runat="server" ID="btnKaydet" Text="Kaydet" CssClass="nomargin submitForm redBtn" OnClick="btnKaydet_Click" />
            <div class="fix"></div>
        </div>
        <br />
    </div>
        <div class="rowElem" style="padding:0px;">
            <div id="divTable" class="table" runat="server">
                <div class="head">
                    <h5 class="iCreate" id="title2" runat="server">Sayfalar</h5>
                </div>
                <table cellpadding="0" cellspacing="0" border="0" class="display" id="example">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Başlık</th>
                            <th>LINK</th>                            
                            <th>Düzenle</th>
                            <th>Sil</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptSayfa" runat="server" OnItemCommand="rptSayfa_ItemCommand">
                            <ItemTemplate>
                                <tr class="gradeA even">                                    
                                    <td class="center"><%# Eval("ID") %></td>
                                    <td><%# Eval("BASLIK") %></td>
                                    <td class="center">
                                        <a onclick="$.jGrowl('detay-<%# Eval("BASLIK") %>-<%# Eval("ID") %>', { sticky: true , life: 10000 , header: 'Link Alt Satırdır!' });"><img alt="Link Al" title="Linki Oluşturmak İçin Tıklayınız!" src="images/icons/color/chain.png"/><img alt="Link Al" title="Linki Oluşturmak İçin Tıklayınız!" src="images/icons/color/chain.png"/></a>
                                    </td>
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
