using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortal_v1.Facade;

namespace WebPortal_v1
{
    public partial class galeri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                Tools.rptDoldur("Select * From ALBUM Where TUR =" + Request.QueryString["tur"], rptAlbum);
            }
            else
            {
                Tools.rptDoldur("Select * From ALBUM", rptAlbum);
            }
            Tools.rptDoldur("Select * From GALERI", rptGaleri);
        }
    }
}