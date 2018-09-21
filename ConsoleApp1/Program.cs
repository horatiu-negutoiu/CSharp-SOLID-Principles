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
            writer.WriteTransaction(this);
        }
    }

    class FoodTransaction : Transaction, ITransaction
    {
        public FoodTransaction(int id, double amount) : base(id, amount)
        {
            this.id = id;
            this.amount = amount;
            this.type = "food";
            this.writer = new Writer();
        }
    }

    class TransportationTransaction : Transaction, ITransaction
    {
        public TransportationTransaction(int id, double amount) : base(id, amount)
        {
            this.id = id;
            this.amount = amount;
            this.type = "transportation";
            this.writer = new Writer();
        }
    }

    class Writer
    {
        public void WriteTransaction(Transaction transaction)
        {
            this.WriteTransactionToConsole(transaction);
        }

        public void WriteTransactionToConsole(Transaction transaction)
        {
            if (transaction.type == "food")
            {
                Console.WriteLine($"Food: ${transaction.amount}");
            }
            else if (transaction.type == "transportation")
            {
                Console.WriteLine($"Transportation: ${transaction.amount}");
            }
        }
    }
}