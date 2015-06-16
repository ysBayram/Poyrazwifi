using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace WebPortal_v1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("sayfa_detay", "detay-{BASLIK}-{ID}", "~/syf_detay.aspx");
            RouteTable.Routes.MapPageRoute("anasayfa", "Anasayfa", "~/default.aspx");
            RouteTable.Routes.MapPageRoute("galeri", "Galeri", "~/galeri.aspx");
            RouteTable.Routes.MapPageRoute("iletisim", "İletişim", "~/iletisim.aspx");
            RouteTable.Routes.MapPageRoute("teklif", "Teklif-Forumları", "~/teklif.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}