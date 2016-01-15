using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace UI
{
    class SQLite
    {
        SQLiteConnection m_dbConnection;
        SQLiteCommand cmd;

        public void ConnectToDB()
        {
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source=TestDB.sqlite;Version=3;");
                m_dbConnection.Open();
                Debug.WriteLine("Oepn DB Connection");
            }
            catch(SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }

        public void CloseDB()
        {
            try
            {
                m_dbConnection.Close();
                Debug.WriteLine("Close DB Connection");
            }
            catch(SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }
        public SQLiteCommand GetSQLCommand()
        {
            return new SQLiteCommand(m_dbConnection);
        }
        public void Execute(string sql)
        {
            ConnectToDB();
            cmd = GetSQLCommand();
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                CloseDB();
                return;
            }
            CloseDB();
            return;
        }
    }
}
