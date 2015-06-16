using System;
using System.Collections.Generic;
using System.Text;
using WebPortal_v1.Entity;
using WebPortal_v1.Provider;
using System.Data;
using System.Data.SQLite;

namespace WebPortal_v1.Facade
{
    public class ILETISIMCRUD
    {
        public static void Kaydet(ILETISIM p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("insert into ILETISIM(ID,ISIM,ADRES,TEL,FAX,MAIL)values (@ID,@ISIM,@ADRES,@TEL,@FAX,@MAIL)");
            cm.Parameters.AddWithValue("@ID", null);
            cm.Parameters.AddWithValue("@ISIM", p.ISIM);
            cm.Parameters.AddWithValue("@ADRES", p.ADRES);
            cm.Parameters.AddWithValue("@TEL", p.TEL);
            cm.Parameters.AddWithValue("@FAX", p.FAX);
            cm.Parameters.AddWithValue("@MAIL", p.MAIL);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Guncelle(ILETISIM p)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("update ILETISIM set ISIM=@ISIM,ADRES=@ADRES,TEL=@TEL,FAX=@FAX,MAIL=@MAIL where ID=@ID");
            cm.Parameters.AddWithValue("@ISIM", p.ISIM);
            cm.Parameters.AddWithValue("@ADRES", p.ADRES);
            cm.Parameters.AddWithValue("@TEL", p.TEL);
            cm.Parameters.AddWithValue("@FAX", p.FAX);
            cm.Parameters.AddWithValue("@MAIL", p.MAIL);
            cm.Parameters.AddWithValue("@ID", p.ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static void Sil(int ID)
        {
            SQLiteCommand cm = DBCon.KomutOlustur("delete from ILETISIM where ID=@ID");
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Connection.Open();
            cm.ExecuteNonQuery();
            cm.Connection.Close();
        }


        public static ILETISIM IdyeGoreILETISIMGetir(int ID)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from ILETISIM where ID=@ID", DBCon.BaglantiYap());
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ILETISIM ý = new ILETISIM();
                ý.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                ý.ISIM = Convert.ToString(dt.Rows[0]["ISIM"]);
                ý.ADRES = Convert.ToString(dt.Rows[0]["ADRES"]);
                ý.TEL = Convert.ToString(dt.Rows[0]["TEL"]);
                ý.FAX = Convert.ToString(dt.Rows[0]["FAX"]);
                ý.MAIL = Convert.ToString(dt.Rows[0]["MAIL"]);
                return ý;
            }
            else { return null; }
        }


        public static DataTable TumunuGetirDataTable()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from ILETISIM", DBCon.BaglantiYap());
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
