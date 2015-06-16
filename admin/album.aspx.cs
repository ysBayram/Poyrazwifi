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
    public partial class album : System.Web.UI.Page
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
                    ALBUM mst = ALBUMCRUD.IdyeGoreALBUMGetir(AddEdit);
                    tbBaslik.Text = mst.BASLIK;
                    ddlTur.SelectedIndex = (Convert.ToInt32(mst.TUR)) + 1;
                }
                AlbumGetir();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            try
            {
                ALBUM mn = new ALBUM();
                mn.BASLIK = tbBaslik.Text;
                mn.TUR = Convert.ToString(((ddlTur.SelectedIndex) - 1));
                if (fuRes.HasFile) { Tools.Dosya_Sil(mn.RES); mn.RES = Tools.GaleriUpload(fuRes, "album"); }

                if (AddEdit == 0)
                {
                    if (ddlTur.SelectedIndex != 0)
                    {                        
                        ALBUMCRUD.Kaydet(mn);
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                        AlbumGetir();
                    }
                    else
                    {
                        Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                        Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Lütfen Tür Seçiniz!</p>";
                    }
                }
                else
                {
                    if (!fuRes.HasFile)
                    {
                        mn.RES = ALBUMCRUD.IdyeGoreALBUMGetir(AddEdit).RES;
                    }

                    if (ddlTur.SelectedIndex != 0)
                    {
                        mn.ID = AddEdit;
                        ALBUMCRUD.Guncelle(mn);
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                        AlbumGetir();
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

        protected void rptAlbum_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                Tools.Dosya_Sil(ALBUMCRUD.IdyeGoreALBUMGetir(Convert.ToInt32(e.CommandArgument)).RES);
                ALBUMCRUD.Sil(Convert.ToInt32(e.CommandArgument)); AlbumGetir();
            }
            if (e.CommandName == "Edit") { Response.Redirect("album.aspx?id=" + e.CommandArgument); }
        }

        protected void AlbumGetir()
        {
            Tools.rptDoldur("SELECT * FROM ALBUM", rptAlbum);
        }

        protected void ddlTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTur.SelectedIndex == 0) { ddlTur.SelectedIndex = 1; }
        }

        protected string rowStyle(string tur)
        {
            if (tur == "2")
            {return "Video";}
            else { return "Resim"; }
        }


    }
}