using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This code demonstrates the Chain of Responsibility pattern in which several linked managers and executives
/// can respond to purchase request or hand it off to a superior. Each position can have its own set of rules
/// which orders they can approve.
/// </summary>
namespace ChainOfResponsiblity
{
    class Client
    {
        static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Approver ronny = new Director();
            Approver bobby = new VicePresident();
            Approver ricky = new President();

            ronny.SetSuccessor(bobby);
            bobby.SetSuccessor(ricky);

            // Generate and process purchase requests
            Purchase p = new Purchase(8887, 1234.00, "Assests");
            ronny.ProcessRequest(p);

            p = new Purchase(8888, 12345.00, "Project Poison");
            ronny.ProcessRequest(p);

            p = new Purchase(8889, 123456.00, "Project BBD");
            ronny.ProcessRequest(p);

            Console.ReadLine();
        }
    }

    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            { // we pass the request forth
                successor.ProcessRequest(purchase);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            { // we pass the request forth
                successor.ProcessRequest(purchase);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            }
            else 
            { // it's the last chain-link, nowhere to go forth
                Console.WriteLine($"{purchase.Number} requires an executive meeting!");
            }
        }
    }

    /// <summary>
    /// Class holding request details
    /// </summary>
    class Purchase
    {
        private int _number;
        private double _amount;
        private string _purpose;

        public Purchase(int number, double amount, string purpose)
        {
            this._number = number;
            this._amount = amount;
            this._purpose = purpose;
        }
            
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
     
        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }
    }
}
