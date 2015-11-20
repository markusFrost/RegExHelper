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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string getConstantsByDbName(string dbName)
        {
            using (var db = new MyContext())
            {
                var rw = db.ResultWorks.Where(e => e.DbName == dbName);

                if (rw.Count() == 0)
                {
                    return null;
                }
                else
                {
                    return rw.First<ResultWorkItem>().ConstantsValues;
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> map = new Dictionary<string, string>();

            string pattern1 = @"\b\w+\s*\=\s*\|\b\w+\|\;";
            string input = getConstantsByDbName ( cboxDbName.Text);// rtbConstants.Text;

            string pattern2 = @"\w+";

            string sqlValue = rtbSql.Text;

            input = input.Replace("\"", "|");

            map.Clear();

            foreach (Match match in Regex.Matches(input, pattern1, RegexOptions.IgnoreCase))
            {
                string key = null;
                string value = null;

                foreach (Match match1 in Regex.Matches( match.Value, pattern2, RegexOptions.IgnoreCase))
                {
                    if (key == null)
                    {
                        key = match1.Value;
                    }
                    else if ( value == null )
                    {
                        value = match1.Value;
                    }

                }

                if ( !map.ContainsKey( key ) )
                {
                    map.Add(key, value);
                }
            }

           

            foreach (string key in map.Keys)
            {
                string replace = "";

                replace += " \"";
                replace += " + ";
                replace += key;
                replace += " + ";
                 replace += "\" ";

                 string pat = @"\b" + map[key] + @"\b";
                Regex rgx = new Regex(pat);

                sqlValue = rgx.Replace(sqlValue, replace);
            }

            sqlValue = sqlValue.Replace(" . ", ".");

            sqlValue = "String query = \"" + sqlValue + "\";";

            rtbResult.Text = sqlValue;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //rtbConstants.Clear();
            rtbResult.Clear();
            rtbSql.Clear();
        }

        private void rtbResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillCombobox();
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

        


    }
}
