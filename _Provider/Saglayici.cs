using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace WebPortal_v1.Provider
{
    public class DBCon
    {
        public static SQLiteConnection BaglantiYap()
        {
            return new SQLiteConnection(@"Data Source=|DataDirectory|\Portal_DB.db");
        }
        public static SQLiteCommand KomutOlustur(string cmd)
        {
            return string.IsNullOrEmpty(cmd) ? null : new SQLiteCommand(cmd, BaglantiYap());
        }
    }
}
