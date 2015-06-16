<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="multiup.aspx.cs" Inherits="WebPortal_v1.admin.multiup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <script type="text/javascript">
        function ClientValidate(source, arguments) {
            if (arguments.Value == 0) {
                $.jGrowl('Lütfen Albüm Seçiniz', { sticky: true });
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }
        }
    </script>
    <div class="widget mainForm" style="margin-top: 0px;">
        <div class="head">
            <h5 class="iPreview">Toplu Resim Yönetimi</h5>
        </div>
        <div class="rowElem">
            <label>Albüm :</label><div class="formRight">
                <asp:CustomValidator ID="CustomValidator1" ControlToValidate="ddlAlbum" ClientValidationFunction="ClientValidate" runat="server" />
                <asp:DropDownList ID="ddlAlbum" runat="server"></asp:DropDownList>
            </div>
            <div class="fix"></div>
        </div>
    </div>
    <div class="widget" style="margin-top:-1px;">       
        <ul class="tabs">
            <li><a id="goTab1" href="#tab1">Toplu Resim Yükleme</a></li>
            <li><a id="goTab2" href="#tab2">Toplu Resim Silme</a></li>
        </ul>
            
        <div class="tab_container">
            <div id="tab1" class="tab_content">
                <div class="rowElem" id="divRes" runat="server">           
                    <label>Resim :</label>
                    <div class="formRight">
                        <asp:FileUpload ID="fuRes" runat="server" Multiple="Multiple" />
                    </div>
                    <div class="fix"></div>
                </div>
                <div class="rowElem">
                    <asp:Button runat="server" ID="btnUpload" Text="Yükle" CssClass="nomargin submitForm greenBtn" OnClick="btnUpload_Click" />
                    <div class="fix"></div>
                </div>
            </div>
            <div id="tab2" class="tab_content">
                <div class="rowElem">
                    <asp:Button runat="server" ID="btnListele" Text="Seçili Albümü Listele" CssClass="ml30 floatleft blueBtn" OnClick="btnListele_Click" />
                    <asp:Button runat="server" ID="btnDelete" Text="Sil" CssClass="ml30 floatleft redBtn" Enabled="False" OnClick="btnDelete_Click"/>
                    <div class="fix"></div>
                </div>
            </div>
        </div>	
        <div class="fix"></div>	 
    </div>

    <!-- Gallery -->
    <div class="widget first" id="divGaleri" runat="server" style="display: none;">
        <div class="head">
            <h5 class="iPreview">Galleri</h5>
        </div>
        <div class="pics">
            <ul>
                <asp:Repeater ID="rptGaleri" runat="server" OnItemCommand="rptGaleri_ItemCommand">
                    <ItemTemplate>
                        <li><a href="<%# Eval("LINK") %>" title="<%# Eval("BASLIK") %>" rel="prettyPhoto">
                            <img src="<%# Eval("RES") %>" alt="" width="100" height="100" /></a>
                            <div class="actions">
                                <asp:ImageButton ID="IbtnSil" runat="server" CommandName="Sil" CommandArgument='<%# Eval("ID") %>' ImageUrl="~/admin/images/delete.png" OnClientClick="return confirm('Silme işlemini onaylıyor musunuz?');" />
                                <asp:CheckBox ID="cbGaleri" runat="server" />
                            </div>
                            <asp:Literal ID="ltID" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Literal>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="fix"></div>
        </div>

    </div>

</asp:Content>
