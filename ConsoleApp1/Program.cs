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
        void FoodTransactionItemizedListOutput();
        void TransportationTransactionToggleType();
    }

    class Transaction : ITransaction
    {
        public int id;
        public double amount;
        public Writer writer;

        public Transaction(int id, double amount)
        {
            this.id = id;
            this.amount = amount;
            this.writer = new Writer();
        }

        public void OutputTransaction()
        {
            writer.Write($"Transaction: ${this.amount}");
        }

        public void FoodTransactionItemizedListOutput()
        {
            throw new NotImplementedException();
        }

        public void TransportationTransactionToggleType()
        {
            throw new NotImplementedException();
        }
    }

    class FoodTransaction : Transaction, ITransaction
    {
        public List<string> itemizedList;

        public FoodTransaction(int id, double amount) : base(id, amount)
        {
            this.id = id;
            this.amount = amount;
            this.writer = new Writer();
            this.itemizedList = new List<string>();
        }

        public new void OutputTransaction()
        {
            writer.Write($"Food: ${this.amount}");
        }

        public new void FoodTransactionItemizedListOutput()
        {
            foreach (string item in itemizedList)
            {
                writer.Write($"Item: {item}");
            }
        }

        public new void TransportationTransactionToggleType()
        {
            throw new NotImplementedException();
        }
    }

    class TransportationTransaction : Transaction, ITransaction
    {
        public TRANSPORTATION_TYPE transportationType;

        public TransportationTransaction(int id, double amount) : base(id, amount)
        {
            this.id = id;
            this.amount = amount;
            this.writer = new Writer();
            this.transportationType = TRANSPORTATION_TYPE.PUBLIC;
        }

        public new void OutputTransaction()
        {
            writer.Write($"Transportation: ${this.amount}");
        }

        public new void FoodTransactionItemizedListOutput()
        {
            throw new NotImplementedException();
        }

        public new void TransportationTransactionToggleType()
        {
            if (this.transportationType == TRANSPORTATION_TYPE.PUBLIC)
                this.transportationType = TRANSPORTATION_TYPE.PRIVATE;
            else
                this.transportationType = TRANSPORTATION_TYPE.PUBLIC;
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
            writer.Write($"Rent: ${this.amount}");
        }

        public new void FoodTransactionItemizedListOutput()
        {
            throw new NotImplementedException();
        }

        public new void TransportationTransactionToggleType()
        {
            throw new NotImplementedException();
        }
    }

    class Writer
    {
        public void Write(string entry)
        {
            this.WriteToConsole(entry);
        }

        public void WriteToConsole(string entry)
        {
            Console.WriteLine($"{entry}");
        }
    }

    public enum TRANSPORTATION_TYPE
    {
        PUBLIC,
        PRIVATE
    };
}