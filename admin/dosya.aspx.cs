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
    public partial class dosya : System.Web.UI.Page
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
                    DOSYA mst = DOSYACRUD.IdyeGoreDOSYAGetir(AddEdit);
                    tbBaslik.Text = mst.BASLIK;
                }
                DGetir();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            try
            {
                DOSYA mn = new DOSYA();
                mn.BASLIK = tbBaslik.Text;
                mn.LINK = Tools.Dosya_Upload(fuDosya);
                if (AddEdit == 0)
                {
                    DOSYACRUD.Kaydet(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                    DGetir();
                }
                else
                {
                    mn.ID = AddEdit;
                    DOSYACRUD.Guncelle(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                    DGetir();
                }

            }
            catch
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;
        }

        protected void DGetir()
        {
            Tools.rptDoldur("SELECT * FROM DOSYA", rptDosya);
        }

        protected void rptDosya_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Sil") { Tools.Dosya_Sil(DOSYACRUD.IdyeGoreDOSYAGetir(id).LINK); DOSYACRUD.Sil(id); DGetir(); }
            if (e.CommandName == "Edit") { Response.Redirect("dosya.aspx?id=" + e.CommandArgument); }
        }
    }
}