using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoszykZakupowy
{
    class Zamowienie : ISuma
    {

        private Koszyk koszyk;

        public Zamowienie(Koszyk koszyk)
        {
            this.koszyk = koszyk;
        }

        public Koszyk Koszyk { get; }

        public double SumaRazem()
        {
            return 0.0;
        }
    }
}
