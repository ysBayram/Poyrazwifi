using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class YORUMCRUD
    {
        public static void Kaydet(YORUM p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into YORUM(ID,ISIM,MAIL,MESAJ,ONAY)values (@ID,@ISIM,@MAIL,@MESAJ,@ONAY)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@ISIM", p.ISIM);
            cm.Parameters.AddWithValue("@MAIL", p.MAIL);
            cm.Parameters.AddWithValue("@MESAJ", p.MESAJ);
            cm.Parameters.AddWithValue("@ONAY", p.ONAY);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(YORUM p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update YORUM set ISIM=@ISIM,MAIL=@MAIL,MESAJ=@MESAJ,ONAY=@ONAY where ID=@ID");
            cm.Parameters.AddWithValue("@ISIM", p.ISIM);
            cm.Parameters.AddWithValue("@MAIL", p.MAIL);
            cm.Parameters.AddWithValue("@MESAJ", p.MESAJ);
            cm.Parameters.AddWithValue("@ONAY", p.ONAY);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from YORUM where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static YORUM IdyeGoreYORUMGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from YORUM where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                YORUM y = new YORUM();
                y.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                y.ISIM = Convert.ToString(dt.Rows[0]["ISIM"]);
                y.MAIL = Convert.ToString(dt.Rows[0]["MAIL"]);
                y.MESAJ = Convert.ToString(dt.Rows[0]["MESAJ"]);
                y.ONAY = Convert.ToString(dt.Rows[0]["ONAY"]);
                return y;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from YORUM", DBCon.BaglantiYap());
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
