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
    public partial class iletisim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ILETISIM info = ILETISIMCRUD.IdyeGoreILETISIMGetir(1);
                tbIsim.Text = info.ISIM;
                tbTel.Text = info.TEL;
                tbFax.Text = info.FAX;
                tbMail.Text = info.TEL;
                tbAdres.Text = info.ADRES;
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                ILETISIM info = ILETISIMCRUD.IdyeGoreILETISIMGetir(1);
                info.ISIM = tbIsim.Text;
                info.TEL = tbTel.Text;
                info.FAX = tbFax.Text;
                info.MAIL = tbMail.Text;
                info.ADRES = tbAdres.Text;
                info.ID = 1;
                ILETISIMCRUD.Guncelle(info);
                HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");
                Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Ayar Bilgileri Güncellendi.</p>";
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