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
    public partial class tarife : System.Web.UI.Page
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
                    TARIFE mst = TARIFECRUD.IdyeGoreTARIFEGetir(AddEdit);
                    tbAd.Text = mst.AD;
                    tbDown.Text = mst.DOWN;
                    tbUp.Text = mst.UP;
                    tbKota.Text = mst.KOTA;
                    tbUcret.Text = mst.UCRET;
                    if (mst.TUR == "1") { rbFtr.Checked = true; } else { rbStr.Checked = true; };
                }
                TARGetir();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            try
            {
                TARIFE mn = new TARIFE();
                mn.AD = tbAd.Text;
                mn.DOWN = tbDown.Text;
                mn.UP = tbUp.Text;
                mn.KOTA = tbKota.Text;
                mn.UCRET = tbUcret.Text;
                if (rbFtr.Checked) { mn.TUR = "1"; } else { mn.TUR = "2"; };

                if (AddEdit == 0)
                {
                    TARIFECRUD.Kaydet(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                }
                else
                {
                    mn.ID = AddEdit;
                    TARIFECRUD.Guncelle(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";                    
                }
                TARGetir();
            }
            catch
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;
        }

        protected void TARGetir()
        {
            Tools.rptDoldur("SELECT * FROM TARIFE", rptTarife);
        }

        protected void rptTarife_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil") { TARIFECRUD.Sil(Convert.ToInt32(e.CommandArgument)); TARGetir(); }
            if (e.CommandName == "Edit") { Response.Redirect("tarife.aspx?id=" + e.CommandArgument); }
        }
    }
}