﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPortal_v1.Facade;

namespace WebPortal_v1.user_controls
{
    public partial class tarife : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Tools.rptDoldur("SELECT * FROM TARIFE WHERE TUR=1", rptFtarife);
                Tools.rptDoldur("SELECT * FROM TARIFE WHERE TUR=2", rptStarife);
            }
        }
    }
}