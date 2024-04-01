using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment_15.Order;

namespace Assignment_15
{
    //I want to implement an Order class and remove the implementation of the List/Dictionary from the Subject class.
    public class Subject : ISubject
    {
        //Order List simplified , essential to both staff and customers (Observers)

        private OrderRepository OrderRepository = new OrderRepository();

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
            foreach (var order in this.OrderRepository.GetAllOrders())
            {
                if(order.Status == OrderStatus.New)
                {
                    order.Status = OrderStatus.Processing;
                }
            }
        }




        //Business Logic

        public void PlaceOrder(IObserver observer, string orderName)
        {
            Console.WriteLine($"{nameof(observer)} placed an order.");
            this.OrderRepository.AddOrder(new Order(orderName,OrderStatus.New));

            Thread.Sleep(10);

            Console.WriteLine($"Subject : A new Order has been placed : {this.OrderRepository.GetOrder(orderName).Name}");
            this.Notify();
        }

        public void FulfillOrder(IObserver observer, string orderName)
        {
            var order = this.OrderRepository.GetOrder(orderName);
            if (observer is Staff && order != null && order.Status == OrderStatus.Shipped)
            {
                Console.WriteLine($"{nameof(observer)} fullfilled an order.");
                order.Status = OrderStatus.Delivered;
                this.OrderRepository.RemoveOrder(order);

                Thread.Sleep(10);

                Console.WriteLine($"Subject : An order has been fullfilled and removed (next in queue) : {order.Name}");
                this.Notify();
            }

        }

        public void ReadyToShip(IObserver observer, string orderName)
        {
            var order = this.OrderRepository.GetOrder(orderName);
            if(observer is Staff && order != null && order.Status == OrderStatus.Processing) 
            {
                Console.WriteLine($"{nameof(observer)} prepared an order for shipping");
                order.Status = OrderStatus.Shipped;

                Thread.Sleep(10);

                Console.WriteLine($"Subject : An order has been made ready to ship : {order.Name}");
                this.Notify();
            }
        }


    }
}
