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
    public partial class proj_hizmet : System.Web.UI.Page
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
                    PROJ_HIZMET mst = PROJ_HIZMETCRUD.IdyeGorePROJ_HIZMETGetir(AddEdit);
                    tbBaslik.Text = mst.BASLIK;
                    tbIcerik.Text = mst.ICERIK;
                    rbtnRes.SelectedIndex = IndexSec(mst.RES);
                }
                PHGetir();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            try
            {
                PROJ_HIZMET mn = new PROJ_HIZMET();
                mn.BASLIK = tbBaslik.Text;
                mn.ICERIK = tbIcerik.Text;
                mn.RES = ResSec(rbtnRes.SelectedIndex);
                if (AddEdit == 0)
                {
                    PROJ_HIZMETCRUD.Kaydet(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                    PHGetir();
                }
                else
                {
                    mn.ID = AddEdit;
                    PROJ_HIZMETCRUD.Guncelle(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                    PHGetir();
                }

            }
            catch
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;
        }

        protected void PHGetir()
        {
            Tools.rptDoldur("SELECT * FROM PROJ_HIZMET", rptProj_Hizmet);
        }

        protected void rptProj_Hizmet_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil") { PROJ_HIZMETCRUD.Sil(Convert.ToInt32(e.CommandArgument)); PHGetir(); }
            if (e.CommandName == "Edit") { Response.Redirect("proj_hizmet.aspx?id=" + e.CommandArgument); }
        }

        protected string ResSec(int index)
        {
            switch (index)
            {
                case 0: return "../images/icons/big/coffee.png";
                case 1: return "../images/icons/big/help.png";
                case 2: return "../images/icons/big/settings.png";
                case 3: return "../images/icons/big/target.png";
                default: return "../images/icons/big/coffee.png";
            }
        }

        protected int IndexSec(string res)
        {
            switch (res)
            {
                case "../images/icons/big/coffee.png": return 0;
                case "../images/icons/big/help.png": return 1;
                case "../images/icons/big/settings.png": return 2;
                case "../images/icons/big/target.png": return 3;
                default: return 0;
            }
        }


    }

}