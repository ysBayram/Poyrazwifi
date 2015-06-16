using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortal_v1.Entity;
using WebPortal_v1.Facade;

namespace WebPortal_v1.admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["anahtar"] == null || (string)Session["anahtar"] == "kapali")
            {
                Response.Redirect("login.aspx");
            }else if (!Page.IsPostBack)
            {
                spanAdmin.InnerText = "Hoşgeldin " + ADMINCRUD.IdyeGoreADMINGetir(1).K_AD;
            }
        }
    }
}