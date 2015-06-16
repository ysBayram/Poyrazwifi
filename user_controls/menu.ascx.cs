using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortal_v1.Entity;
using WebPortal_v1.Facade;

namespace WebPortal_v1.user_controls
{
    public partial class menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            menuGetir();
        }

        protected void menuGetir() { Tools.rptDoldur("SELECT * FROM MENU WHERE ALT=0", rptMenu); }

        protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rp = (Repeater)e.Item.FindControl("rptAltmenu");

            int ust_id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ID").ToString());

            if (Convert.ToInt32(MENUCRUD.TekDegerGetir("SELECT COUNT(*) FROM MENU WHERE UST_ID=" + ust_id)) != 0)
            {
                Tools.rptDoldur("SELECT * FROM MENU WHERE UST_ID=" + ust_id, rp);
            }

        }

    }
}