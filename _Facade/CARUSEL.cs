using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class CARUSELCRUD
    {
        public static void Kaydet(CARUSEL p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into CARUSEL(ID,BASLIK,ICERIK,LINK,TIP)values (@ID,@BASLIK,@ICERIK,@LINK,@TIP)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@TIP", p.TIP);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(CARUSEL p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update CARUSEL set BASLIK=@BASLIK,ICERIK=@ICERIK,LINK=@LINK,TIP=@TIP where ID=@ID");
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@TIP", p.TIP);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from CARUSEL where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static CARUSEL IdyeGoreCARUSELGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from CARUSEL where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                CARUSEL c = new CARUSEL();
                c.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                c.BASLIK = Convert.ToString(dt.Rows[0]["BASLIK"]);
                c.ICERIK = Convert.ToString(dt.Rows[0]["ICERIK"]);
                c.LINK = Convert.ToString(dt.Rows[0]["LINK"]);
                c.TIP = Convert.ToString(dt.Rows[0]["TIP"]);
                return c;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from CARUSEL", DBCon.BaglantiYap());
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
