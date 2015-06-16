using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class AYARCRUD
    {
        public static void Kaydet(AYAR p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into AYAR(ID,TITLE,DESCR,KWORD,LOGO,ANALYTC,SLOGAN)values (@ID,@TITLE,@DESCR,@KWORD,@LOGO,@ANALYTC,@SLOGAN)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@TITLE", p.TITLE);
            cm.Parameters.AddWithValue("@DESCR", p.DESCR);
            cm.Parameters.AddWithValue("@KWORD", p.KWORD);
            cm.Parameters.AddWithValue("@LOGO", p.LOGO);
            cm.Parameters.AddWithValue("@ANALYTC", p.ANALYTC);
            cm.Parameters.AddWithValue("@SLOGAN", p.SLOGAN);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(AYAR p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update AYAR set TITLE=@TITLE,DESCR=@DESCR,KWORD=@KWORD,LOGO=@LOGO,ANALYTC=@ANALYTC,SLOGAN=@SLOGAN where ID=@ID");
            cm.Parameters.AddWithValue("@TITLE", p.TITLE);
            cm.Parameters.AddWithValue("@DESCR", p.DESCR);
            cm.Parameters.AddWithValue("@KWORD", p.KWORD);
            cm.Parameters.AddWithValue("@LOGO", p.LOGO);
            cm.Parameters.AddWithValue("@ANALYTC", p.ANALYTC);
            cm.Parameters.AddWithValue("@SLOGAN", p.SLOGAN);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from AYAR where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static AYAR IdyeGoreAYARGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from AYAR where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                AYAR a = new AYAR();
                a.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                a.TITLE = Convert.ToString(dt.Rows[0]["TITLE"]);
                a.DESCR = Convert.ToString(dt.Rows[0]["DESCR"]);
                a.KWORD = Convert.ToString(dt.Rows[0]["KWORD"]);
                a.LOGO = Convert.ToString(dt.Rows[0]["LOGO"]);
                a.ANALYTC = Convert.ToString(dt.Rows[0]["ANALYTC"]);
                a.SLOGAN = Convert.ToString(dt.Rows[0]["SLOGAN"]);
                return a;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from AYAR", DBCon.BaglantiYap());
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
