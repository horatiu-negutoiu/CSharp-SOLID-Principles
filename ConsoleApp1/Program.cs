namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, ITransaction> transactions = new Dictionary<int, ITransaction>();
            transactions.Add(0, new FoodTransaction(0, 10.40));
            transactions.Add(1, new TransportationTransaction(1, -5.00));

            foreach (KeyValuePair<int, ITransaction> transactionEntry in transactions)
            {
                transactionEntry.Value.OutputTransaction();
            }
            Console.ReadKey();
        }
    }

    interface ITransaction
    {
        void OutputTransaction();
    }

    class Transaction : ITransaction
    {
        public int id;
        public double amount;
        public string type;
        public Writer writer;

        public Transaction(int id, double amount)
        {
            this.id = id;
            this.amount = amount;
            this.writer = new Writer();
        }

        public void OutputTransaction()
        {
            writer.WriteTransaction($"Transaction: ${this.amount}");
        }
    }

    class FoodTransaction : Transaction, ITransaction
    {
        public FoodTransaction(int id, double amount) : base(id, amount)
        {
            this.id = id;
            this.amount = amount;
            this.writer = new Writer();
        }

        public new void OutputTransaction()
        {
            writer.WriteTransaction($"Food: ${this.amount}");
        }
    }

    class TransportationTransaction : Transaction, ITransaction
    {
        public TransportationTransaction(int id, double amount) : base(id, amount)
        {
            this.id = id;
            this.amount = amount;
            this.writer = new Writer();
        }

        public new void OutputTransaction()
        {
            writer.WriteTransaction($"Transportation: ${this.amount}");
        }
    }

    class RentTransaction : Transaction, ITransaction
    {
        public RentTransaction(int id, double amount) : base(id, amount)
        {
            this.id = id;
            this.amount = amount;
            this.writer = new Writer();
        }

        public new void OutputTransaction()
        {
            writer.WriteTransaction($"Rent: ${this.amount}");
        }
    }

    class Writer
    {
        public void WriteTransaction(string transactionEntry)
        {
            this.WriteTransactionToConsole(transactionEntry);
        }

        public void WriteTransactionToConsole(string transactionEntry)
        {
            Console.WriteLine($"{transactionEntry}");
        }
    }
}