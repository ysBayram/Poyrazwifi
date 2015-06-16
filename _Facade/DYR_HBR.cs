using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class DYR_HBRCRUD
    {
        public static void Kaydet(DYR_HBR p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into DYR_HBR(ID,BASLIK,ICERIK,FOTO,VIDEO)values (@ID,@BASLIK,@ICERIK,@FOTO,@VIDEO)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@FOTO", p.FOTO);
            cm.Parameters.AddWithValue("@VIDEO", p.VIDEO);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(DYR_HBR p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update DYR_HBR set BASLIK=@BASLIK,ICERIK=@ICERIK,FOTO=@FOTO,VIDEO=@VIDEO where ID=@ID");
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@FOTO", p.FOTO);
            cm.Parameters.AddWithValue("@VIDEO", p.VIDEO);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from DYR_HBR where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static DYR_HBR IdyeGoreDYR_HBRGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from DYR_HBR where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                DYR_HBR d = new DYR_HBR();
                d.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                d.BASLIK = Convert.ToString(dt.Rows[0]["BASLIK"]);
                d.ICERIK = Convert.ToString(dt.Rows[0]["ICERIK"]);
                d.FOTO = Convert.ToString(dt.Rows[0]["FOTO"]);
                d.VIDEO = Convert.ToString(dt.Rows[0]["VIDEO"]);
                return d;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from DYR_HBR", DBCon.BaglantiYap());
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
