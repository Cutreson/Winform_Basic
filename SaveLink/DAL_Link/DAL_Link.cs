using DTO_SaveLink;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_SaveLink
{
    public class DAL_Link : DBConnect 
    {
        public DataTable getLink()
        {
            _conn.Open();
            string query = "SELECT * FROM DATA";
            SQLiteDataAdapter da = new SQLiteDataAdapter(query, _conn);
            DataTable dtLink = new DataTable();
            da.Fill (dtLink);
            return dtLink;
        }
        public bool addLink(DTO_Link link)
        {
            try
            {
                _conn.Open();
                string SQLite = string.Format("INSERT INTO DATA(TITLE, URL) VALUES ('{0}', '{1}')", link.Title, link.Url);
                SQLiteCommand cmd = new SQLiteCommand(SQLite, _conn);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool editLink(DTO_Link link)
        {
            try
            {
                _conn.Open();
                string SQLite = string.Format("UPDATE DATA SET TITLE = '{0}', URL = '{1}' WHERE ID = {3}", link.Title, link.Url, link.Id);
                SQLiteCommand cmd = new SQLiteCommand(SQLite, _conn);
                if(cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool deleteLink(int id)
        {
            try
            {
                _conn.Open();
                string SQLite = string.Format("DELETE FROM DATA WHERE ID = {0}", id);
                SQLiteCommand cmd = new SQLiteCommand(SQLite,_conn);
                if( cmd.ExecuteNonQuery() > 0)
                {
                    return true ;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}
