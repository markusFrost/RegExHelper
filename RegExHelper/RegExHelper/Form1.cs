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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> map = StringHelper.getConstantsMap(rtbSql.Text, cboxDbName.Text);

            rtbResult.Text = StringHelper.getSqlQueryByMap(map, rtbSql.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
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
            List<string> listNames = DbEntityHelper.getInstance().getDbNames();
            foreach (var name in listNames)
            {
                cboxDbName.Items.Add(name);
            }
        }

        


    }
}
