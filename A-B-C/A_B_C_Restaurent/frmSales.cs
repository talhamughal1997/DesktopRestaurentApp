using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace A_B_C_Restaurent
{
    public partial class frmSales : Form
    {
        ClsDataBase obj = new ClsDataBase();


        int O_ID,num;
        

        string qry;

       

        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=db_A-B-C;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;

        ReportDocument RD = new ReportDocument();

       

        public frmSales()
        {
            InitializeComponent();
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            O_ID = Convert.ToInt32(obj.NewId("O_Id", "tbl_Sales"));
            lblOrder.Text = O_ID.ToString();

            qry = "select * from tbl_Products";
            obj.BindToComboBox(qry,C_Box_Products,"P_Name","P_Id");
            C_Box_Products.Text = "";

            dataGridView1.Rows.Clear();
           
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "S / NO.";
            dataGridView1.Columns[1].HeaderText = "Products";
            dataGridView1.Columns[2].HeaderText = "Unit Price";
            dataGridView1.Columns[3].HeaderText = "Qty";
            dataGridView1.Columns[4].HeaderText = "Net Price";
            

        }

        private void frmSales_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain fu = new frmMain();
            fu.Show();
        }

        private void BtnAddCart_Click(object sender, EventArgs e)
        {
            if (lblUnitPrice.Text != "" && lblNetPrice.Text != "")
            {
                num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = (num + 1).ToString();
                dataGridView1.Rows[num].Cells[1].Value = C_Box_Products.Text;
                dataGridView1.Rows[num].Cells[2].Value = lblUnitPrice.Text;
                dataGridView1.Rows[num].Cells[3].Value = txtQty.Text;
                dataGridView1.Rows[num].Cells[4].Value = lblNetPrice.Text;

                lblTotalItems.Text = (dataGridView1.Rows.Count).ToString();
                int val = 0;
                for (int a = 0; a <= dataGridView1.Rows.Count - 1; a++)
                {
                    val += Convert.ToInt32(dataGridView1.Rows[a].Cells[4].Value);
                }
                lblTotalPrice.Text = val.ToString();
            }
            else
            {
                MessageBox.Show("Plz Fill Accurate Products Or Fill Qty in Numbers  !!");
            }
        }


        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (txtQty.Text != "")
                {
                    int a = Convert.ToInt32(lblUnitPrice.Text);
                    int b = Convert.ToInt32(txtQty.Text);
                    lblNetPrice.Text = (a * b).ToString();
                }
                else
                {
                    lblNetPrice.Text = "";
                }
            }
            catch (Exception) { }
        }



        private void C_Box_Products_TextChanged(object sender, EventArgs e)
        {
            try
            {               
               
                qry = "select * from tbl_Products where P_Name = '" + C_Box_Products.Text.ToString() + "'";
                lblUnitPrice.Text = obj.FindField(qry, "P_Price").ToString();
                txtQty.Text = "";
            }
            catch (Exception) 
            {
                lblUnitPrice.Text = "";
            }
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            if (txtAmountPaid.Text != "")
            {
                try
                {
                    int val1 = Convert.ToInt32(lblTotalPrice.Text);
                    int val2 = Convert.ToInt32(txtAmountPaid.Text);

                    lblBalance.Text = (val2 - val1).ToString();
                }
                catch (Exception)
                {
                    lblBalance.Text = "0";
                }
            }
            else
            {
                lblBalance.Text = "0";
            }
        }

        private void BtnClearCart_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int val = 0;
                for (int a = 0; a <= dataGridView1.Rows.Count - 1; a++)
                {
                    dataGridView1.Rows[a].Cells[0].Value = (a + 1).ToString();
                    val += Convert.ToInt32(dataGridView1.Rows[a].Cells[4].Value);
                    lblTotalItems.Text = (a + 1).ToString();
                    lblTotalPrice.Text = val.ToString();
                }
            }
            catch (Exception) { }
        }

        private void BtnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.Rows.Count >= 0 && txtAmountPaid.Text != "" && int.Parse(txtAmountPaid.Text) >= int.Parse(lblTotalPrice.Text))
                {
                    string msg = null;
                    string date = DateTime.Now.ToShortDateString();
                    string time = DateTime.Now.ToShortTimeString();

                    qry = "select U_Name from tbl_Users where U_Id = " + ClsDataBase.U_Id + "";
                    string user = obj.FindField(qry, "U_Name").ToString();

                    for (int a = 0; a <= dataGridView1.Rows.Count - 1; a++)
                    {
                        qry = "select G_Id from tbl_Products where P_Name = '" + dataGridView1.Rows[a].Cells[1].Value.ToString() + "' ";
                        int g_id = Convert.ToInt32(obj.FindField(qry, "G_Id"));
                        qry = "select G_Kitchen from tbl_Groups where G_Id = " + g_id + " ";
                        int kitchen = Convert.ToInt32(obj.FindField(qry, "G_Kitchen"));

                        string P_Name = dataGridView1.Rows[a].Cells[1].Value.ToString();
                        int U_Price = Convert.ToInt32(dataGridView1.Rows[a].Cells[2].Value);
                        int qty = Convert.ToInt32(dataGridView1.Rows[a].Cells[3].Value);
                        int net_price = Convert.ToInt32(dataGridView1.Rows[a].Cells[4].Value);

                        qry = "insert into tbl_Sales Values (" + O_ID + " , '" + P_Name + "' , " + U_Price + " , " + qty + " , " + net_price + " , " + kitchen + " , '" + date + "' , '" + time + "' ," + txtAmountPaid.Text + " , " + lblBalance.Text +  " , '" + user + "' )";
                        msg = obj.Manipulate(qry, "Sales Added");
                    }
                    MessageBox.Show(msg.ToString());

                    ClearTextBoxes();
                    BtnClearCart_Click(sender, e);
                    timer1.Enabled = false;
                    ClsDataBase.O_Id = O_ID;
                    this.Hide();
                    frmReciepts frm = new frmReciepts();
                    frm.Show();




                    qry = "select * from tbl_Sales where O_Id = " + ClsDataBase.O_Id + " ";
                    da = new SqlDataAdapter(qry, cn);
                    ds = new DataSet();
                    da.Fill(ds, "tab");

                    
                    //frm.crystalReportViewer1.ReportSource = RD;
                    //frm.crystalReportViewer1.Refresh();

                    //RD.PrintToPrinter(1, true,1, 1);

                    //Crystal_Sales reciept = new Crystal_Sales();
                    //reciept.SetDataSource(ds.Tables["tab"]);
                    //reciept.Refresh();
                    
                }

                else
                {
                    MessageBox.Show("Plz Add Products For Sale Or Check Amount ");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex + "Fill All Amount In Numbers ");
            }
        }
       
        
        private void ClearTextBoxes()
        {
            C_Box_Products.Text = "";
            txtAmountPaid.Text = "";
            txtQty.Text = "";
            lblBalance.Text = "";
            lblNetPrice.Text = "";
            lblTotalPrice.Text = "";
            lblTotalItems.Text = "";
            lblUnitPrice.Text = "";
            C_Box_Products.Focus();
           
        }

       
    }
}
