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
    public partial class menu : System.Web.UI.Page
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
                    MENU mst = MENUCRUD.IdyeGoreMENUGetir(AddEdit);
                    tbIsim.Text = mst.ISIM;
                    tbLink.Text = mst.LINK;
                    rbtnKat.SelectedValue = mst.ALT;
                    if (mst.ALT == "1")
                    {
                        if (MENUCRUD.IdyeGoreMENUGetir(mst.UST_ID) != null)
                        {
                            ddlUstSec.SelectedValue = mst.UST_ID.ToString(); ddlUstSec.Visible = true;
                        }
                        else
                        {
                            Response.Write("<script>alert('Listelenen Kategorinin Bilgileri Hatalıdır! Lütfen Silip Yeniden Oluşturunuz!')</script>");
                        }
                    }
                }
                MenuGetir();
            }
        }

        protected void MenuGetir()
        {
            Tools.rptDoldur("SELECT * FROM MENU", rptMenu);
            Tools.ddlDoldur("SELECT * FROM MENU WHERE ALT=0", ddlUstSec, "ISIM", "ID");
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");

            try
            {
                MENU mn = new MENU();
                mn.LINK = tbLink.Text;
                mn.ISIM = tbIsim.Text;
                mn.ALT = rbtnKat.SelectedValue;
                if (rbtnKat.SelectedValue == "1") { mn.UST_ID = Convert.ToInt32(ddlUstSec.SelectedValue); }
                if (rbtnKat.SelectedValue == "0") { mn.UST_ID = 0; }

                if (AddEdit == 0)
                {
                    MENUCRUD.Kaydet(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Kaydedildi.</p>";
                    MenuGetir();
                }
                else
                {
                    mn.ID = AddEdit;
                    MENUCRUD.Guncelle(mn);
                    Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                    Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                    MenuGetir();
                }

            }
            catch
            {
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
            }

            Sonuc.Visible = true;
        }

        protected void rptMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil") { MENUCRUD.Sil(Convert.ToInt32(e.CommandArgument)); Response.Redirect("menu.aspx"); }
            if (e.CommandName == "Edit") { Response.Redirect("menu.aspx?id=" + e.CommandArgument); }
        }

        protected void rbtnKat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnKat.SelectedValue == "0") { ddlUstSec.Visible = false; }
            if (rbtnKat.SelectedValue == "1") { ddlUstSec.Visible = true; }
        }
    }
}