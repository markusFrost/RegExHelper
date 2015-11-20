using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegExHelper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            meth(tbDbName.Text, tbPattern.Text );
           
        }

        private void meth(string dbName, string patternConst)
        {
            string myConnection = "datasource=localhost;port=3306;username=admin;password=123456";
            try
            {
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();

            string query = "select * from database." + dbName + " ;";

            myDataAdapter.SelectCommand = new MySqlCommand(query, myConn);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);

            myConn.Open();

            MySqlCommand comand = myConn.CreateCommand();
            comand.CommandText = "select table_name from information_schema.tables where table_schema='"+dbName+"'";

            MySqlDataReader reader = comand.ExecuteReader();

            List<string> listTables = new List<string>();
            string resultValue = "";
            while (reader.Read())
            {
                string tableName = reader["table_name"].ToString();

                listTables.Add(tableName);
            }

            Dictionary<string, string> map = new Dictionary<string, string>();

            foreach (string tableName in listTables)
            {
                comand.CommandText = "show columns from " + dbName + "." + tableName;

                reader.Close();
                reader = comand.ExecuteReader();
                resultValue += patternConst + " " + (tableName + "_table").ToUpper() + " = " + "\"" + tableName + "\"" + ";" + "\n";
               
                while (reader.Read())
                {
                    string columnName = reader["Field"].ToString();
                    string strValue = patternConst + " " + columnName.ToUpper() + " = " + columnName + ";" + "\n";
                    if (!map.ContainsKey(columnName))
                    {
                        map.Add(columnName, strValue);
                    }
                }
              
            }

            resultValue += "\n";

            foreach (string key in map.Keys)
            {
                resultValue += map[key];
            }

            rtbConstantRes.Text = resultValue;

            myConn.Close();

            }
            catch (Exception)
            {

            }
        }

       

         

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbQuery.Clear();
            rtbConstantRes.Clear();
        }

        /*string input = rtbQuery.Text.Replace("`", "");

           string pattern = @"(?<=[\(\,])\\?n?\s+\w+";

           string pattern_const = tbPattern.Text;

           string pattern1 = @"(?<=create table)\s+\w+";

           foreach (Match match in Regex.Matches(input.ToLower(), pattern1, RegexOptions.IgnoreCase))
           {
               string tableName = match.Value.Trim();
               rtbConstantRes.Text += pattern_const + " " + (tableName + "_table").ToUpper() + " = " + "\"" + tableName + "\"" + ";" +  "\n\n";
           }

           foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
           {
               string value = match.Value.Replace("\n", "").Trim();

               if (!value.Equals("PRIMARY") && !value.Equals("UNIQUE")
                   && !value.Equals("CONSTRAINT") && !value.Equals("KEY"))
               {
                   rtbConstantRes.Text += pattern_const + " " + value.ToUpper() + " = " + "\"" + value + "\"" + ";" + "\n";
               }
               
           }*/
    }
}
