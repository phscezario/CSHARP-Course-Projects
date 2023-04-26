using System;
using System.Collections.Generic;

namespace Bank.Application
{
    class Program
    {
        static List<Account> accountList = new List<Account>();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAccount();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Draw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                  userOption = GetUserOption();
            }

            Console.WriteLine("Thank you to use our application.");
            Console.ReadLine();
        }

        private static void ListAccount()
        {
            Console.WriteLine("List of Accounts.");

            if (accountList.Count == 0)
            {
                Console.WriteLine("No item registred.");
                return;
            }

            for (int i = 0; i < accountList.Count; i++)
            {
                Account account = accountList[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(account);
            }
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Insert Account");

            Console.Write("Insert 1 for Legal Person or 2 for Legal Entity: ");
            int typeAccountEntry = int.Parse(Console.ReadLine());

            Console.Write("Insert User name: ");
            string entryName = Console.ReadLine();

            Console.Write("Insert initial fund: ");
            double entryFunds = double.Parse(Console.ReadLine());

            Console.Write("Insert the credit: ");
            double entryCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountType: (AccountType)typeAccountEntry,
                                             funds: entryFunds,
                                             credit: entryCredit,
                                             name:  entryName);

            accountList.Add(newAccount);
        }

        private static void Transfer()
        {
            Console.Write("Insert the source account number: ");
            int sourceAccountNumber = int.Parse(Console.ReadLine());

            Console.Write("Insert the target account number: ");
            int targetAccountValue = int.Parse(Console.ReadLine());

            Console.Write("Insert the transfer value: ");
            double transferValue = double.Parse(Console.ReadLine());

            accountList[sourceAccountNumber].Transfer(transferValue, accountList[targetAccountValue]);
        }

        private static void Draw()
        {
            Console.Write("Insert the account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Insert the draw value: ");
            double drawValue = double.Parse(Console.ReadLine());

            accountList[accountNumber].DrawMoney(drawValue);
        }

        private static void Deposit()
        {
            Console.Write("Insert the account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Insert the draw value: ");
            double depositValue = double.Parse(Console.ReadLine());

            accountList[accountNumber].Deposit(depositValue);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Bank Application simulator!!!");
            Console.WriteLine("Enter you choice:");

            Console.WriteLine();
            Console.WriteLine("Enter the new choice:");
            Console.WriteLine("1- List accounts");
            Console.WriteLine("2- Insert new account");
            Console.WriteLine("3- Transfer");
            Console.WriteLine("4- Draw");
            Console.WriteLine("5- Deposit");
            Console.WriteLine("C- Screen clear");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
