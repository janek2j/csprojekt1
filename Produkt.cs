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
        private decimal cena;
        private string opis; //??????

        public Produkt(string nazwa, decimal cena)
        {
            this.Nazwa = nazwa;
            this.cena = cena;
            this.opis = "---";
        }

        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public override string ToString()
        {
            return Nazwa + ", " + Cena;
        }
     
    }
}
