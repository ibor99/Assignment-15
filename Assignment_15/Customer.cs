using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_15
{
    class Customer : IObserver
    {
        public void Update(ISubject subject)
        {
            if((subject as Subject).isNew == true) 
            {
                Console.WriteLine("Customer :  Sent a notification to Customer.");
            }
        }
    }
}
