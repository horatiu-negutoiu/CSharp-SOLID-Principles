namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction(0, 10.40),
                new Transaction(1, -5.00),
            };

            foreach (Transaction transaction in transactions)
            {
                transaction.OutputTransaction();
            }
            Console.ReadKey();
        }
    }

    class Transaction
    {
        public int id;
        public double amount;

        public Transaction(int id, double amount)
        {
            this.id = id;
            this.amount = amount;
        }

        public void OutputTransaction()
        {
            Console.WriteLine("Transaction [{this.id.ToString()}] - ${this.amount.ToString()}");
        }
    }
}