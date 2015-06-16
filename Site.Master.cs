using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WebPortal_v1.Facade;
using WebPortal_v1.Entity;

using System.Drawing;

namespace WebPortal_v1
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public static string Anarenk;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AYAR ayar = AYARCRUD.IdyeGoreAYARGetir(1);
                Site_Title.Text = base.Page.Title + " || " + ayar.TITLE;

                HtmlMeta meta1 = new HtmlMeta();
                meta1.Name = "Description";
                meta1.Content = ayar.DESCR;
                this.Page.Header.Controls.Add(meta1);

                HtmlMeta meta2 = new HtmlMeta();
                meta2.Name = "Keywords";
                meta2.Content = ayar.KWORD;
                this.Page.Header.Controls.Add(meta2);

                Site_Logo.Src = ayar.LOGO;

                //Bitmap lg = new Bitmap(HttpContext.Current.Server.MapPath(ayar.LOGO.Substring(2)));
                //double oran = (double)(lg.Height) / (double)(lg.Width);
                //if (lg.Height > 275)
                //{
                //    Site_Logo.Height = 275;
                //}
                //if (lg.Width > 940)
                //{
                //    Site_Logo.Width = 940;   
                //}
                //if (lg.Height < 275 || lg.Width < 940)
                //{
                //    logo.Attributes.Add("style", "background: url('../images/backgrounds/2-white.jpg') top center fixed;");
                //}
                
                //Slogan.InnerText = ayar.SLOGAN;
                                                
                LiteralControl ltr = new LiteralControl();
                ltr.Text = "<style type=\"text/css\" rel=\"stylesheet\">" +
                            @"  /*Main color*/
                            .invent-content a, .post .entry-title a:hover, .invent-color, .invent-color-on-hover:hover, 
                            .widget_text a:hover, .widget_popular_posts a, .widget_twitter .all-tweets:hover, 
                            .widget_recent_comments a, .widget_archive a, .widget_categories a, 
                            .tab-style3 ul li a.current, .tab-style3 li a:hover, .twitter-carousel a, 
                            .invent-site-map .active, .sf-menu > li.sfHover>a , .sf-menu > li:hover >a, 
                            ul.sf-menu > li.current > a { 
	                            color: #"+@ayar.ANALYTC+@"; /* main color */
                            }

                            .home-page-header .nivo-controlNav a.active, .home-page-header .nivo-controlNav a:hover, .nav-decorator div,
                            .anythingSlider-minimalist-round .thumbNav .cur, .anythingSlider-minimalist-round .thumbNav a:hover, 
                            .scroll-to-top:hover, .lof-main-item-desc h3 a, .twitter-widget-carousel-bottom .fade-carousel-controls a:hover, 
                            .twitter-widget-carousel-bottom .fade-carousel-controls a.actual, .scroll-to-top:hover, .lof-main-item-desc h3 a,
                            .fancyslider-bullets a.active, .fancyslider-bullets a:hover, .invent-submit-decoration, .invent-big-color-icon-center { 
	                            background-color: #" + @ayar.ANALYTC + @"; /* main color */
                            }

                            .border-standard:hover, .lof-navigator li:hover img, ul.lof-navigator li.active img, .widget_flickr .border-standard:hover, 
                            .widget_popular_posts .border-standard:hover { 
	                            border-color: #" + @ayar.ANALYTC + @"; /* main color */
                            }

                            /*SLider background color*/
                            .home-page-slider-color {
	                            background-color: #" + @ayar.ANALYTC + @"; /* slider background color */
                            }
                    </style>
                    ";
                this.Page.Header.Controls.Add(ltr);
                
            }
        }
    }
}