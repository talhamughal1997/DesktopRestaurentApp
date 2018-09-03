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
    public partial class frmLogIn : Form
    {
        ClsDataBase obj = new ClsDataBase();
        bool mode = true;
        string qry;
       

        public frmLogIn()
        {
            InitializeComponent();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            if (mode == true)
            {
                lblUsers.Text = "Users";
                lnkUser.Text = "as Administrator";
                pictureBox1.BackgroundImage = Properties.Resources.Users;
                mode = false;
               
            }
            else
            {
                lblUsers.Text = "Administrator";
                lnkUser.Text = "as Users";
                pictureBox1.BackgroundImage = Properties.Resources.Admin;
                mode = true;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {   
            if (mode == true)
            {
                qry = "select * from tbl_Users where U_roll ='Admin' and U_UName = '" + txtAdmin.Text + "' and U_Password = '" + txt_Password.Text + "' ";

                bool chk = obj.SearchUser(qry);

                if (chk == true)
                {
                    ClsDataBase.Role = obj.FindField(qry, "U_Roll");
                    ClsDataBase.U_Id = Convert.ToInt32(obj.FindField(qry, "U_Id"));
                    
                    this.Hide();
                    frmMain fu = new frmMain();
                    fu.Show();
                    
                }
                else
                {
                    MessageBox.Show("IN Correct Users");
                }
            }
            else
            {
                qry = "select * from tbl_Users where U_roll = 'User' and U_UName = '" + txtAdmin.Text + "' and U_Password = '" + txt_Password.Text + "' ";

                bool chk = obj.SearchUser(qry);

                if (chk == true)
                {
                    ClsDataBase.Role = obj.FindField(qry, "U_Roll");
                    ClsDataBase.U_Id = Convert.ToInt32(obj.FindField(qry, "U_Id"));
                    
                    this.Hide();
                    frmMain fu = new frmMain();
                    fu.Show();
                    //qry = "select * from tbl_Users where U_Uname = '" + txtAdmin.Text + "' and U_Password = '" + txt_Password.Text + "'";
                    
                }
                else
                {
                    MessageBox.Show("IN Correct Users");
                }

            }
            
        }
                
        private void picMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtAdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnLogIn_Click(sender, e);
            }
        }

        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtAdmin_KeyPress(sender, e);
        }
    }
}
