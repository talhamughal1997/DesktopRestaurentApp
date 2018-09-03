using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_B_C_Restaurent
{
    public partial class frmReports : Form
    {
        string qry;
        ClsDataBase obj = new ClsDataBase();

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain fu = new frmMain();
            fu.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            qry = "select * from tbl_Sales where O_Date = '" + dateTimePicker1.Value.ToShortDateString() + "'";
            obj.BindToDataGridView(qry,dataGridView1);
            decimal totalprice = 0;

            try
            {
                for (int a = 0; a <= dataGridView1.Rows.Count - 1; a++)
                {
                    totalprice += decimal.Parse(dataGridView1.Rows[a].Cells[4].Value.ToString());
                }
            }
            catch(Exception){}

            textBox1.Text = totalprice.ToString();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {

        }
    }
}
