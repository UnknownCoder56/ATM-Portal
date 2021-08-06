namespace ATM_Portal
{
    public class UserInfo
    {
        public string Name;
        public double AccountNumber;
        public string Password;
        public double Balance;

        public UserInfo(string name, double accountnumber, string password, double balance)
        {
            Name = name;
            AccountNumber = accountnumber;
            Password = password;
            Balance = balance;
        }
    }
}
