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
    public partial class social : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Tools.ddlDoldur("Select * From SOCIAL", ddlTur, "TUR", "ID");
            }
        }

        protected void ddlTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            SOCIAL sc = SOCIALCRUD.IdyeGoreSOCIALGetir(Convert.ToInt16(ddlTur.SelectedValue));
            if (sc.ACTIVE == "true") { cbActive.Checked = true; } else { cbActive.Checked = false; }
            tbLink.Text = sc.LINK;
            ddlTur.DataBind();
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SOCIAL sc = new SOCIAL();
                sc.ID = Convert.ToInt16(ddlTur.SelectedValue);
                sc.TUR = ddlTur.SelectedItem.ToString().ToLower();
                sc.LINK = tbLink.Text;
                if (cbActive.Checked && !(String.IsNullOrEmpty(tbLink.Text))) { sc.ACTIVE = "true"; } else { sc.ACTIVE = "false"; }
                SOCIALCRUD.Guncelle(sc);
                HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");
                Sonuc.Attributes.Add("class", "nNote nSuccess hideit");
                Sonuc.InnerHtml = "<p><strong>BAŞARILI: </strong>Bilgiler Güncellendi.</p>";
                Sonuc.Visible = true;
            }
            catch
            {
                HtmlGenericControl Sonuc = (HtmlGenericControl)Master.FindControl("divSonuc");
                Sonuc.Attributes.Add("class", "nNote nFailure hideit");
                Sonuc.InnerHtml = "<p><strong>HATALI: </strong>Bilgiler Güncellenemedi.</p>";
                Sonuc.Visible = true;

            }
        }
    }
}