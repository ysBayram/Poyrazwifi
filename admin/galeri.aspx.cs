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
    public partial class galeri : System.Web.UI.Page
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
                GaleriGetir();
                if (AddEdit != 0)
                {
                    btnKaydet.Text = "Düzenle";
                    GALERI mst = GALERICRUD.IdyeGoreGALERIGetir(AddEdit);
                    tbBaslik.Text = mst.BASLIK;
                    tbLink.Text = mst.LINK;
                    ddlAlbum.SelectedValue = mst.ALBUM_ID.ToString();

                    switch (ALBUMCRUD.IdyeGoreALBUMGetir(mst.ALBUM_ID).TUR)
                    {
                        case "1": divVid.Attributes.Add("style", "display:none;"); divRes.Attributes.Add("style", "display:block;"); break;
                        case "2": divRes.Attributes.Add("style", "display:none;"); divVid.Attributes.Add("style", "display:block;"); tbVid.Text = mst.LINK; break;
                        case "0": if (ddlAlbum.SelectedItem.ToString() == "Resim") { divVid.Attributes.Add("style", "display:none;"); divRes.Attributes.Add("style", "display:block;"); } else if (ddlAlbum.SelectedItem.ToString() == "Video") { divRes.Attributes.Add("style", "display:none;"); divVid.Attributes.Add("style", "display:block;"); tbVid.Text = mst.LINK; }; break;
                    }
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            if (ddlAlbum.SelectedValue == "0") { ddlAlbum.SelectedValue = "1"; }
            string tur = ALBUMCRUD.IdyeGoreALBUMGetir(Convert.ToInt32(ddlAlbum.SelectedValue)).TUR;

            try
            {
                GALERI mn = new GALERI();
                mn.BASLIK = tbBaslik.Text;
                if (!String.IsNullOrEmpty(ddlAlbum.SelectedValue))
                {
                    mn.ALBUM_ID = Convert.ToInt32(ddlAlbum.SelectedValue);
                }
                else { mn.ALBUM_ID = 1; }
                                
                if (tur == "1")
                {
                    if (fuRes.HasFile)
                    {
                        Tools.Dosya_Sil(mn.RES);
                        mn.LINK = Tools.GaleriUpload(fuRes, "galeri");
                        mn.RES = mn.LINK;
                    }
                } 
                
                if (tur == "2" && !(String.IsNullOrEmpty(tbVid.Text)))
                {
                    mn.RES = "http://img.youtube.com/vi/" + Tools.YoutubeID(tbVid.Text) + "/hqdefault.jpg";
                    mn.LINK = "http://www.youtube.com/embed/" + Tools.YoutubeID(tbVid.Text);
                }

                if (AddEdit == 0)
                {
                    if ( fuRes.HasFile || !(String.IsNullOrEmpty(tbVid.Text)))
                    {
                        GALERICRUD.Kaydet(mn);
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";                        
                    }
                    else
                    {
                        Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                        Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Kaydedilemedi.</p>";
                    }
                    GaleriGetir();
                }
                else
                {
                    mn.ID = AddEdit;
                    if ( fuRes.HasFile || !(String.IsNullOrEmpty(tbVid.Text)))
                    {
                        GALERICRUD.Guncelle(mn);
                        Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                        Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                    }
                    else
                    {
                        Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                        Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
                    }
                    GaleriGetir();
                }

            }
            catch (Exception)
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;

        }

        protected void rptGaleri_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                Int32 id = Convert.ToInt32(e.CommandArgument);
                string tur = ALBUMCRUD.IdyeGoreALBUMGetir(GALERICRUD.IdyeGoreGALERIGetir(id).ALBUM_ID).TUR;
                if (tur == "1"){Tools.Dosya_Sil(GALERICRUD.IdyeGoreGALERIGetir(id).RES);}

                GALERICRUD.Sil(Convert.ToInt32(e.CommandArgument)); GaleriGetir();
            }
            if (e.CommandName == "Edit") { Response.Redirect("galeri.aspx?id=" + e.CommandArgument); }
        }

        protected void GaleriGetir()
        {
            Tools.rptDoldur("SELECT * FROM GALERI ORDER BY ID ASC", rptGaleri);
            Tools.ddlDoldur("SELECT * FROM ALBUM", ddlAlbum, "BASLIK", "ID");
            ddlAlbum.Items.Insert(0, new ListItem("Lütfen Albüm Seçiniz", "0"));
        }

        protected string rowStyle(string tip)
        {
            string tur = ALBUMCRUD.IdyeGoreALBUMGetir(Convert.ToInt32(tip)).TUR;
            if (tur == "2")
            { return "gradeX even"; }
            else { return "gradeC even"; }
        }

        protected void ddlAlbum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAlbum.SelectedValue == "0") { ddlAlbum.SelectedValue = "1"; }

            string tur = ALBUMCRUD.IdyeGoreALBUMGetir(Convert.ToInt32(ddlAlbum.SelectedValue)).TUR;
            
            if (tur == "1")
            {
                tbVid.Enabled = false;
                fuRes.Enabled = true;
            }
            if (tur == "2")
            {
                fuRes.Enabled = false;
                tbVid.Enabled = true;
            }

        }


    }
}