using System;
using System.Collections.Generic;
using System.Text;

namespace WebPortal_v1.Entity
{
    public class GALERI
    {
        public Int32 ID { get; set; }
        public String BASLIK { get; set; }
        public String LINK { get; set; }
        public String RES { get; set; }
        public Int32 ALBUM_ID { get; set; }
    }
}
