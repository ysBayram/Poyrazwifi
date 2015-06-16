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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["exit"] == "1")
            {
                Session["anahtar"] = "kapali";
            }
            Page.Form.DefaultButton = btnGiris.UniqueID;
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            ADMIN admin = ADMINCRUD.IdyeGoreADMINGetir(1);

            if (tbK_Ad.Text == admin.K_AD && tbPass.Text == admin.SIFRE)
            {
                Session["anahtar"] = "acik";
                Response.Redirect("default.aspx");
            }
            else
            {
                divSonuc.Visible = true;
            }
        }
    }
}