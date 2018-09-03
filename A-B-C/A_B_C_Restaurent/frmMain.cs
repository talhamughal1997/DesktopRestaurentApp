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
    public partial class frmMain : Form
    {
        ClsDataBase obj = new ClsDataBase();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (ClsDataBase.Role.ToLower() != "admin")
            {
                picProduct.Enabled = false;
                picReport.Enabled = false;
                picAdmin.Enabled = false;
            }
            
        }

        private void picSale_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSales fu = new frmSales();
            fu.Show();
        }

        private void picProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmProducts fu = new frmProducts();
            fu.Show();
        }

        private void picReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmReports fu = new frmReports();
            fu.Show();
        }

        private void picAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdmin fu = new frmAdmin();
            fu.Show();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogIn fu = new frmLogIn();
            fu.Show();
        }
    }
}
