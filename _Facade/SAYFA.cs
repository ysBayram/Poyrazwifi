using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class SAYFACRUD
    {
        public static void Kaydet(SAYFA p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into SAYFA(ID,BASLIK,FOTO,VIDEO,ICERIK,TUR)values (@ID,@BASLIK,@FOTO,@VIDEO,@ICERIK,@TUR)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@FOTO", p.FOTO);
            cm.Parameters.AddWithValue("@VIDEO", p.VIDEO);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@TUR", p.TUR);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(SAYFA p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update SAYFA set BASLIK=@BASLIK,FOTO=@FOTO,VIDEO=@VIDEO,ICERIK=@ICERIK,TUR=@TUR where ID=@ID");
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@FOTO", p.FOTO);
            cm.Parameters.AddWithValue("@VIDEO", p.VIDEO);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@TUR", p.TUR);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from SAYFA where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static SAYFA IdyeGoreSAYFAGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from SAYFA where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                SAYFA s = new SAYFA();
                s.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                s.BASLIK = Convert.ToString(dt.Rows[0]["BASLIK"]);
                s.FOTO = Convert.ToString(dt.Rows[0]["FOTO"]);
                s.VIDEO = Convert.ToString(dt.Rows[0]["VIDEO"]);
                s.ICERIK = Convert.ToString(dt.Rows[0]["ICERIK"]);
                s.TUR = Convert.ToString(dt.Rows[0]["TUR"]);
                return s;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from SAYFA", DBCon.BaglantiYap());
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
