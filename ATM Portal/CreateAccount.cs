﻿using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ATM_Portal
{
    public partial class CreateAccount : Form
    {
        
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo(
                textBoxUserName.Text, double.Parse(textBoxAccountNumber.Text), 
                textBoxPassword.Text, double.Parse(textBoxBalance.Text));
            try
            {
                string dir = Login.dir;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ATM Portal\\" + userInfo.AccountNumber + ".json";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string text = JsonConvert.SerializeObject(userInfo);
                MessageBox.Show("Account Created!");
                FileStream fileStream = File.Create(path);
                StreamWriter writer = new StreamWriter(fileStream);
                writer.Write(text);
                writer.Close();
                fileStream.Close();
                Hide();
                Login login = new Login();
                login.Show();
            } catch(Exception x)
            {
                MessageBox.Show(x.Message + " " + x.Source);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
