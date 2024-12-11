
namespace Client
{
    partial class RegisterForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        /// 
        //private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPasswordConfirm;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRoleCode;
        private System.Windows.Forms.TextBox txtRoleCode;
        private System.Windows.Forms.LinkLabel linkLogin;
        private System.Windows.Forms.Button btnRegister;

        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordConfirm = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRoleCode = new System.Windows.Forms.Label();
            this.txtRoleCode = new System.Windows.Forms.TextBox();
            this.linkLogin = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(16, 18);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(73, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(133, 15);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(228, 22);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 50);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(133, 47);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(228, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPasswordConfirm
            // 
            this.lblPasswordConfirm.AutoSize = true;
            this.lblPasswordConfirm.Location = new System.Drawing.Point(16, 82);
            this.lblPasswordConfirm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasswordConfirm.Name = "lblPasswordConfirm";
            this.lblPasswordConfirm.Size = new System.Drawing.Size(121, 17);
            this.lblPasswordConfirm.TabIndex = 4;
            this.lblPasswordConfirm.Text = "Confirm Password";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Location = new System.Drawing.Point(133, 79);
            this.txtPasswordConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.Size = new System.Drawing.Size(228, 22);
            this.txtPasswordConfirm.TabIndex = 5;
            this.txtPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(133, 177);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 28);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(16, 114);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(37, 17);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "Role";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "User",
            "Admin"});
            this.cmbRole.Location = new System.Drawing.Point(133, 111);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(228, 24);
            this.cmbRole.TabIndex = 7;
            // 
            // lblRoleCode
            // 
            this.lblRoleCode.AutoSize = true;
            this.lblRoleCode.Location = new System.Drawing.Point(16, 149);
            this.lblRoleCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoleCode.Name = "lblRoleCode";
            this.lblRoleCode.Size = new System.Drawing.Size(74, 17);
            this.lblRoleCode.TabIndex = 8;
            this.lblRoleCode.Text = "Role Code";
            // 
            // txtRoleCode
            // 
            this.txtRoleCode.Location = new System.Drawing.Point(133, 145);
            this.txtRoleCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRoleCode.Name = "txtRoleCode";
            this.txtRoleCode.Size = new System.Drawing.Size(228, 22);
            this.txtRoleCode.TabIndex = 9;
            // 
            // linkLogin
            // 
            this.linkLogin.AutoSize = true;
            this.linkLogin.Location = new System.Drawing.Point(16, 209);
            this.linkLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLogin.Name = "linkLogin";
            this.linkLogin.Size = new System.Drawing.Size(363, 17);
            this.linkLogin.TabIndex = 11;
            this.linkLogin.TabStop = true;
            this.linkLogin.Text = "Если вы зарегистрированы, нажмите здесь для входа";
            this.linkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogin_LinkClicked);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 237);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.linkLogin);
            this.Controls.Add(this.txtRoleCode);
            this.Controls.Add(this.lblRoleCode);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtPasswordConfirm);
            this.Controls.Add(this.lblPasswordConfirm);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RegisterForm";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

#endregion