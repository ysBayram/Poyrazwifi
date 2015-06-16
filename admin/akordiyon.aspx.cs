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
    public partial class akordiyon : System.Web.UI.Page
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
                    AKKOR mst = AKKORCRUD.IdyeGoreAKKORGetir(AddEdit);
                    tbBaslik.Text = mst.BASLIK;
                    tbIcerik.Text = mst.ICERIK;
                }
                AKGetir();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            try
            {
                AKKOR mn = new AKKOR();
                mn.BASLIK = tbBaslik.Text;
                mn.ICERIK = tbIcerik.Text;
                if (AddEdit == 0)
                {
                    AKKORCRUD.Kaydet(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                    AKGetir();
                }
                else
                {
                    mn.ID = AddEdit;
                    AKKORCRUD.Guncelle(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                    AKGetir();
                }

            }
            catch
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;
        }

        protected void AKGetir()
        {
            Tools.rptDoldur("SELECT * FROM AKKOR", rptAkordiyon);
        }

        protected void rptAkordiyon_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil") { AKKORCRUD.Sil(Convert.ToInt32(e.CommandArgument)); AKGetir(); }
            if (e.CommandName == "Edit") { Response.Redirect("akordiyon.aspx?id=" + e.CommandArgument); }
        }
    }
}