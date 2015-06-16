using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebPortal_v1.Facade;

namespace WebPortal_v1
{
    public partial class iletisim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack){Session.Add("CountSent", 1);}
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            int say = (int)Session["CountSent"];

            if (!String.IsNullOrEmpty(name.Value) && !String.IsNullOrEmpty(email.Value) && !String.IsNullOrEmpty(message.Value))
            {
                if (say != 3)
                {
                    Tools.sendMail(name.Value, email.Value, "Web Sitesi İletişim", message.Value);
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
            }
            
        }
        
    }
}