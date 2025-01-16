namespace Diplom
{
    partial class Form_Menu
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
            btn_Photo = new Button();
            btn_EditPhoto = new Button();
            btn_printotchet = new Button();
            btn_ExitAcc = new Button();
            SuspendLayout();
            // 
            // btn_Photo
            // 
            btn_Photo.Location = new Point(89, 71);
            btn_Photo.Name = "btn_Photo";
            btn_Photo.Size = new Size(148, 23);
            btn_Photo.TabIndex = 0;
            btn_Photo.Text = "Работа с камерой";
            btn_Photo.UseVisualStyleBackColor = true;
            btn_Photo.Click += btn_Photo_Click;
            // 
            // btn_EditPhoto
            // 
            btn_EditPhoto.Location = new Point(89, 116);
            btn_EditPhoto.Name = "btn_EditPhoto";
            btn_EditPhoto.Size = new Size(148, 23);
            btn_EditPhoto.TabIndex = 1;
            btn_EditPhoto.Text = "Редактировать фото";
            btn_EditPhoto.UseVisualStyleBackColor = true;
            btn_EditPhoto.Click += btn_EditPhoto_Click;
            // 
            // btn_printotchet
            // 
            btn_printotchet.Location = new Point(89, 164);
            btn_printotchet.Name = "btn_printotchet";
            btn_printotchet.Size = new Size(148, 23);
            btn_printotchet.TabIndex = 2;
            btn_printotchet.Text = "Создать отчет";
            btn_printotchet.UseVisualStyleBackColor = true;
            // 
            // btn_ExitAcc
            // 
            btn_ExitAcc.Location = new Point(89, 214);
            btn_ExitAcc.Name = "btn_ExitAcc";
            btn_ExitAcc.Size = new Size(146, 23);
            btn_ExitAcc.TabIndex = 3;
            btn_ExitAcc.Text = "Выход из Аккаунта";
            btn_ExitAcc.UseVisualStyleBackColor = true;
            btn_ExitAcc.Click += btn_ExitAcc_Click;
            // 
            // Form_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 330);
            Controls.Add(btn_ExitAcc);
            Controls.Add(btn_printotchet);
            Controls.Add(btn_EditPhoto);
            Controls.Add(btn_Photo);
            Name = "Form_Menu";
            Text = "Меню";
            FormClosing += Form_Menu_FormClosing;
            Load += Form_Menu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Photo;
        private Button btn_EditPhoto;
        private Button btn_printotchet;
        private Button btn_ExitAcc;
    }
}