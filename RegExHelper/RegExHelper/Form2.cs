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
            string input = rtbQuery.Text.Replace("`", "");

            string pattern = @"(?<=[\(\,])\\?n?\s+\w+";

            string pattern_const = tbPattern.Text;

            string pattern1 = @"(?<=create table)\s+\w+";

            foreach (Match match in Regex.Matches(input.ToLower(), pattern1, RegexOptions.IgnoreCase))
            {
                string tableName = match.Value.Trim();
                rtbConstantRes.Text += pattern_const + " " + (tableName + "_table").ToUpper() + " = " + "\"" + tableName + "\"" + "\n\n";
            }

            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
            {
                string value = match.Value.Replace("\n", "").Trim();

                if (!value.Equals("PRIMARY") && !value.Equals("UNIQUE"))
                {
                    rtbConstantRes.Text += pattern_const + " " + value.ToUpper() + " = " + "\"" + value + "\"" + "\n";
                }
               
            }

           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbQuery.Clear();
            rtbConstantRes.Clear();
        }
    }
}
