
namespace Diplom
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void btn_enter_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            if (txtBox_username.Text == "")
            {
                MessageBox.Show("Поле логина не должно быть пустым");
                return;
            }

            if (txtBox_userpass.Text == "")
            {
                MessageBox.Show("Поле пароля не должно быть пустым");
                return;
            }
            if (txtBox_userpass.Text == "admin" && txtBox_username.Text == "admin")
            {

                Form_Menu form_Menu = new Form_Menu();
                form_Menu.Show();
                this.Hide();
                //Hide();

            }
            else
            {
                MessageBox.Show("Пользователь не найден, проверьте логин и пароль");
            }
        }

        private void txtBox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBox_userpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
