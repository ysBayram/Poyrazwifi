using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class MENUCRUD
    {
        public static void Kaydet(MENU p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into MENU(ID,ISIM,LINK,ALT,UST_ID)values (@ID,@ISIM,@LINK,@ALT,@UST_ID)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@ISIM", p.ISIM);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@ALT", p.ALT);
            cm.Parameters.AddWithValue("@UST_ID", p.UST_ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(MENU p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update MENU set ISIM=@ISIM,LINK=@LINK,ALT=@ALT,UST_ID=@UST_ID where ID=@ID");
            cm.Parameters.AddWithValue("@ISIM", p.ISIM);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@ALT", p.ALT);
            cm.Parameters.AddWithValue("@UST_ID", p.UST_ID);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from MENU where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static MENU IdyeGoreMENUGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from MENU where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                MENU a = new MENU();
                a.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                a.ISIM = Convert.ToString(dt.Rows[0]["ISIM"]);
                a.LINK = Convert.ToString(dt.Rows[0]["LINK"]);
                a.ALT = Convert.ToString(dt.Rows[0]["ALT"]);
                a.UST_ID = Convert.ToInt32(dt.Rows[0]["UST_ID"]);
                return a;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from MENU", DBCon.BaglantiYap());
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
