using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class BankAccount
    {
        public string AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public double Balance { get; set; } = 0;

        public BankAccount()
        {

        }

        public BankAccount(string accountNumber, AccountType type, double balance)
        {
            this.AccountNumber = accountNumber;
            this.Type = type;
            this.Balance = balance;
        }

        public override string ToString()
        {
            return string.Format("Account Number: {0}\n" +
                "Account Type: {1}\n" +
                "Account Balance: {2:c}", this.AccountNumber, this.Type, this.Balance);
        }
    }
}
