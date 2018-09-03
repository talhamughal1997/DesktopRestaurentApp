using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace A_B_C_Restaurent
{
    public partial class frmReciepts : Form
    {
        ClsDataBase obj = new ClsDataBase();

        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=db_A-B-C;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
          
        ReportDocument RD = new ReportDocument();

        string qry;

        public frmReciepts()
        {
            InitializeComponent();
        }

        private void frmReciepts_Load(object sender, EventArgs e)
        {
            qry = "select * from tbl_Sales where O_Id = " + ClsDataBase.O_Id + " ";
            da = new SqlDataAdapter(qry, cn);
            ds = new DataSet();
            da.Fill(ds, "tab");
            
            RD.Load(@"D:\A-B-C\A_B_C_Restaurent\Crystal_Sales.rpt");
            RD.SetDataSource(ds.Tables["tab"]);
            crystalReportViewer1.ReportSource =RD;
            crystalReportViewer1.Refresh();
           
        }

        private void frmReciepts_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            frmSales frm = new frmSales();
            frm.Show();
        }

        
    }
}
