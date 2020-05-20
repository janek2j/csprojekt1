using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoszykZakupowy
{
    class Produkt
    {
        //private int numerId;
        private double _cena;

        public Produkt(string nazwa, double cena)
        {
            this.Nazwa = nazwa;
            this._cena = cena;
        }

        public string Nazwa { get; set; }
        public double Cena
        {
            get
            {
                return _cena;
            }
            set
            {
                this._cena = Cena;
            }
        }
        public override string ToString()
        {
            return Nazwa + ", " + Cena;
        }

    }
}
