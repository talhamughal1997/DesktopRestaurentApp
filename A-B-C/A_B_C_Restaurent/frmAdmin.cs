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
    public partial class frmAdmin : Form
    {
        ClsDataBase obj = new ClsDataBase();
        string qry;
        int ID;
        bool mode = true;

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain fu = new frmMain();
            fu.Show();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            qry = "select * from tbl_Users";
            
            obj.BindToListBox(qry, lst_Users, "U_UName", "U_Id");

            ID = Convert.ToInt32(obj.NewId("U_Id", "tbl_Users"));
            txtId.Text = ID.ToString();

        }

        private void lblEdit_Click(object sender, EventArgs e)
        {
            if (lblEdit.Text == "Edit")
            {
                mode = false;
                lblAdd.Visible = false;
                lblEdit.Text = "Edit Cancel";
                lblUpdate.Visible = true;
                lblDelete.Visible = true;
                ClearBoxes();


            }
            else
            {
                lblAdd.Visible = true;
                lblEdit.Text = "Edit";
                lblUpdate.Visible = false;
                lblDelete.Visible = false;
                ClearBoxes();
                mode = true;
                frmAdmin_Load(sender, e);
            }
        }
        

        private void lblAdd_Click(object sender, EventArgs e)
        {
            qry = "select * from tbl_Users where U_Id = " + txtId.Text + " or U_Name = '" + txtName.Text + "' and U_FName = '" + txtFName.Text + "' or U_Email = '" + txtEmail.Text + "' or U_UName = '" + cBox_Role.SelectedItem.ToString() + "' ";
            bool chk = obj.SearchUser(qry);
            if (chk == true)
            {
                MessageBox.Show("Record Already Exist");
            }
            else
            {
                qry = "insert into tbl_Users values(" + ID + ",'" + txtName.Text + "','" + txtFName.Text + "','" + txtUName.Text + "','" + txtEmail.Text + "','" + txtPassword.Text + "','" + cBox_Role.Text + "')";
                MessageBox.Show(obj.Manipulate(qry, "Record Added SuccessFully"));
                frmAdmin_Load(sender, e);
            }

            
        }
        private void ClearBoxes()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtFName.Text = "";
            txtUName.Text = "";
            cBox_Role.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            
        }



        private void lst_Users_Click(object sender, EventArgs e)
        {
            if (mode == false)
            {
                txtId.ReadOnly = false;
                int I = Convert.ToInt16(lst_Users.SelectedValue);
                qry = "select* from tbl_Users where U_Id = " + I + "";

                txtId.Text = obj.FindField(qry, "U_Id");
                txtName.Text = obj.FindField(qry, "U_Name");
                txtFName.Text = obj.FindField(qry, "U_FName");
                txtUName.Text = obj.FindField(qry, "U_UName");
                cBox_Role.Text = obj.FindField(qry, "U_Roll");
                txtEmail.Text = obj.FindField(qry, "U_Email");
                txtPassword.Text = obj.FindField(qry, "U_Password");
                
            }
            
        }
        private void lblUpdate_Click(object sender, EventArgs e)
        {
           
                qry = "Update tbl_Users set U_Id =" + txtId.Text + ",U_Name ='" + txtName.Text + "',U_FName ='" + txtFName.Text + "',U_UName ='" + txtUName.Text + "',U_Email ='" + txtEmail.Text + "',U_Password ='" + txtPassword.Text + "',U_Roll ='" + cBox_Role.SelectedItem.ToString() + "' where U_Id =" + lst_Users.SelectedValue + " ";
                MessageBox.Show(obj.Manipulate(qry, "Record Updated SuccessFully"));
                frmAdmin_Load(sender, e);
            

        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("Do You Really Want to Delete ?", "Delete", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                qry = "delete from tbl_Users where U_Id = " + lst_Users.SelectedValue + " ";
                obj.Manipulate(qry, "Record Deleted Successfully");
                frmAdmin_Load(sender, e);
            }
        }

       
        
    }
}
