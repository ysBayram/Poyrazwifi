using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class MANSETCRUD
    {
        public static void Kaydet(MANSET p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into MANSET(ID,BASLIK,LINK,ICERIK,RES,VID,TIP)values (@ID,@BASLIK,@LINK,@ICERIK,@RES,@VID,@TIP)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@RES", p.RES);
            cm.Parameters.AddWithValue("@VID", p.VID);
            cm.Parameters.AddWithValue("@TIP", p.TIP);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(MANSET p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update MANSET set BASLIK=@BASLIK,LINK=@LINK,ICERIK=@ICERIK,RES=@RES,VID=@VID,TIP=@TIP where ID=@ID");
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@RES", p.RES);
            cm.Parameters.AddWithValue("@VID", p.VID);
            cm.Parameters.AddWithValue("@TIP", p.TIP);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from MANSET where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static MANSET IdyeGoreMANSETGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from MANSET where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                MANSET m = new MANSET();
                m.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                m.BASLIK = Convert.ToString(dt.Rows[0]["BASLIK"]);
                m.LINK = Convert.ToString(dt.Rows[0]["LINK"]);
                m.ICERIK = Convert.ToString(dt.Rows[0]["ICERIK"]);
                m.RES = Convert.ToString(dt.Rows[0]["RES"]);
                m.VID = Convert.ToString(dt.Rows[0]["VID"]);
                m.TIP = Convert.ToString(dt.Rows[0]["TIP"]);
                return m;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from MANSET", DBCon.BaglantiYap());
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
