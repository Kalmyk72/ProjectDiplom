using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Canon_13_12_10_90D;

namespace Diplom
{
    public partial class Form_CameraPhoto : Form
    {
        public Form_CameraPhoto()
        {
            InitializeComponent();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Form_Menu form_Menu = new Form_Menu();
            form_Menu.Show();
            this.Close();
        }

    }
}
