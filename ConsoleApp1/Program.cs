namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new DatabaseWriter();
            Dictionary<int, ITransaction> transactions = new Dictionary<int, ITransaction>();
            IFoodTransaction foodTransaction = new FoodTransaction(
                writer,
                0,
                10.40,
                new List<string> { "water", "soap" });
            ITransportationTransaction transportationTransaction = new TransportationTransaction(
                writer,
                1,
                40.00,
                TRANSPORTATION_TYPE.PRIVATE);
            IRentTransaction rentTransaction = new RentTransaction(
                writer,
                2,
                1000);

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
        public IWriter writer;

        public Transaction(IWriter writer, int id, double amount)
        {
            this.id = id;
            this.amount = amount;
            this.writer = writer;
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
        public IWriter writer;
        public List<string> itemizedList;

        public FoodTransaction(IWriter writer, int id, double amount, List<string> itemizedList)
        {
            this.id = id;
            this.amount = amount;
            this.writer = writer;
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
        public IWriter writer;
        public TRANSPORTATION_TYPE transportationType;

        public TransportationTransaction(IWriter writer,
            int id,
            double amount,
            TRANSPORTATION_TYPE transportationType = TRANSPORTATION_TYPE.PUBLIC)
        {
            this.id = id;
            this.amount = amount;
            this.writer = writer;
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
        public IWriter writer;

        public RentTransaction(IWriter writer, int id, double amount)
        {
            this.id = id;
            this.amount = amount;
            this.writer = writer;
        }

        public void OutputTransaction()
        {
            writer.Write($"Rent: ${this.amount}");
        }
    }

    interface IWriter
    {
        void Write(string entry);
    }

    interface IConsoleWriter : IWriter
    {
        void WriteToConsole(string entry);
    }

    class ConsoleWriter : IConsoleWriter
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

    interface IDatabaseWriter : IWriter
    {
        void WriteToDatabase(string entry);
    }

    class DatabaseWriter : IDatabaseWriter
    {
        public void Write(string entry)
        {
            this.WriteToDatabase(entry);
        }

        public void WriteToDatabase(string entry)
        {
            // writes the entry to the database
        }
    }

    public enum TRANSPORTATION_TYPE
    {
        PUBLIC,
        PRIVATE
    };
}