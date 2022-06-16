using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_SaveLink
{
    public class DBConnect
    {
        public SQLiteConnection _conn = new SQLiteConnection("Data Source = database.db; Version = 3; New = True; Compress = True;");
        public DBConnect()
        {
            try
            {
                _conn.Open();
                SQLiteCommand sQLiteCommand = _conn.CreateCommand();
                sQLiteCommand.CommandText = "CREATE TABLE IF NOT EXISTS 'DATA' ('ID' INTEGER NOT NULL, 'TITLE' TEXT NOT NULL, 'URL' TEXT NOT NULL, PRIMARY KEY('ID' AUTOINCREMENT));";
                sQLiteCommand.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
