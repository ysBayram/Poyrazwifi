using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class ADMINCRUD
    {
        public static void Kaydet(ADMIN p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into ADMIN(ID,K_AD,SIFRE,MAIL)values (@ID,@K_AD,@SIFRE,@MAIL)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@K_AD", p.K_AD);
            cm.Parameters.AddWithValue("@SIFRE", p.SIFRE);
            cm.Parameters.AddWithValue("@MAIL", p.MAIL);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(ADMIN p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update ADMIN set K_AD=@K_AD,SIFRE=@SIFRE,MAIL=@MAIL where ID=@ID");
            cm.Parameters.AddWithValue("@K_AD", p.K_AD);
            cm.Parameters.AddWithValue("@SIFRE", p.SIFRE);
            cm.Parameters.AddWithValue("@MAIL", p.MAIL);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from ADMIN where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static ADMIN IdyeGoreADMINGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from ADMIN where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ADMIN a = new ADMIN();
                a.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                a.K_AD = Convert.ToString(dt.Rows[0]["K_AD"]);
                a.SIFRE = Convert.ToString(dt.Rows[0]["SIFRE"]);
                a.MAIL = Convert.ToString(dt.Rows[0]["MAIL"]);
                return a;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from ADMIN", DBCon.BaglantiYap());
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
