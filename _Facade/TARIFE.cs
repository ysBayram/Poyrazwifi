using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class TARIFECRUD
    {
        public static void Kaydet(TARIFE p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into TARIFE(ID,AD,DOWN,UP,KOTA,UCRET,TUR)values (@ID,@AD,@DOWN,@UP,@KOTA,@UCRET,@TUR)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@AD", p.AD);
            cm.Parameters.AddWithValue("@DOWN", p.DOWN);
            cm.Parameters.AddWithValue("@UP", p.UP);
            cm.Parameters.AddWithValue("@KOTA", p.KOTA);
            cm.Parameters.AddWithValue("@UCRET", p.UCRET);
            cm.Parameters.AddWithValue("@TUR", p.TUR);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(TARIFE p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update TARIFE set AD=@AD,DOWN=@DOWN,UP=@UP,KOTA=@KOTA,UCRET=@UCRET,TUR=@TUR where ID=@ID");
            cm.Parameters.AddWithValue("@AD", p.AD);
            cm.Parameters.AddWithValue("@DOWN", p.DOWN);
            cm.Parameters.AddWithValue("@UP", p.UP);
            cm.Parameters.AddWithValue("@KOTA", p.KOTA);
            cm.Parameters.AddWithValue("@UCRET", p.UCRET);
            cm.Parameters.AddWithValue("@TUR", p.TUR);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from TARIFE where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static TARIFE IdyeGoreTARIFEGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from TARIFE where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                TARIFE a = new TARIFE();
                a.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                a.AD = Convert.ToString(dt.Rows[0]["AD"]);
                a.DOWN = Convert.ToString(dt.Rows[0]["DOWN"]);
                a.UP = Convert.ToString(dt.Rows[0]["UP"]);
                a.KOTA = Convert.ToString(dt.Rows[0]["KOTA"]);
                a.UCRET = Convert.ToString(dt.Rows[0]["UCRET"]);
                a.TUR = Convert.ToString(dt.Rows[0]["TUR"]);
                return a;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from TARIFE", DBCon.BaglantiYap());
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
