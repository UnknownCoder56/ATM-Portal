using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace ATM_Portal
{
    public partial class AccountManage : Form
    {
        public static UserInfo userInfo;
        public AccountManage(object user)
        {
            InitializeComponent();
            userInfo = (UserInfo)user;
        }

        private void buttonChangeName_Click(object sender, EventArgs e)
        {
            ValueChange valueChange = new ValueChange(ValueChange.CHANGE_NAME);
            valueChange.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelName.Text = userInfo.Name;
            labelAcNumber.Text = userInfo.AccountNumber.ToString("0");
            labelAcBalance.Text = userInfo.Balance.ToString("0.00");
        }

        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            ValueChange valueChange = new ValueChange(ValueChange.DEPOSIT);
            valueChange.Show();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            ValueChange valueChange = new ValueChange(ValueChange.CHANGE_PASSWORD);
            valueChange.Show();
        }

        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            ValueChange valueChange = new ValueChange(ValueChange.WITHDRAW);
            valueChange.Show();
        }

        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
            File.Delete(Login.dir + "\\" + userInfo.AccountNumber + ".json");
            MessageBox.Show("Successfully deleted account!");
            Hide();
            Login login = new Login();
            login.Show();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            File.Delete(Login.dir + "\\" + userInfo.AccountNumber + ".json");
            StreamWriter writer = new StreamWriter(File.Create(Login.dir + "\\" + userInfo.AccountNumber + ".json"));
            string text = JsonConvert.SerializeObject(userInfo);
            writer.Write(text);
            writer.Close();
            Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
