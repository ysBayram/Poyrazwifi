using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class DOSYACRUD
    {
        public static void Kaydet(DOSYA p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into DOSYA(ID,BASLIK,LINK)values (@ID,@BASLIK,@LINK)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(DOSYA p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update DOSYA set BASLIK=@BASLIK,LINK=@LINK where ID=@ID");
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from DOSYA where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static DOSYA IdyeGoreDOSYAGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from DOSYA where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                DOSYA d = new DOSYA();
                d.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                d.BASLIK = Convert.ToString(dt.Rows[0]["BASLIK"]);
                d.LINK = Convert.ToString(dt.Rows[0]["LINK"]);
                return d;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from DOSYA", DBCon.BaglantiYap());
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
