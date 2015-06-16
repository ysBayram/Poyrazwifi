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
    public partial class sayfa : System.Web.UI.Page
    {
        int AddEdit = 0;
        string tur = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["tur"]))
            {
                tur = Request.QueryString["tur"];
                if (tur == "0") { title.InnerText = "Sayfa Yönetimi"; title2.InnerText = "Sayfalar"; }
                if (tur == "1") { title.InnerText = "Duyuru & Haber Yönetimi"; title2.InnerText = "Duyurular & Haberler"; }
            }
            else
            {
                tur = "0";
            }

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
                    SAYFA mst = SAYFACRUD.IdyeGoreSAYFAGetir(AddEdit);
                    tbBaslik.Text = mst.BASLIK;
                    tbVid.Text = mst.VIDEO;
                    tbIcerik.InnerText = mst.ICERIK;
                }
                SayfaGetir();
            }
        }

        protected void SayfaGetir() { Tools.rptDoldur("SELECT * FROM SAYFA WHERE TUR=" + tur, rptSayfa); }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            try
            {
                SAYFA mn = new SAYFA();
                mn.BASLIK = tbBaslik.Text;
                if (!String.IsNullOrEmpty(tbVid.Text))
                {
                    mn.VIDEO = "http://www.youtube.com/embed/" + Tools.YoutubeID(tbVid.Text);
                }
                else
                {
                    mn.VIDEO = String.Empty;
                }
                mn.ICERIK = tbIcerik.InnerText;
                mn.TUR = tur;
                if (fuRes.HasFile) 
                { 
                    Tools.Dosya_Sil(mn.FOTO);
                    string konum = string.Empty;
                    if (tur == "0") { konum = "sayfa"; }
                    if (tur == "1") { konum = "duyuru"; }
                    mn.FOTO = Tools.GaleriUpload(fuRes, konum);
                }

                if (AddEdit == 0)
                {
                    SAYFACRUD.Kaydet(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                    SayfaGetir();
                }
                else
                {
                    if (!fuRes.HasFile)
                    {
                        mn.FOTO = SAYFACRUD.IdyeGoreSAYFAGetir(AddEdit).FOTO;
                    }

                    mn.ID = AddEdit;
                    SAYFACRUD.Guncelle(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                    SayfaGetir();
                }

            }
            catch
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;
        }

        protected void rptSayfa_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                Tools.Dosya_Sil(SAYFACRUD.IdyeGoreSAYFAGetir(Convert.ToInt32(e.CommandArgument)).FOTO);
                SAYFACRUD.Sil(Convert.ToInt32(e.CommandArgument)); SayfaGetir();
            }
            if (e.CommandName == "Edit") { Response.Redirect("sayfa.aspx?id=" + e.CommandArgument + "&tur=" + tur); }
        }
    }
}