using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class ALBUMCRUD
    {
        public static void Kaydet(ALBUM p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into ALBUM(ID,BASLIK,RES,TUR)values (@ID,@BASLIK,@RES,@TUR)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@RES", p.RES);
            cm.Parameters.AddWithValue("@TUR", p.TUR);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(ALBUM p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update ALBUM set BASLIK=@BASLIK,RES=@RES,TUR=@TUR where ID=@ID");
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@RES", p.RES);
            cm.Parameters.AddWithValue("@TUR", p.TUR);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from ALBUM where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static ALBUM IdyeGoreALBUMGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from ALBUM where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ALBUM a = new ALBUM();
                a.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                a.BASLIK = Convert.ToString(dt.Rows[0]["BASLIK"]);
                a.RES = Convert.ToString(dt.Rows[0]["RES"]);
                a.TUR = Convert.ToString(dt.Rows[0]["TUR"]);
                return a;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from ALBUM", DBCon.BaglantiYap());
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
