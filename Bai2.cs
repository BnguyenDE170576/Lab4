using System;

namespace LAB4
{
    internal class Bai2
    {
        // Define a delegate for the event
        public delegate void BalanceChangedEventHandler(object sender, BalanceChangedEventArgs e);

        public class BalanceChangedEventArgs : EventArgs
        {
            public BalanceChangedEventArgs(double amount)
            {
                Amount = amount;
            }

            public double Amount { get; }
        }

        public class Account
        {
            // Use the delegate for the event
            public event BalanceChangedEventHandler BalanceChanged;

            private double balance;

            public void Deposit(double amount)
            {
                balance += amount;
                OnBalanceChanged(amount);
            }

            protected virtual void OnBalanceChanged(double amount)
            {
                // Check if there are any subscribers before invoking the event
                BalanceChanged?.Invoke(this, new BalanceChangedEventArgs(amount));
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Account account = new Account();

                // Subscribe to the event with an event handler
                account.BalanceChanged += Account_BalanceChanged;

                account.Deposit(1000);
                account.Deposit(2000);

                Console.ReadLine();
            }

            private static void Account_BalanceChanged(object sender, BalanceChangedEventArgs e)
            {
                Console.WriteLine($"New account balance: {e.Amount}");
            }
        }
    }
}
