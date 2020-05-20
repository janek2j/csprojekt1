using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoszykZakupowy
{
    class Pozycja333
    {
        private Produkt produkt;
        private int ilosc;

        public Pozycja333(Produkt produkt, int ilosc)
        {
            this.produkt = produkt;
            this.ilosc = ilosc;
        }

        public Produkt Produkt { get; set; }
        public int Ilosc { get; set; }

    }
}
