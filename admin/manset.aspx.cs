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
    public partial class manset : System.Web.UI.Page
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
                    MANSET mst = MANSETCRUD.IdyeGoreMANSETGetir(AddEdit);
                    tbBaslik.Text = mst.BASLIK;
                    tbLink.Text = mst.LINK;
                    tbIcerik.Text = mst.ICERIK;
                    tbVid.Text = mst.VID;
                    ddlTur.SelectedIndex = Convert.ToInt16(mst.TIP);
                }
                mansetGetir();
            }

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            try
            {
                MANSET mn = new MANSET();
                mn.LINK = tbLink.Text;
                mn.BASLIK = tbBaslik.Text;
                mn.ICERIK = tbIcerik.Text;
                mn.VID = "http://www.youtube.com/embed/" + Tools.YoutubeID(tbVid.Text);

                if (AddEdit == 0)
                {
                    if (ddlTur.SelectedIndex != 0)
                    {
                        mn.TIP = ddlTur.SelectedIndex.ToString();
                        if (fuRes.HasFile) { Tools.Dosya_Sil(mn.RES); mn.RES = Tools.GaleriUpload(fuRes, "manset"); }
                        MANSETCRUD.Kaydet(mn);
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                        mansetGetir();
                    }
                    else
                    {
                        Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                        Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Lütfen Tür Seçiniz!</p>";
                    }
                }
                else
                {
                    if (fuRes.HasFile)
                    {
                        Tools.Dosya_Sil(mn.RES); mn.RES = Tools.GaleriUpload(fuRes, "manset");
                    }
                    else
                    {
                        mn.RES = MANSETCRUD.IdyeGoreMANSETGetir(AddEdit).RES;
                    }

                    if (ddlTur.SelectedIndex != 0)
                    {
                        mn.TIP = ddlTur.SelectedIndex.ToString();
                        mn.ID = AddEdit;
                        MANSETCRUD.Guncelle(mn);
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                        mansetGetir();
                    }
                    else
                    {
                        Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                        Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Lütfen Tür Seçiniz!</p>";
                    }
                }

            }
            catch
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;

        }

        protected void rptManset_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                Tools.Dosya_Sil(MANSETCRUD.IdyeGoreMANSETGetir(Convert.ToInt32(e.CommandArgument)).RES);
                MANSETCRUD.Sil(Convert.ToInt32(e.CommandArgument)); mansetGetir();
            }
            if (e.CommandName == "Edit") { Response.Redirect("manset.aspx?id=" + e.CommandArgument); }
        }

        protected void mansetGetir()
        {
            Tools.rptDoldur("SELECT * FROM MANSET ORDER BY ID DESC", rptManset);
        }

        protected string rowStyle(string tip)
        {
            switch (tip)
            {
                case "1": return "gradeA even";
                case "2": return "gradeC even";
                case "3": return "gradeX even";
                default: return "gradeA odd";
            }
        }

        protected void ddlTur_Load(object sender, EventArgs e)
        {
            if (ddlTur.SelectedIndex != 0)
            {
                tbBaslik.Attributes.Add("original-title", "Doldurulması GEREKLİ!");
            }
            else
            {
                tbBaslik.Attributes.Add("original-title", "Lütfen Tür Seçiniz!");
                tbIcerik.Attributes.Add("original-title", "Lütfen Tür Seçiniz!");
                tbLink.Attributes.Add("original-title", "Lütfen Tür Seçiniz!");
                fuRes.Attributes.Add("original-title", "Lütfen Tür Seçiniz!");
                tbVid.Attributes.Add("original-title", "Lütfen Tür Seçiniz!");
            }

            if (ddlTur.SelectedIndex == 1)
            {
                tbIcerik.Attributes.Add("original-title", "Doldurulması Gerekli DEĞİL!");
                tbLink.Attributes.Add("original-title", "Doldurulması GEREKLİ!");
                fuRes.Attributes.Add("original-title", "Doldurulması GEREKLİ!");
                tbVid.Attributes.Add("original-title", "Doldurulması Gerekli DEĞİL!");
            }

            if (ddlTur.SelectedIndex == 2)
            {
                tbIcerik.Attributes.Add("original-title", "Doldurulması Gerekli DEĞİL!");
                tbLink.Attributes.Add("original-title", "Doldurulması Gerekli DEĞİL!");
                fuRes.Attributes.Add("original-title", "Doldurulması Gerekli DEĞİL!");
                tbVid.Attributes.Add("original-title", "Doldurulması GEREKLİ!");
            }

            if (ddlTur.SelectedIndex == 3)
            {
                tbIcerik.Attributes.Add("original-title", "Doldurulması GEREKLİ!");
                tbLink.Attributes.Add("original-title", "Doldurulması GEREKLİ!");
                fuRes.Attributes.Add("original-title", "Doldurulması Gerekli DEĞİL!");
                tbVid.Attributes.Add("original-title", "Doldurulması Gerekli DEĞİL!");
            }
        }

    }
}