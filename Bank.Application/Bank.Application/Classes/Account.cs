using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Application
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double Funds { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(AccountType accountType, double funds, double credit, string name)
        {
            AccountType = accountType;
            Funds = funds;
            Credit = credit;
            Name = name;
        }

        public bool DrawMoney(double drawValue)
        {
            if (Funds - drawValue < (Credit * -1))
            {
                Console.WriteLine("Insufficient funds.");
                return false;
            }

            Funds -= drawValue;
            GetFunds();
            return true;
        }

        public void Deposit(double depositValue)
        {
            Funds += depositValue;
            GetFunds();
        }

        public void Transfer(double transferValue, Account destinationAccount)
        {
            if (DrawMoney(transferValue))
                destinationAccount.Deposit(transferValue);
        }

        public override string ToString()
        {
            string returning = "";
            returning += "Account Type: " + AccountType + " | ";
            returning += "Name: " + Name + " | ";
            returning += "Funds: " + Funds + " | ";
            returning += "Credit: " + Credit + " | ";
            return returning;
        }

        public void GetFunds()
        {
            Console.WriteLine($"{Name}, your current funds is: {Funds}.");
        }

    }
}
