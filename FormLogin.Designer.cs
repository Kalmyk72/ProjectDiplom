namespace Diplom
{
    partial class Form_Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBox_username = new TextBox();
            txtBox_userpass = new TextBox();
            btn_enter = new Button();
            btn_exit = new Button();
            SuspendLayout();
            // 
            // txtBox_username
            // 
            txtBox_username.Location = new Point(135, 61);
            txtBox_username.Name = "txtBox_username";
            txtBox_username.Size = new Size(100, 23);
            txtBox_username.TabIndex = 0;
            txtBox_username.TextChanged += txtBox_username_TextChanged;
            // 
            // txtBox_userpass
            // 
            txtBox_userpass.Location = new Point(135, 106);
            txtBox_userpass.Name = "txtBox_userpass";
            txtBox_userpass.PasswordChar = '*';
            txtBox_userpass.Size = new Size(100, 23);
            txtBox_userpass.TabIndex = 1;
            txtBox_userpass.TextChanged += txtBox_userpass_TextChanged;
            // 
            // btn_enter
            // 
            btn_enter.Location = new Point(135, 151);
            btn_enter.Name = "btn_enter";
            btn_enter.Size = new Size(101, 23);
            btn_enter.TabIndex = 2;
            btn_enter.Text = "Войти";
            btn_enter.UseVisualStyleBackColor = true;
            btn_enter.Click += btn_enter_Click;
            btn_enter.KeyPress += btn_enter_KeyPress;
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(135, 195);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(101, 23);
            btn_exit.TabIndex = 3;
            btn_exit.Text = "Выход";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // Form_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 284);
            Controls.Add(btn_exit);
            Controls.Add(btn_enter);
            Controls.Add(txtBox_userpass);
            Controls.Add(txtBox_username);
            Name = "Form_Login";
            Text = "Авторизация";
            Load += Form_Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBox_username;
        private TextBox txtBox_userpass;
        private Button btn_enter;
        private Button btn_exit;

    }
}
