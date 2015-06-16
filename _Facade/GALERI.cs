using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class GALERICRUD
    {
        public static void Kaydet(GALERI p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into GALERI(ID,BASLIK,LINK,RES,ALBUM_ID)values (@ID,@BASLIK,@LINK,@RES,@ALBUM_ID)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@RES", p.RES);
            cm.Parameters.AddWithValue("@ALBUM_ID", p.ALBUM_ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(GALERI p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update GALERI set BASLIK=@BASLIK,LINK=@LINK,RES=@RES,ALBUM_ID=@ALBUM_ID where ID=@ID");
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@RES", p.RES);
            cm.Parameters.AddWithValue("@ALBUM_ID", p.ALBUM_ID);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from GALERI where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static GALERI IdyeGoreGALERIGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from GALERI where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                GALERI g = new GALERI();
                g.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                g.BASLIK = Convert.ToString(dt.Rows[0]["BASLIK"]);
                g.LINK = Convert.ToString(dt.Rows[0]["LINK"]);
                g.RES = Convert.ToString(dt.Rows[0]["RES"]);
                g.ALBUM_ID = Convert.ToInt32(dt.Rows[0]["ALBUM_ID"]);
                return g;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from GALERI", DBCon.BaglantiYap());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return dt;
            }
            else { return null; }
        }


        public static DataTable KayitKumesiGetir(string sql)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, DBCon.BaglantiYap());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return dt;
            }
            else { return null; }
        }


        public static object TekDegerGetir(string sql)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, DBCon.BaglantiYap());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                return (object)dt.Rows[0][0];
            }
            else { return null; }
        }


    }
}
