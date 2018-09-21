namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, ITransaction> transactions = new Dictionary<int, ITransaction>();
            IFoodTransaction foodTransaction = new FoodTransaction(0,
                10.40,
                new List<string> { "water", "soap" });
            ITransportationTransaction transportationTransaction = new TransportationTransaction(
                1,
                40.00,
                TRANSPORTATION_TYPE.PRIVATE);
            IRentTransaction rentTransaction = new RentTransaction(2, 1000);

            transactions.Add(0, foodTransaction);
            transactions.Add(1, transportationTransaction);
            transactions.Add(2, rentTransaction);

            foodTransaction.FoodTransactionItemizedListOutput();
            transportationTransaction.TransportationTransactionToggleType();

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
    }

    interface IFoodTransaction : ITransaction
    {
        void FoodTransactionItemizedListOutput();
    }

    class FoodTransaction : IFoodTransaction
    {
        public int id;
        public double amount;
        public Writer writer;
        public List<string> itemizedList;

        public FoodTransaction(int id, double amount, List<string> itemizedList)
        {
            this.id = id;
            this.amount = amount;
            this.writer = new Writer();
            this.itemizedList = itemizedList;
        }

        public void OutputTransaction()
        {
            writer.Write($"Food: ${this.amount}");
        }

        public void FoodTransactionItemizedListOutput()
        {
            foreach (string item in itemizedList)
            {
                writer.Write($"Item: {item}");
            }
        }
    }

    interface ITransportationTransaction : ITransaction
    {
        void TransportationTransactionToggleType();
    }

    class TransportationTransaction : ITransportationTransaction
    {
        public int id;
        public double amount;
        public Writer writer;
        public TRANSPORTATION_TYPE transportationType;

        public TransportationTransaction(int id,
            double amount,
            TRANSPORTATION_TYPE transportationType = TRANSPORTATION_TYPE.PUBLIC)
        {
            this.id = id;
            this.amount = amount;
            this.writer = new Writer();
            this.transportationType = transportationType;
        }

        public void OutputTransaction()
        {
            writer.Write($"Transportation: ${this.amount}");
        }

        public void TransportationTransactionToggleType()
        {
            if (this.transportationType == TRANSPORTATION_TYPE.PUBLIC)
                this.transportationType = TRANSPORTATION_TYPE.PRIVATE;
            else
                this.transportationType = TRANSPORTATION_TYPE.PUBLIC;
        }
    }

    interface IRentTransaction : ITransaction
    {

    }

    class RentTransaction : IRentTransaction
    {
        public int id;
        public double amount;
        public Writer writer;

        public RentTransaction(int id, double amount)
        {
            this.id = id;
            this.amount = amount;
            this.writer = new Writer();
        }

        public void OutputTransaction()
        {
            writer.Write($"Rent: ${this.amount}");
        }
    }

    interface IWriter
    {
        void Write(string entry);
        void WriteToConsole(string entry);
    }

    class Writer : IWriter
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