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
    public partial class multiup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Tools.ddlDoldur("SELECT * FROM ALBUM WHERE TUR=1", ddlAlbum, "BASLIK", "ID");
                ddlAlbum.Items.Insert(0, new ListItem("Lütfen Albüm Seçiniz", "0"));
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            if (fuRes.HasFile)
            {
                Tools.multiup(Request.Files, "galeri", ddlAlbum);

                Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>İşlem Başarı İle Sonuçlanmıştır.</p>";

                Tools.rptDoldur("SELECT * FROM GALERI ORDER BY ID DESC LIMIT " + Request.Files.Count, rptGaleri);
                divGaleri.Attributes.Add("style", "display:block;");
            }
            else
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Kaydedilemedi. Lütfen Resim Seçiniz!</p>";
            }

            Sonuc.Visible = true;
                        
        }

        protected void rptGaleri_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            if (e.CommandName == "Sil")
            {
                Int32 id = Convert.ToInt32(e.CommandArgument);
                Tools.Dosya_Sil(GALERICRUD.IdyeGoreGALERIGetir(id).RES);
                GALERICRUD.Sil(id);
                Tools.rptDoldur("SELECT * FROM GALERI WHERE ALBUM_ID=" + ddlAlbum.SelectedValue + " ORDER BY ID DESC", rptGaleri);
                Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>İşlem Başarı İle Sonuçlanmıştır.</p>";
            }
            else
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>İşlem Sırasında Bir Hata Oluştu!</p>";
            }
            Sonuc.Visible = true;
        }

        protected void btnListele_Click(object sender, EventArgs e)
        {
            Tools.rptDoldur("SELECT * FROM GALERI WHERE ALBUM_ID="+ ddlAlbum.SelectedValue +" ORDER BY ID DESC" , rptGaleri);
            divGaleri.Attributes.Add("style", "display:block;");
            btnDelete.Enabled = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            Tools.multidel(rptGaleri, "cbGaleri", "ltID");
            Tools.rptDoldur("SELECT * FROM GALERI WHERE ALBUM_ID=" + ddlAlbum.SelectedValue + " ORDER BY ID DESC", rptGaleri);

            Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
            Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>İşlem Başarı İle Sonuçlanmıştır.</p>";
            Sonuc.Visible = true;
        }
        
    }
}