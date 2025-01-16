using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Diplom
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }

        private void Form_Menu_Load(object sender, EventArgs e)
        {

        }

        private void btn_Photo_Click(object sender, EventArgs e)
        {
            Form_CameraPhoto form_CameraPhoto = new Form_CameraPhoto();
            form_CameraPhoto.ShowDialog();
            this.Close();
        }

        private void btn_ExitAcc_Click(object sender, EventArgs e)
        {
            Form_Login form_Login = new Form_Login();
            form_Login.ShowDialog();
            this.Close();
        }

        private void btn_EditPhoto_Click(object sender, EventArgs e)
        {
            ImageEditor.ImageEditor edit = new ImageEditor.ImageEditor();
            edit.ShowDialog();
            this.Close();
        }

        private void Form_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
           // if (MessageBox.Show("Точно хотите выйти", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            //{
             //   Application.Exit();
               // e.Cancel = false;
            //}
            
        }
    }
}
    
