using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class DESTECRUD
    {
        public static void Kaydet(DESTE p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into DESTE(ID,U_BASLIK,A_BASLIK,ICERIK,RES)values (@ID,@U_BASLIK,@A_BASLIK,@ICERIK,@RES)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@U_BASLIK", p.U_BASLIK);
            cm.Parameters.AddWithValue("@A_BASLIK", p.A_BASLIK);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@RES", p.RES);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(DESTE p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update DESTE set U_BASLIK=@U_BASLIK,A_BASLIK=@A_BASLIK,ICERIK=@ICERIK,RES=@RES where ID=@ID");
            cm.Parameters.AddWithValue("@U_BASLIK", p.U_BASLIK);
            cm.Parameters.AddWithValue("@A_BASLIK", p.A_BASLIK);
            cm.Parameters.AddWithValue("@ICERIK", p.ICERIK);
            cm.Parameters.AddWithValue("@RES", p.RES);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from DESTE where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static DESTE IdyeGoreDESTEGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from DESTE where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                DESTE d = new DESTE();
                d.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                d.U_BASLIK = Convert.ToString(dt.Rows[0]["U_BASLIK"]);
                d.A_BASLIK = Convert.ToString(dt.Rows[0]["A_BASLIK"]);
                d.ICERIK = Convert.ToString(dt.Rows[0]["ICERIK"]);
                d.RES = Convert.ToString(dt.Rows[0]["RES"]);
                return d;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from DESTE", DBCon.BaglantiYap());
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
