using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
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
                //Debug.WriteLine("Oepn DB Connection");
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
                //Debug.WriteLine("Close DB Connection");
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
            catch(SQLiteException e) 
            {
                Debug.WriteLine("BUG!!!!!!!!!!!! " + e);
                CloseDB();
                return;
            }
            CloseDB();
            return;
        }

        public DataSet ExecuteSelectQuery(string sql)
        {
            ConnectToDB();
            cmd = GetSQLCommand();
            cmd.CommandText = string.Format(sql);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            return ds;
        }

        public int ExecuteSumQuery(string sql)
        {
            ConnectToDB();
            cmd = GetSQLCommand();
            cmd.CommandText = string.Format(sql);
            if( cmd.ExecuteScalar() is DBNull )
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }            
        }

        public string DateTimeSQLite(DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
        }

        public string DateTimeS(DateTime datetime)
        {
            string dateTimeFormat = "{0}-{1}-{2}";
            return string.Format(dateTimeFormat, datetime.Year, datetime.Month, datetime.Day);
        }
    }
}
