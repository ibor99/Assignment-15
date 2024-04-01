using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_15
{
    class Staff : IObserver
    {
        public Staff(string v)
        {
            this.Name = v;
        }

        public string Name { get; set; }

        public void Update(ISubject subject)
        { 
            Console.WriteLine($"{this.Name} :  Order has changed status.");
        }
    }
}
