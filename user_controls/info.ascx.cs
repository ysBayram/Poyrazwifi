using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortal_v1.Entity;
using WebPortal_v1.Facade;

namespace WebPortal_v1.user_controls.Iletisim
{
    public partial class info : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ILETISIM info = ILETISIMCRUD.IdyeGoreILETISIMGetir(1);
                isim.InnerText = info.ISIM;
                adres.InnerText = info.ADRES;
                tel.InnerText = info.TEL;
                fax.InnerText = info.FAX;
                mail.InnerText = info.MAIL;
            }
        }
    }
}