using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoszykZakupowy
{
    class Koszyk : ISuma
    {
        private Produkt[] produkt;

        public Koszyk(Produkt[] produkty)
        {
            //this.elementyKoszyka. = elementyKoszyka;
        }

        public double SumaRazem()
        {
            return 0.0;
        }
    }
}
