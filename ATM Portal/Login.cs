using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ATM_Portal
{
    public partial class Login : Form
    {
        public static string dir;
        public Login()
        {
            InitializeComponent();
            dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ATM Portal\\";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ATM Portal\\" + textBoxAccountNumber.Text + ".json");
                string user = reader.ReadToEnd();
                reader.Close();
                UserInfo currentUserInfo = JsonConvert.DeserializeObject<UserInfo>(user);
                if (textBoxAccountPassword.Text == currentUserInfo.Password)
                {
                    MessageBox.Show("Logged In!");
                    this.Hide();
                    AccountManage accountManage = new AccountManage(currentUserInfo);
                    accountManage.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Password!");
                }
            } catch
            {
                MessageBox.Show("Account does not exist!");
            }
        }
    }
}
