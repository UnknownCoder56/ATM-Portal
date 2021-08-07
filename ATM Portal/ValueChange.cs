using System;
using System.Windows.Forms;

namespace ATM_Portal
{
    public partial class ValueChange : Form
    {
        public static int DEPOSIT = 0;
        public static int WITHDRAW = 1;
        public static int CHANGE_NAME = 2;
        public static int CHANGE_PASSWORD = 3;
        public string value;
        public int type;
        public ValueChange(int formType)
        {
            InitializeComponent();
            type = formType;
            if (formType == DEPOSIT)
            {
                Text = "Deposit";
                labelValue.Text = "Deposit Money";
                labelEnterValue.Text = "How much to deposit?";
            }
            else if (formType == WITHDRAW)
            {
                Text = "Withdraw";
                labelValue.Text = "Withdraw Money";
                labelEnterValue.Text = "How much to withdraw?";
            }
            else if (formType == CHANGE_NAME)
            {
                Text = "Change Name";
                labelValue.Text = "Change A/C holder's name";
                labelEnterValue.Text = "Enter new name";
            }
            else if (formType == CHANGE_PASSWORD)
            {
                Text = "Change Password";
                labelValue.Text = "Change A/C password";
                labelEnterValue.Text = "Enter new password";
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                value = textBoxValue.Text;
                if (type == DEPOSIT) AccountManage.userInfo.Balance += double.Parse(value);
                else if (type == WITHDRAW) AccountManage.userInfo.Balance -= double.Parse(value);
                else if (type == CHANGE_NAME) AccountManage.userInfo.Name = value;
                else if (type == CHANGE_PASSWORD) AccountManage.userInfo.Password = value;
                Hide();
            } catch
            {
                MessageBox.Show("Please enter a number!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
