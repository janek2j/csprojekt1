using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoszykZakupowy
{
    class Pozycja
    {
        public Produkt Produkt { get; set; }
        public int Ilosc { get; set; }
        private double _podsuma;

        public double Podsuma {
            get
            {
                return _podsuma;
            }
            set
            {
                _podsuma = Podsumuj();
            }
        }

        public string PodsumaTekst
        {
            get
            {
                return String.Format("{0:0.00}", Podsuma);
            }
        }

        public Pozycja(Produkt produkt, int ilosc)
        {
            Produkt = produkt;
            Ilosc = ilosc;
            _podsuma = Podsumuj();
        }

        public double Podsumuj()
        {
            return this.Produkt.Cena * this.Ilosc;
        }
    }
}
