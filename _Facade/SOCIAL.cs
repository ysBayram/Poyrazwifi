using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class SOCIALCRUD
    {
        public static void Kaydet(SOCIAL p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into SOCIAL(ID,TUR,LINK,ACTIVE)values (@ID,@TUR,@LINK,@ACTIVE)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@TUR", p.TUR);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@ACTIVE", p.ACTIVE);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(SOCIAL p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update SOCIAL set TUR=@TUR,LINK=@LINK,ACTIVE=@ACTIVE where ID=@ID");
            cm.Parameters.AddWithValue("@TUR", p.TUR);
            cm.Parameters.AddWithValue("@LINK", p.LINK);
            cm.Parameters.AddWithValue("@ACTIVE", p.ACTIVE);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from SOCIAL where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static SOCIAL IdyeGoreSOCIALGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from SOCIAL where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                SOCIAL s = new SOCIAL();
                s.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                s.TUR = Convert.ToString(dt.Rows[0]["TUR"]);
                s.LINK = Convert.ToString(dt.Rows[0]["LINK"]);
                s.ACTIVE = Convert.ToString(dt.Rows[0]["ACTIVE"]);
                return s;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from SOCIAL", DBCon.BaglantiYap());
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
