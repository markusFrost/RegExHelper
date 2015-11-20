using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExHelper
{
    public class DbMysqlHelper
    {
        private DbMysqlHelper() { }

        private static DbMysqlHelper instance;

        public static DbMysqlHelper getInstance()
        {
            if (instance == null)
            {
                instance = new DbMysqlHelper();
            }
            return instance;
        }

        static MySqlConnection myConn;
        public MySqlConnection getConnection(string dbName)
        {

            if (myConn != null) return myConn;

            string myConnection = "datasource=localhost;port=3306;username=admin;password=123456";

            try
            {
                 myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();

                string query = "select * from database." + dbName + " ;";

                myDataAdapter.SelectCommand = new MySqlCommand(query, myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
            }
            catch (Exception) { }

                return myConn;
        }

        public Dictionary<string, string> getMapColumns(List<string> listTables, string dbName, string patternConst)
        {
            MySqlConnection myConn = getConnection(dbName);

            myConn.Open();

            Dictionary<string, string> map = new Dictionary<string, string>();

            MySqlCommand comand = myConn.CreateCommand();

            MySqlDataReader reader;

            foreach (string tableName in listTables)
            {
               
                comand.CommandText = "show columns from " + dbName + "." + tableName;

                reader = comand.ExecuteReader();

                while (reader.Read())
                {
                    string columnName = reader["Field"].ToString();
                    string strValue = patternConst + " " + columnName.ToUpper() + " = " + "\"" + columnName + "\"" + ";" + "\n";
                    if (!map.ContainsKey(columnName))
                    {
                        map.Add(columnName, strValue);
                    }
                }
                reader.Close();

            }

            myConn.Close();

            return map;
        }

        public List<string> getTableNames( string dbName )
        {

            MySqlConnection myConn = getConnection( dbName );

            myConn.Open();

            MySqlCommand comand = myConn.CreateCommand();
            comand.CommandText = "select table_name from information_schema.tables where table_schema='" + dbName + "'";

            MySqlDataReader reader = comand.ExecuteReader();

            List<string> listTables = new List<string>();

            while (reader.Read())
            {
                string tableName = reader["table_name"].ToString();

                listTables.Add(tableName);
            }

            reader.Close();

            myConn.Close();

            return listTables;
        }
    }
}
