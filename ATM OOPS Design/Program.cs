using System;
using System.Collections.Generic;

namespace ATM_OOPS_Design
{
    // https://www.educative.io/courses/grokking-the-object-oriented-design-interview/m22LWKgQ4Wr
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public enum TransactionType
        {
            Withdraw,
            Deposit,
            CheckBalance,
            PinChange
        }

        public enum AccountStatus
        {
            Blocked,
            Unblocked,
            Active,
            Hold
        }

        public enum TransactionStatus
        {
            Completed,
            InProgress,
            Hold
        }

        public class Address
        {
            public string Country { get; set; }
            public string State{ get; set; }
            public string District { get; set; }
            public string PinCode{ get; set; }
        }

        public class Customer
        {
            Card Card;
            Account Account;
            AccountStatus AccountStatus;
            bool MakeTransaction(Transaction transaction);
        }

        public class Card
        {
            public int No { get; set; }
            public DateTime Expiry { get; set; }
            public string CVV{ get; set; }
        }

        public class Account
        {
            Bank Bank;
            string accountNo;
            int balance;
            int getBalance();
        }

        public class Bank
        {
            Address Address;
            List<ATM> atms;
            string name;
            string Code;
            bool AddATM(ATM atm);
            List<ATM> getAllAtms();
        }

        public class ATM
        {
            string Code;
            CashDispencer CashDispencer;
            Monitor Monitor;
            KeyBoard KeyBoard;
            Printer Printer;

            bool PerformTransaction(Transaction transaction, Customer customer);
            bool Validate(Account account);
        }

        public class CashDispencer
        {
            int NoOfHundredotesAvilable;
            int NoOfFiveHundredNotesAvilable;
            int NoOfThousandNotesAvilable;
            bool CanDispence();
            bool DispenceAmount(int amount);
        }

        public class Monitor
        {
            bool ShowMessage(string msg);
            bool Perform(int type);
        }

        public class KeyBoard
        {
            bool GetInput(string input);
        }

        public class Printer
        {
            bool Print(Transaction transaction);
        }

        public abstract class Transaction
        {
            int no;
            DateTime transactinDate;
            TransactionStatus TransactionStatus;
            TransactionType TransactionType;
            bool DoTransaction();
        }

        public class WithDraw : Transaction
        {
            int amount;
            bool WithDraw(int amount);
        }

        public class Deposit : Transaction
        {
            int amount;
            bool Deposit(int amount);
        }
        public class Transfer: Transaction
        {
            string destinationAccountNo;
            bool Transfer(int amount);
            bool IsValidAccount(Account account);
        }

    }
}
