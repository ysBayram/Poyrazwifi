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
    public partial class ayar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AYAR ayar = AYARCRUD.IdyeGoreAYARGetir(1);
                Logo.HRef = ayar.LOGO;
                tbTitle.Text = ayar.TITLE;
                tbDescp.Text = ayar.DESCR;
                tbKeyWord.Text = ayar.KWORD;
                tbSlogan.Text = ayar.SLOGAN;
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            { 
                AYAR ayar = AYARCRUD.IdyeGoreAYARGetir(1);
                if (fuLogo.HasFile) {Tools.Dosya_Sil(ayar.LOGO); ayar.LOGO = Tools.GaleriUpload(fuLogo, ""); }
                ayar.TITLE = tbTitle.Text;
                ayar.DESCR = tbDescp.Text;
                ayar.KWORD = tbKeyWord.Text;
                ayar.SLOGAN = tbSlogan.Text;
                ayar.ANALYTC = Page.Request["colorpickerField"];
                ayar.ID = 1;
                AYARCRUD.Guncelle(ayar);
                HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");
                Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
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