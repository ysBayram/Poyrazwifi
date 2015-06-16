using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WebPortal_v1.Entity;
using WebPortal_v1.Facade;

namespace WebPortal_v1.admin
{
    public partial class profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ADMIN admin = ADMINCRUD.IdyeGoreADMINGetir(1);

                tbK_Ad.Text = admin.K_AD;
                tbPass.Text = admin.SIFRE;
                tbMail.Text = admin.MAIL;
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                ADMIN admin = ADMINCRUD.IdyeGoreADMINGetir(1);
                admin.K_AD = tbK_Ad.Text;
                admin.SIFRE = tbPass.Text;
                admin.MAIL = tbMail.Text;
                admin.ID = 1;
                ADMINCRUD.Guncelle(admin);
                HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");
                Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Profil Bilgileri Güncellendi.</p>";
                Sonuc.Visible = true;

            }
            catch
            {
                HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
                Sonuc.Visible = true;
            }
        }
    }
}