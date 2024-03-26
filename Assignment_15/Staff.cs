using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_15
{
    class Staff : IObserver
    {
        public void Update(ISubject subject)
        {
            if((subject as Subject).Orders.Count > 0)
            {
                Console.WriteLine("Staff : New order notification.");
            }
        }
    }
}
