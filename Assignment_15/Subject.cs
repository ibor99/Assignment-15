using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_15
{
    public class Subject : ISubject
    {
        //Order List simplified , essential to both staff and customers (Observers)
        public bool isNew = false;
        public Dictionary<string,string> Orders { get; set; } = new Dictionary<string,string>();

        private List<IObserver> _observers = new List<IObserver>();




        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject : Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject : Detached an observer");
        }

        public void Notify()
        {
            Console.WriteLine("Subject : Notifying observers...");

            foreach (var observer in this._observers) 
            {
                observer.Update(this);
            }
            isNew = false;
        }




        //Business Logic

        public void PlaceOrder(IObserver observer, string orderName)
        {
            Console.WriteLine($"{nameof(observer)} placed an order.");
            this.Orders.Add($"{orderName}","Pending");
            isNew = true;

            Thread.Sleep(10);

            Console.WriteLine($"Subject : A new Order has been placed : {this.Orders.Last()}");
            this.Notify();
        }

        public void FulfillOrder(IObserver observer, string orderName)
        {
            if (observer is Staff && this.Orders[orderName] == "Ready to Ship")
            {
                Console.WriteLine($"{nameof(observer)} fullfilled an order.");
                var toRemove = $"[{orderName}, Fullfilled]";
                this.Orders.Remove(orderName);

                Thread.Sleep(10);

                Console.WriteLine($"Subject : An order has been fullfilled and removed (next in queue) : {toRemove}");
                this.Notify();
            }

        }

        public void ReadyToShip(IObserver observer, string orderName)
        {
            if(observer is Staff) 
            {
                Console.WriteLine($"{nameof(observer)} prepared an order for shipping");

                if (this.Orders.ContainsKey(orderName))
                {
                    this.Orders[orderName] = "Ready to Ship";
                }

                Thread.Sleep(10);

                Console.WriteLine($"Subject : An order has been made ready to ship : [{orderName}, {this.Orders[orderName]}]");
            }
        }


    }
}
