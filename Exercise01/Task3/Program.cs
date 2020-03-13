using System;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();

            accounts.Add(new BankAccount("0001", AccountType.CURRENT, 21.4));
            accounts.Add(new BankAccount("0002", AccountType.GIRO, 0));
            accounts.Add(new BankAccount("0003", AccountType.CURRENT, 120.75));
            accounts.Add(new BankAccount("0004", AccountType.SAVINGS, 765.3));
            accounts.Add(new BankAccount("0005", AccountType.GIRO, 213));

            string input = string.Empty;

            while (input.ToUpper() != "Q")
            {
                Console.Write("Enter A to show all accounts; C to create a new account; Q to quit: ");
                input = Console.ReadLine().Trim();

                if (input.ToUpper() == "A")
                {
                    ShowAllAccounts(accounts);
                } else if (input.ToUpper() == "C")
                {
                    CreateBankAccount(accounts);
                }
            }
        }

        static void ShowAllAccounts(List<BankAccount> accounts)
        {
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine("===================================");
                Console.WriteLine(account);
                Console.WriteLine("===================================\n");
            }
        }

        static void CreateBankAccount(List<BankAccount> accounts)
        {
            string accNum;
            int accType;
            double balance;

            Console.Write("Enter account number: ");
            accNum = Console.ReadLine().Trim();

            if (accNum == string.Empty)
            {
                Console.WriteLine("You must enter account number!");
                return;
            }

            Console.Write("Enter account type ({0} - SAVINGS; {1} - CURRENT; {2} - GIRO): ", 
                (int)AccountType.SAVINGS, (int)AccountType.CURRENT, (int)AccountType.GIRO);

            bool typeValid = int.TryParse(Console.ReadLine(), out accType);

            if (!typeValid || !Enum.IsDefined(typeof(AccountType), accType))
            {
                Console.WriteLine("Invalid Type!");
                return;
            }

            Console.Write("Enter account balance: ");
            
            bool balanceValid = double.TryParse(Console.ReadLine(), out balance);

            if (!balanceValid)
            {
                Console.WriteLine("Balance Invalid!");
                return;
            }

            BankAccount newAcc = new BankAccount(accNum, (AccountType)accType, balance);

            accounts.Add(newAcc);

            Console.WriteLine("Account {0} successfully created.", newAcc.AccountNumber);
        }
    }
}
