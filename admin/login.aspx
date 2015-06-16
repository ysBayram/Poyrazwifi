<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebPortal_v1.admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <title>Yönetim Paneli | Giriş</title>

    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/css?family=Cuprum" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/custom.js"></script>

    <script src="js/plugins/forms/old_Validate/jquery-1.6.min.js" type="text/javascript"></script>
    <script src="js/plugins/forms/old_Validate/jquery.validationEngine-en.js" type="text/javascript" charset="utf-8"></script>
    <script src="js/plugins/forms/old_Validate/jquery.validationEngine.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#valid").validationEngine();
        });
    </script>
    <script type="text/javascript">
        function Gizle(obj) {
            obj = document.getElementById(obj);
            obj.style.display = 'none';
        }
    </script>
</head>

<body>

    <!-- Top navigation bar -->
    <div id="topNav">
        <div class="fixed">
            <div class="wrapper">
                <div class="backTo">
                    <a href="/" title="">
                        <img src="images/icons/topnav/mainWebsite.png" alt="" /><span>Websiteye Geri Dön</span></a>
                </div>
                <div class="fix"></div>
            </div>
        </div>
    </div>

    <!-- Login form area -->
    <div class="loginWrapper">
        <div class="loginLogo">
            <img src="images/loginLogo.png" alt="" />
        </div>
        <div class="loginPanel">
            <div class="head">
                <h5 class="iUser">Yönetici Girişi</h5>
            </div>
            <form id="valid" class="mainForm" runat="server">
                <fieldset>
                    <div class="loginRow noborder">
                        <label>Kullanıcı:</label>
                        <div class="loginInput">
                            <asp:TextBox type="text" name="login" id="tbK_Ad" runat="server" CssClass="validate[required]"></asp:TextBox>
                        </div>
                        <div class="fix"></div>
                    </div>

                    <div class="loginRow">
                        <label>Şifre:</label>
                        <div class="loginInput">
                            <asp:TextBox type="password" name="password" id="tbPass" runat="server" CssClass="validate[required]"></asp:TextBox>
                        </div>
                        <div class="fix"></div>
                    </div>

                    <div class="loginRow">
                        <asp:Button runat="server" type="submit" Text="Yönetim Paneline Giriş" CssClass="greyishBtn submitForm" id="btnGiris" OnClick="btnGiris_Click"></asp:Button>
                        <div class="fix"></div>
                        <div class="nNote nFailure hideit" runat="server" visible="false" id="divSonuc" onclick="javascript:Gizle('divSonuc');">
                            <p><strong>Kullanıcı Adı veya Şifre Hatalı!</strong><br />
                                İlgili Alanları Kontrol Ediniz!</p>
                        </div>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>

    <!-- Footer -->
    <div id="footer">
        <div class="wrapper">
            <span>&copy; Copyright 2013. Tüm hakları saklıdır. YSB was here :) <a href="#" title="">Mirza41</a></span>
        </div>
    </div>

</body>
</html>

