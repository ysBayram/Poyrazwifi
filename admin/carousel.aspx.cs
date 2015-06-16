using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WebPortal_v1.Facade;
using WebPortal_v1.Entity;

namespace WebPortal_v1.admin
{
    public partial class carousel : System.Web.UI.Page
    {
        int AddEdit = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                AddEdit = Convert.ToInt32(Request.QueryString["id"]);
            }
            else
            {
                AddEdit = 0;
            }

            if (!Page.IsPostBack)
            {
                if (AddEdit != 0)
                {
                    btnKaydet.Text = "Düzenle";
                    CARUSEL mst = CARUSELCRUD.IdyeGoreCARUSELGetir(AddEdit);
                    tbBaslik.Text = mst.BASLIK;
                }
                CRGetir();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            try
            {
                CARUSEL mn = new CARUSEL();
                mn.BASLIK = tbBaslik.Text;

                if (fuRes.HasFile)
                {
                    Tools.Dosya_Sil(mn.ICERIK);
                    mn.ICERIK = Tools.GaleriUpload(fuRes, "carousel");
                }

                if (AddEdit == 0)
                {
                    CARUSELCRUD.Kaydet(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                    CRGetir();
                }
                else
                {
                    mn.ID = AddEdit;
                    CARUSELCRUD.Guncelle(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                    CRGetir();
                }

            }
            catch
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;
        }

        protected void rptCarousel_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil") { CARUSELCRUD.Sil(Convert.ToInt32(e.CommandArgument)); CRGetir(); }
            if (e.CommandName == "Edit") { Response.Redirect("carousel.aspx?id=" + e.CommandArgument); }
        }

        protected void CRGetir()
        {
            Tools.rptDoldur("SELECT * FROM CARUSEL", rptCarousel);
        }
    }
}