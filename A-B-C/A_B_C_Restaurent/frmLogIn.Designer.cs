namespace A_B_C_Restaurent
{
    partial class frmLogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUsers = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.txtAdmin = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lnkUser = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.picMinimized = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimized)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsers
            // 
            this.lblUsers.BackColor = System.Drawing.Color.Transparent;
            this.lblUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUsers.Location = new System.Drawing.Point(299, 193);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(327, 29);
            this.lblUsers.TabIndex = 0;
            this.lblUsers.Text = "Administrator";
            this.lblUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::A_B_C_Restaurent.Properties.Resources.Admin;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(352, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 154);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.BackgroundImage = global::A_B_C_Restaurent.Properties.Resources.close;
            this.picExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picExit.Location = new System.Drawing.Point(857, 469);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(33, 29);
            this.picExit.TabIndex = 2;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // txtAdmin
            // 
            this.txtAdmin.BackColor = System.Drawing.SystemColors.Menu;
            this.txtAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdmin.Location = new System.Drawing.Point(383, 233);
            this.txtAdmin.Name = "txtAdmin";
            this.txtAdmin.Size = new System.Drawing.Size(206, 24);
            this.txtAdmin.TabIndex = 1;
            this.txtAdmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdmin_KeyPress);
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.Blue;
            this.btnLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(410, 355);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(89, 29);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "L0g IN";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // lnkUser
            // 
            this.lnkUser.ActiveLinkColor = System.Drawing.Color.White;
            this.lnkUser.BackColor = System.Drawing.Color.Transparent;
            this.lnkUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUser.ForeColor = System.Drawing.Color.Navy;
            this.lnkUser.LinkColor = System.Drawing.Color.Navy;
            this.lnkUser.Location = new System.Drawing.Point(474, 314);
            this.lnkUser.Name = "lnkUser";
            this.lnkUser.Size = new System.Drawing.Size(115, 15);
            this.lnkUser.TabIndex = 3;
            this.lnkUser.TabStop = true;
            this.lnkUser.Text = "As User  :";
            this.lnkUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUser_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(258, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(258, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password :";
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.SystemColors.Menu;
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Password.Location = new System.Drawing.Point(383, 276);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(206, 24);
            this.txt_Password.TabIndex = 2;
            this.txt_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Password_KeyPress);
            // 
            // picMinimized
            // 
            this.picMinimized.BackColor = System.Drawing.Color.Transparent;
            this.picMinimized.BackgroundImage = global::A_B_C_Restaurent.Properties.Resources.minimized;
            this.picMinimized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMinimized.Location = new System.Drawing.Point(802, 469);
            this.picMinimized.Name = "picMinimized";
            this.picMinimized.Size = new System.Drawing.Size(33, 29);
            this.picMinimized.TabIndex = 9;
            this.picMinimized.TabStop = false;
            this.picMinimized.Click += new System.EventHandler(this.picMinimized_Click);
            // 
            // frmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::A_B_C_Restaurent.Properties.Resources.LogIn_BackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(911, 516);
            this.Controls.Add(this.picMinimized);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnkUser);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.txtAdmin);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "L0gG |N ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimized)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.TextBox txtAdmin;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.LinkLabel lnkUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.PictureBox picMinimized;
    }
}

