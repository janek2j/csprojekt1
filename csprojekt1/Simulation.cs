using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoszykZakupowy
{
    class Simulation
    {
        public delegate void OnEventThatCurrentTimeIsEven(string msg);
        public event OnEventThatCurrentTimeIsEven listOfSubscribers;
        

        public int CurrentTime;

        public void simulate()
        {
            while (CurrentTime < 10)
            {
                if (CurrentTime % 2 == 0)
                {
                    Console.WriteLine(CurrentTime);
                    raiseEventCurrentTimeIsEven("CurrentTime= " + CurrentTime);
         
                }
                System.Threading.Thread.Sleep(100);
                CurrentTime++;
            }
            Console.ReadLine();
        }

        public void raiseEventCurrentTimeIsEven(string msg)
        {
            if (listOfSubscribers != null)
                listOfSubscribers(msg);
        }

        public Simulation()
        {
            CurrentTime = 0;
        }
    }
}
