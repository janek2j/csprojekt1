﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoszykZakupowy
{
    class Produkt
    {
        private decimal cena;

        public Produkt(string nazwa, decimal cena)
        {
            this.Nazwa = nazwa;
            this.cena = cena;
        }

        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public override string ToString()
        {
            return Nazwa + ", " + Cena;
        }
     
    }
}
