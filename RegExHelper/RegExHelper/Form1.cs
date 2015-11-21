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
            if (cboxDbName.Text.Length == 0)
            {
                MessageBox.Show("Choose DataBase!");
                return;
            }

            setVisibility(true);

            string input = DbEntityHelper.getInstance().getConstantsByDbName( cboxDbName.Text );

            Dictionary<string, string> map = StringHelper.getConstantsMap(rtbSql.Text, input);

            Dictionary<string, string> mapConst = StringHelper.getLocalConstansMap(rtbSql.Text);

            rtbResult.Text = StringHelper.getLocalConstansListByMap(mapConst, tbPattern.Text) + StringHelper.getSqlQueryByMap(map, mapConst, rtbSql.Text, cbClassName.Text);

            DbEntityHelper.getInstance().putUserDataFromFormLocalConstant(cboxDbName.Text, tbPattern.Text, cbClassName.Text );
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            setVisibility(false);

            rtbResult.Clear();
            rtbSql.Clear();
        }

        private void rtbResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillCombobox();
            setVisibility(false);
        }

        private void fillCombobox()
        {
            List<string> listNames = DbEntityHelper.getInstance().getDbNames();
            foreach (var name in listNames)
            {
                cboxDbName.Items.Add(name);
            }

            List<string> listClassNames = DbEntityHelper.getInstance().getLastDbNames();
            foreach (var name in listClassNames)
            {
                cbClassName.Items.Add(name);
            }

            ItemSavedData item = DbEntityHelper.getInstance().getUserSavedData();

            if (item != null)
            {
                cboxDbName.Text = item.LastDbName;
                if (item.LocalConstPattern != null && item.LocalConstPattern != "")
                {
                    tbPattern.Text = item.LocalConstPattern;
                }
                cbClassName.Text = item.LastClassName;
            }
        }

        private void setVisibility(bool fl)
        {
            rtbResult.Visible = fl;
            lableResultText.Visible = fl;
        }

        


    }
}
