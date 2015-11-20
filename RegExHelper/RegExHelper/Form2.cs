using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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

       
        


        public void AddResultWork( ResultWorkItem item )
        {
            if (!WasUpdateResultWork(item))
            {
                using (var db = new MyContext())
                {
                    db.ResultWorks.Add(item);
                    db.SaveChanges();
                }
            }
        }

        public bool WasUpdateResultWork( ResultWorkItem item )
        {
            using (var db = new MyContext())
            {
                //var p = db.Res .Where(e => e.Id == 4).First<Person>();
                var rw = db.ResultWorks.Where(e => e.DbName == item.DbName);

                if (rw.Count() == 0)
                {
                    return false;
                }
                else
                {
                    rw.First<ResultWorkItem>().ConstantsValues = item.ConstantsValues;
                    db.SaveChanges();
                    return true;
                }
            }

        }

        private void fillCombobox()
        {
            using (var db = new MyContext())
            {
                //var p = db.Res .Where(e => e.Id == 4).First<Person>();
                var list = db.ResultWorks.Where(e => e.Id >= 0).ToList<ResultWorkItem>();

                foreach (var item in list)
                {
                    cboxDbName.Items.Add(item.DbName);
                }

                
            }
        }


        public Form2()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            meth(cboxDbName.Text, tbPattern.Text );
           
        }

       

        private void meth1( string name )
        {

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
                    string strValue = patternConst + " " + columnName.ToUpper() + " = " + "\"" +  columnName + "\"" +  ";" + "\n";
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

            ResultWorkItem item = new ResultWorkItem();
            item.DbName = dbName;
            item.ConstantsValues = resultValue;

            AddResultWork(item);

            rtbConstantRes.Text = resultValue;

            myConn.Close();

            }
            catch (Exception)
            {

            }
        }

       

       

         

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbConstantRes.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fillCombobox();
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
