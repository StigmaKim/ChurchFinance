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
            }
            catch(SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }

    }
}
