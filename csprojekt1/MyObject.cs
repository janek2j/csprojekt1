﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoszykZakupowy
{
    class MyObject
    {
        public MyObject(Simulation simulation)
        {
            simulation.listOfSubscribers += Print;
        }

        public void Print(string msg)
        {
            Console.WriteLine(msg + " MyObject");
        }
    }
}