using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class MALI_BILGICRUD
    {
        public static void Kaydet(MALI_BILGI p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into MALI_BILGI(ID,VERGI_DAIRE,VERGI_NO,TIC_ODA,TIC_SICIL,LEVHA)values (@ID,@VERGI_DAIRE,@VERGI_NO,@TIC_ODA,@TIC_SICIL,@LEVHA)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@VERGI_DAIRE", p.VERGI_DAIRE);
            cm.Parameters.AddWithValue("@VERGI_NO", p.VERGI_NO);
            cm.Parameters.AddWithValue("@TIC_ODA", p.TIC_ODA);
            cm.Parameters.AddWithValue("@TIC_SICIL", p.TIC_SICIL);
            cm.Parameters.AddWithValue("@LEVHA", p.LEVHA);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(MALI_BILGI p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update MALI_BILGI set VERGI_DAIRE=@VERGI_DAIRE,VERGI_NO=@VERGI_NO,TIC_ODA=@TIC_ODA,TIC_SICIL=@TIC_SICIL,LEVHA=@LEVHA where ID=@ID");
            cm.Parameters.AddWithValue("@VERGI_DAIRE", p.VERGI_DAIRE);
            cm.Parameters.AddWithValue("@VERGI_NO", p.VERGI_NO);
            cm.Parameters.AddWithValue("@TIC_ODA", p.TIC_ODA);
            cm.Parameters.AddWithValue("@TIC_SICIL", p.TIC_SICIL);
            cm.Parameters.AddWithValue("@LEVHA", p.LEVHA);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from MALI_BILGI where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static MALI_BILGI IdyeGoreMALI_BILGIGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from MALI_BILGI where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                MALI_BILGI m = new MALI_BILGI();
                m.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                m.VERGI_DAIRE = Convert.ToString(dt.Rows[0]["VERGI_DAIRE"]);
                m.VERGI_NO = Convert.ToString(dt.Rows[0]["VERGI_NO"]);
                m.TIC_ODA = Convert.ToString(dt.Rows[0]["TIC_ODA"]);
                m.TIC_SICIL = Convert.ToString(dt.Rows[0]["TIC_SICIL"]);
                m.LEVHA = Convert.ToString(dt.Rows[0]["LEVHA"]);
                return m;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from MALI_BILGI", DBCon.BaglantiYap());
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
