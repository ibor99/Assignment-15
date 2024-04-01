using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_15
{
    class Customer : IObserver
    {
        public Customer(string v)
        {
            this.Name = v;
        }
        public string Name { get; set; }
        public void Update(ISubject subject)
        {
            Console.WriteLine($"{this.Name} :  Sent a notification to Customer.");
        }
    }
}
