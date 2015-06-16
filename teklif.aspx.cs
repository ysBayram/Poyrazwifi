using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WebPortal_v1.Facade;

namespace WebPortal_v1
{
    public partial class teklif : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Tools.rptDoldur("SELECT * FROM TARIFE WHERE TUR=1", rptFtarife);
                Tools.rptDoldur("SELECT * FROM TARIFE WHERE TUR=2", rptStarife);
                Session.Add("CountSent", 1);
            }
        }

        protected void MailGonder(string tarife)
        {
            int say = (int)Session["CountSent"];

            if (!String.IsNullOrEmpty(name.Value) && !String.IsNullOrEmpty(email.Value) && !String.IsNullOrEmpty(message.Value))
            {
                if (say != 3)
                {
                    Tools.sendMail(name.Value, email.Value, "Başvuru Kaydı", name.Value + " isimli " + tel.Value + " numaralı şahıs \n" + adres.Value + "\n adresi için " + tarife + " paketine başvuruda bulunmuştur. \n Müşterinin kişisel Mesajı : " + message.Value);
                    say++;
                    Session.Add("CountSent", say);
                }
                else
                {
                    Response.Write("<script>alert('Güvenlik İhlali! Lütfen Daha Sonra Tekrar Deneyiniz.')</script>");
                }
                name.Value = String.Empty;
                email.Value = String.Empty;
                message.Value = String.Empty;
                tel.Value = String.Empty;
                adres.Value = String.Empty;
            }
            
        }

        protected void MailGonderAriza()
        {
            int say = (int)Session["CountSent"];

            if (!String.IsNullOrEmpty(name.Value) && !String.IsNullOrEmpty(email.Value) && !String.IsNullOrEmpty(message.Value))
            {
                if (say != 3)
                {
                    Tools.sendMail(name.Value, email.Value, "Arıza Tespit Kaydı", name.Value + " isimli " + tel.Value + " numaralı şahıs \n" + adres.Value + "\n adresi için Arıza Tespit başvursunda bulunmuştur. \n Müşterinin kişisel Mesajı : " + message.Value);
                    say++;
                    Session.Add("CountSent", say);
                }
                else
                {
                    Response.Write("<script>alert('Güvenlik İhlali! Lütfen Daha Sonra Tekrar Deneyiniz.')</script>");
                }
                name.Value = String.Empty;
                email.Value = String.Empty;
                message.Value = String.Empty;
                tel.Value = String.Empty;
                adres.Value = String.Empty;
            }

        }


        protected void btnGonder_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (cbBasvuru.Checked == true)
                {
                    if (Tarife(rptFtarife) != null)
                    {
                        MailGonder(Tarife(rptFtarife));
                    }

                    if (Tarife(rptStarife) != null)
                    {
                        MailGonder(Tarife(rptStarife));
                    }
                }

                if (cbAriza.Checked == true)
                {
                    MailGonderAriza();
                }
                
            }
        }

        protected void rptFtarife_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButton rrbtn = (RadioButton)e.Item.FindControl("rbtn");
                string script = "SetUniqueRadioButton('rptFtarife.*tarife',this)";
                rrbtn.Attributes.Add("onclick", script);
            }
        }

        protected void rptStarife_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                RadioButton rrbtn = (RadioButton)e.Item.FindControl("rbtn");
                string script = "SetUniqueRadioButton('rptStarife.*tarife',this)";
                rrbtn.Attributes.Add("onclick", script);
            }
        }

        protected string Tarife(Repeater rpt)
        {
            foreach (RepeaterItem item in rpt.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    RadioButton rrbtn = (RadioButton)item.FindControl("rbtn");
                    if (rrbtn != null && rrbtn.Checked)
                    {
                        return rrbtn.Text;
                    }
                }
            }
            return null;
        }

        protected void cbBasvuru_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked == true)
            {
                cbAriza.Checked = false;
                cbBasvuru.Checked = true;
                TableTarife.Attributes.Add("style", "display:block;");
                sagBanner.Attributes.Add("style", "display:none;");
            }
            else
            {
                cbAriza.Checked = true;
                cbBasvuru.Checked = false;
                TableTarife.Attributes.Add("style", "display:none;");
                sagBanner.Attributes.Add("style", "display:block;");
            }
            
        }

        protected void cbAriza_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked == true)
            {
                cbAriza.Checked = true;
                cbBasvuru.Checked = false;
                TableTarife.Attributes.Add("style", "display:none;");
                sagBanner.Attributes.Add("style", "display:block;");
            }
            else
            {
                cbAriza.Checked = false;
                cbBasvuru.Checked = true;
                TableTarife.Attributes.Add("style", "display:block;");
                sagBanner.Attributes.Add("style", "display:none;");
            }
        }
                
    }
}