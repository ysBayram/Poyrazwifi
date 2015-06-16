using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortal_v1.Facade;
using WebPortal_v1.Entity;

namespace WebPortal_v1
{
    public partial class syf_detay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(RouteData.Values["ID"]);
            SAYFA s = SAYFACRUD.IdyeGoreSAYFAGetir(id);
            title1.InnerText = s.BASLIK;
            if (!String.IsNullOrEmpty(s.VIDEO))
            {
                divvideo.Attributes.Add("style", "display:block;");
                video.Attributes.Add("src", s.VIDEO);
            }

            if (!String.IsNullOrEmpty(s.FOTO))
            {
                divresim.Attributes.Add("style", "display:block;");
                resim1.Attributes.Add("src", s.FOTO);
                resim2.Attributes.Add("href", s.FOTO);
                resim2.Attributes.Add("title", s.BASLIK);
            }

            icerik.InnerHtml = s.ICERIK;

            Page.Title = s.BASLIK;

        }
    }
}