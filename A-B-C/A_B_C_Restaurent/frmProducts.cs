using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace A_B_C_Restaurent
{
    public partial class frmProducts : Form
    {
        ClsDataBase obj = new ClsDataBase();
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=db_A-B-C;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd = new SqlCommand();
        TreeNode TN;
        ArrayList AL = new ArrayList();

        string qry;
        int ID;
        
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {

            ID = Convert.ToInt32(obj.NewId("P_Id", "tbl_Products"));

            txtId.Text = ID.ToString();


            qry = "select distinct(G_Name) from tbl_Groups";
            obj.BindToComboBox(qry, C_Box_Group, "G_Name");
            
           

            qry = " SELECT tbl_Products.P_Id, tbl_Products.P_Name, tbl_Groups.G_Name, tbl_Groups.G_Kitchen, tbl_Groups.G_Division, tbl_Products.P_Units, tbl_Products.P_Cost, tbl_Products.P_Price FROM tbl_Products INNER JOIN tbl_Groups ON tbl_Products.G_Id = tbl_Groups.G_Id";

            obj.BindToDataGridView(qry, dataGridView1);
            dataGridView1.Columns["P_Id"].HeaderText = "S/No";
            dataGridView1.Columns["P_Name"].HeaderText = "Products";
            dataGridView1.Columns["G_Name"].HeaderText = "Groups";
            dataGridView1.Columns["G_Kitchen"].HeaderText = "Kitchen";
            dataGridView1.Columns["G_Division"].HeaderText = "Division";
            dataGridView1.Columns["P_Units"].HeaderText = "Units";
            dataGridView1.Columns["P_Cost"].HeaderText = "Cost";
            dataGridView1.Columns["P_Price"].HeaderText = "Price";

            qry = "select distinct(P_Units) from tbl_Products";
            obj.BindToComboBox(qry, C_Box_Unit, "P_Units");
            qry = "select distinct(G_Division) from tbl_Groups";
            obj.BindToComboBox(qry, C_Box_Division, "G_Division");
            

            TreeNode MainTN1 = new TreeNode();
            MainTN1.Text = "Groups";
            treeView1.Nodes.Add(MainTN1);

            TreeNode MainTN2 = new TreeNode();
            MainTN2.Text = "Kitchen";
            treeView1.Nodes.Add(MainTN2);

            TreeNode MainTN3 = new TreeNode();
            MainTN3.Text = "Division";
            treeView1.Nodes.Add(MainTN3);

            TreeNode MainTN4 = new TreeNode();
            MainTN4.Text = "Units";
            treeView1.Nodes.Add(MainTN4);

            qry = "select distinct (G_Name) from tbl_groups";
            da = new SqlDataAdapter(qry, cn);
            ds = new DataSet();
            da.Fill(ds, "tab");

            if (ds.Tables["tab"].Rows.Count >= 0)
            {

                for (int a = 0; a <= ds.Tables["tab"].Rows.Count - 1; a++)
                {
                    TN = new TreeNode();
                    TN.Text = ds.Tables["tab"].Rows[a]["G_Name"].ToString();
                    MainTN1.Nodes.Add(TN); 
                }
                
                for (int a = 0; a <= ds.Tables["tab"].Rows.Count - 1; a++)
                {
                    qry = "select distinct(G_Kitchen) from tbl_groups";
                    da = new SqlDataAdapter(qry, cn);
                    ds = new DataSet();
                    da.Fill(ds, "tab");
                    TN = new TreeNode();
                    TN.Text = ds.Tables["tab"].Rows[a]["G_Kitchen"].ToString();
                    MainTN2.Nodes.Add(TN);
                }
                for (int a = 0; a <= ds.Tables["tab"].Rows.Count - 1; a++)
                {
                    qry = "select distinct(G_Division) from tbl_groups";
                    da = new SqlDataAdapter(qry, cn);
                    ds = new DataSet();
                    da.Fill(ds, "tab");
                    TN = new TreeNode();
                    TN.Text = ds.Tables["tab"].Rows[a]["G_Division"].ToString();
                    MainTN3.Nodes.Add(TN);
                }
                qry = "select distinct(P_Units) from tbl_Products";
                da = new SqlDataAdapter(qry, cn);
                ds = new DataSet();
                da.Fill(ds, "tab");
               
                for (int a = 0; a <= ds.Tables["tab"].Rows.Count - 1; a++)
                {
                   
                        TN = new TreeNode();
                        TN.Text = ds.Tables["tab"].Rows[a]["P_Units"].ToString();
                        MainTN4.Nodes.Add(TN);
                }
            }

            treeView1 = new TreeView();

            
        }
            
        

        private void frmProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain fu = new frmMain();
            fu.Show();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();

            ID = Convert.ToInt32(obj.NewId("P_Id", "tbl_Products"));
            txtId.Text = ID.ToString();
            BtnAdd.Enabled = true;
            BtnDelete.Enabled = false;
            BtnUpdate.Enabled = false;
        }

        private void ClearTextBoxes()
        {
            txtCost.Clear();
            txtId.Clear();
            txtKitchen.Clear();
            txtName.Clear();
            txtPrice.Clear();
            C_Box_Division.Text = "";
            C_Box_Group.Text = "";
            C_Box_Unit.Text = "";

        }
        
        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCost.Text))
            {
                try
                {
                    double value_1 = Convert.ToInt32(txtCost.Text);
                    double value_2 = (value_1 * 42) / 100;
                    txtPrice.Text = Math.Round((value_1 + value_2)).ToString();

                }
                catch (Exception)
                {
                    
                }
            }
        }

        

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.ToUpper() != "" && txtCost.Text != "")
            {

                qry = "select * from tbl_Products where P_Name = '" + txtName.Text.ToUpper().ToUpper() + "' ";

                da = new SqlDataAdapter(qry, cn);
                ds = new DataSet();
                da.Fill(ds, "tab");
                if (ds.Tables["tab"].Rows.Count > 0)
                {
                    MessageBox.Show("Item Already Exist");

                }
                else
                {

                    qry = "select * from tbl_Groups";

                    da = new SqlDataAdapter(qry, cn);
                    ds = new DataSet();
                    da.Fill(ds, "tab");

                    for (int a = 0; a <= ds.Tables["tab"].Rows.Count - 1 ; a++)
                    {
                        string row_1 = ds.Tables["tab"].Rows[a]["G_Name"].ToString();
                        string row_2 = ds.Tables["tab"].Rows[a]["G_Division"].ToString();

                        if (C_Box_Group.Text == row_1 && C_Box_Division.Text == row_2)
                        {
                            qry = "select * from tbl_Groups where G_Name = '" + C_Box_Group.Text + "'";
                            string findfield = obj.FindField(qry, "G_Id");
                            qry = "insert into tbl_Products values (" + ID + ",'" + txtName.Text.ToUpper() + "' , " + txtCost.Text + " , " + txtPrice.Text + " , '" + C_Box_Unit.Text + "','" + Convert.ToInt32(findfield) + "') ";
                            MessageBox.Show(obj.Manipulate(qry, "Product Added Successfullly"));

                            break;
                        }
                        else
                        {
                            qry = "insert into tbl_Groups (G_Name , G_Kitchen , G_Division) values ('" + C_Box_Group.Text + "' , " + txtKitchen.Text + " , '" + C_Box_Division.Text + "') ";
                            MessageBox.Show(obj.Manipulate(qry, "Group Added Successfullly"));
                            qry = "select * from tbl_Groups where G_Name = '" + C_Box_Group.Text + "' ";
                            da = new SqlDataAdapter(qry, cn);
                            ds = new DataSet();
                            da.Fill(ds, "tab");
                            int num = Convert.ToInt32(ds.Tables["tab"].Rows[0]["G_Id"]);
                            qry = "insert into tbl_Products values (" + ID + ",'" + txtName.Text.ToUpper() + "' , " + txtCost.Text + " , " + txtPrice.Text + " , '" + C_Box_Unit.Text + "' , '" + num + "') ";
                            MessageBox.Show(obj.Manipulate(qry, "Product Added Successfullly"));
                           
                            break;

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Plz Fill Text Boxes");
            }
            frmProducts_Load(sender, e);
        }

        private void C_Box_Group_TextChanged(object sender, EventArgs e)
        {
            qry = "select * from tbl_Groups";
            
            da = new SqlDataAdapter(qry,cn);
            ds = new DataSet();
            da.Fill(ds,"tab");

            for (int a = 0; a <= ds.Tables["tab"].Rows.Count - 1; a++)
            {
                string row_1 = ds.Tables["tab"].Rows[a]["G_Name"].ToString();
                
                if (C_Box_Group.Text == row_1)
                {
                   // C_Box_Group.ValueMember = Convert.ToInt32(ds.Tables["tab"].Rows[a]["G_Id"]);
                    txtKitchen.ReadOnly = true;
                    txtKitchen.Text = ds.Tables["tab"].Rows[a]["G_Kitchen"].ToString();
                    break;
                }
                else
                {
                    txtKitchen.ReadOnly = false;
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

            bool Matched = false;
            bool G_Matched = true;
            
            qry = " SELECT G_Id from tbl_Groups where G_Name = '" + C_Box_Group.Text + "' ";
            int val = Convert.ToInt32(obj.FindField(qry, "G_Id"));

            if (txtName.Text != "" && txtCost.Text != "")
            {

                qry = " SELECT tbl_Products.P_Id, tbl_Products.P_Name, tbl_Groups.G_Id, tbl_Groups.G_Name, tbl_Groups.G_Kitchen, tbl_Groups.G_Division, tbl_Products.P_Units, tbl_Products.P_Cost, tbl_Products.P_Price FROM tbl_Products INNER JOIN tbl_Groups ON tbl_Products.G_Id = tbl_Groups.G_Id";

                da = new SqlDataAdapter(qry, cn);
                ds = new DataSet();
                da.Fill(ds, "tab");

                for (int a = 0; a <= ds.Tables["tab"].Rows.Count - 1; a++)
                {

                    string row_1 = ds.Tables["tab"].Rows[a]["P_Name"].ToString();
                    string row_2 = ds.Tables["tab"].Rows[a]["G_Name"].ToString();
                    string row_3 = ds.Tables["tab"].Rows[a]["G_Division"].ToString();
                    string row_4 = ds.Tables["tab"].Rows[a]["P_Cost"].ToString();


                    if (txtName.Text.ToLower() == row_1.ToLower() && C_Box_Group.Text.ToLower() == row_2.ToLower() && C_Box_Division.Text.ToLower() == row_3.ToLower() && txtCost.Text == row_4)
                    {
                        Matched = true;
                        
                        break;
                    }
                    else
                    {
                        if (C_Box_Group.Text.ToLower() != ds.Tables["tab"].Rows[a]["G_Name"].ToString().ToLower())
                        {
                            G_Matched = false;

                        }
                        else
                        {
                            G_Matched = true;
                            val = Convert.ToInt32(ds.Tables["tab"].Rows[a]["G_Id"]);
                        }
                        Matched = false;
                        
                    }

                }
            }

            else if (C_Box_Group.Text != "")
            {
                qry = "Update tbl_Groups set G_Name = '" + C_Box_Group.Text + "' , G_Kitchen = " + txtKitchen.Text + " , G_Division = '" + C_Box_Division.Text + "'  where G_Id = " + val + "";
                MessageBox.Show(obj.Manipulate(qry, "Product Updated Successfully"));
            }
            else
            {
                MessageBox.Show("Plz Fill Text Boxes");
            }
            if (Matched == false)
            {

                if (G_Matched == false)
                {
                    qry = "insert into tbl_Groups (G_Name,G_Kitchen,G_Division) Values ('" + C_Box_Group.Text + "' , '" + txtKitchen.Text + "' , '" + C_Box_Division.Text + "')";
                    MessageBox.Show(obj.Manipulate(qry, "Group Added Successfully"));
                    qry = "select * from tbl_groups where G_Name = '" + C_Box_Group.Text + "'";
                    da = new SqlDataAdapter(qry,cn);
                    ds = new DataSet();
                    da.Fill(ds, "Tab");
                    val = Convert.ToInt32(ds.Tables["tab"].Rows[0]["G_Id"]);
                        
                }
         
                qry = "Update tbl_Products set P_Name = '" + txtName.Text + "' , P_Cost = " + txtCost.Text + " , P_Price = " + txtPrice.Text + " , P_Units = '" + C_Box_Unit.Text + "' , G_Id = " + val + " where P_Id = " + Convert.ToInt32(txtId.Text) + "";
                MessageBox.Show(obj.Manipulate(qry, "Product Updated Successfully"));
            
            }
            else
            {
                MessageBox.Show("Items Matched");
            }

            frmProducts_Load(sender, e);
            ClearTextBoxes();
            BtnNew_Click(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                C_Box_Group.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtKitchen.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                C_Box_Division.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                C_Box_Unit.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCost.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                BtnAdd.Enabled = false;
                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
                txtKitchen.ReadOnly = false;
            }
            catch (Exception)
            {
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                qry = "Delete From tbl_Groups where G_Id = " + C_Box_Group.SelectedValue + " ";
                MessageBox.Show(obj.Manipulate(qry, "Record Deleted Successfully"));
                qry = "Delete From tbl_Products where G_Id = " + txtId.Text + " ";
                MessageBox.Show(obj.Manipulate(qry, "Record Deleted Successfully"));
            }
            else
            {
                qry = "Delete From tbl_Products where P_Id = " + txtId.Text + " ";
                MessageBox.Show(obj.Manipulate(qry, "Record Deleted Successfully"));
            }

            frmProducts_Load(sender, e);
            BtnNew_Click(sender, e);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            
            qry = " SELECT tbl_Products.P_Id, tbl_Products.P_Name, tbl_Groups.G_Name, tbl_Groups.G_Kitchen, tbl_Groups.G_Division, tbl_Products.P_Units, tbl_Products.P_Cost, tbl_Products.P_Price FROM tbl_Products INNER JOIN tbl_Groups ON tbl_Products.G_Id = tbl_Groups.G_Id where P_Name like '%" + txtSearch.Text.ToLower() + "%' ";
           // qry = "select * from tbl_Products where P_Name like '%" + txtSearch.Text.ToLower() + "%'";
            obj.BindToDataGridView(qry, dataGridView1);
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {


            try
            {
                qry = "SELECT tbl_Products.P_Name, tbl_Groups.G_Name, tbl_Groups.G_Kitchen, tbl_Groups.G_Division, tbl_Products.P_Units, tbl_Products.P_Cost, tbl_Products.P_Price FROM tbl_Products INNER JOIN tbl_Groups ON tbl_Products.G_Id = tbl_Groups.G_Id";
                da = new SqlDataAdapter(qry, cn);
                ds = new DataSet();
                da.Fill(ds, "tab");

                for (int a = 0; a <= ds.Tables["tab"].Rows.Count - 1; a++)
                {
                    string field = null;
                    for (int b = 0; b <= ds.Tables["tab"].Columns.Count - 1; b++)
                    {
                        if (ds.Tables["tab"].Rows[a][b].ToString().ToLower() == e.Node.Text.ToLower())
                        {
                            field = ds.Tables["tab"].Rows[a][b].ToString().ToLower();
                            string column = ds.Tables["tab"].Columns[b].ToString();
                            qry = "SELECT tbl_Groups.G_Id, tbl_Products.P_Name, tbl_Groups.G_Name, tbl_Groups.G_Kitchen, tbl_Groups.G_Division, tbl_Products.P_Units, tbl_Products.P_Cost, tbl_Products.P_Price FROM tbl_Products INNER JOIN tbl_Groups ON tbl_Products.G_Id = tbl_Groups.G_Id where " + column + " = '" + field + "'";
                            da = new SqlDataAdapter(qry, cn);
                            ds = new DataSet();
                            da.Fill(ds, "tab");
                            dataGridView1.DataSource = ds.Tables["tab"];
                        }



                    }

                    if (field != null)
                    {
                        break;
                    }
                }


            }

            catch (Exception)
            {
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           // MessageBox.Show(e.Node.Text);
            //AL.Add(e.Node.Text);
        }
         

       
    }
}
