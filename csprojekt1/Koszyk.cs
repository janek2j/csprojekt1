using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoszykZakupowy
{
    class Koszyk : ISuma
    {
        private Produkt[] produkty;

        public Koszyk(Produkt[] produkty)
        {
            this.produkty = produkty;
        }

        public double SumaRazem()
        {
           return 0.0;
        }
        
    }
}
