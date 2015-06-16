using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class PROJ_HIZMETCRUD
    {
        public static void Kaydet(PROJ_HIZMET p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into PROJ_HIZMET(ID,BASLIK,ICERIK,LINK,RES)values (@ID,@BASLIK,@ICERIK,@LINK,@RES)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@RES", p.RES);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(PROJ_HIZMET p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update PROJ_HIZMET set BASLIK=@BASLIK,ICERIK=@ICERIK,LINK=@LINK,RES=@RES where ID=@ID");
            cm.Parameters.AddWithValue("@BASLIK", p.BASLIK);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@RES", p.RES);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from PROJ_HIZMET where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static PROJ_HIZMET IdyeGorePROJ_HIZMETGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from PROJ_HIZMET where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                PROJ_HIZMET c = new PROJ_HIZMET();
                c.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                c.BASLIK = Convert.ToString(dt.Rows[0]["BASLIK"]);
                c.ICERIK = Convert.ToString(dt.Rows[0]["ICERIK"]);
                c.LINK = Convert.ToString(dt.Rows[0]["LINK"]);
                c.RES = Convert.ToString(dt.Rows[0]["RES"]);
                return c;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from PROJ_HIZMET", DBCon.BaglantiYap());
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
