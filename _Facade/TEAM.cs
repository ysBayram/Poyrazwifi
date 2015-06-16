using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class TEAMCRUD
    {
        public static void Kaydet(TEAM p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into TEAM(ID,ISIM,UNVAN,ACIKLAMA)values (@ID,@ISIM,@UNVAN,@ACIKLAMA)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@ISIM", p.ISIM);
            cm.Parameters.AddWithValue("@UNVAN", p.UNVAN);
            cm.Parameters.AddWithValue("@ACIKLAMA", p.ACIKLAMA);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(TEAM p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update TEAM set ISIM=@ISIM,UNVAN=@UNVAN,ACIKLAMA=@ACIKLAMA where ID=@ID");
            cm.Parameters.AddWithValue("@ISIM", p.ISIM);
            cm.Parameters.AddWithValue("@UNVAN", p.UNVAN);
            cm.Parameters.AddWithValue("@ACIKLAMA", p.ACIKLAMA);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from TEAM where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static TEAM IdyeGoreTEAMGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from TEAM where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                TEAM t = new TEAM();
                t.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                t.ISIM = Convert.ToString(dt.Rows[0]["ISIM"]);
                t.UNVAN = Convert.ToString(dt.Rows[0]["UNVAN"]);
                t.ACIKLAMA = Convert.ToString(dt.Rows[0]["ACIKLAMA"]);
                return t;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from TEAM", DBCon.BaglantiYap());
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
