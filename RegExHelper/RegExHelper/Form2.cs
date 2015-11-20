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
        public Form2()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            rtbConstantRes.Text = StringHelper.convertSqlQueryToConstants(cboxDbName.Text, tbPattern.Text);           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbConstantRes.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fillCombobox();
        }

        private void fillCombobox()
        {
            List<string> listNames = DbEntityHelper.getInstance().getDbNames();
            foreach (var name in listNames)
            {
                cboxDbName.Items.Add(name);
            }
        }
    }
}
