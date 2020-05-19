using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoszykZakupowy
{
    class Koszyk : ISuma
    {
        private ElementKoszyka[] elementyKoszyka;

        public Koszyk(ElementKoszyka[] elyko)
        {
            this.elementyKoszyka = elyko;
        }

        public double SumaRazem()
        {
            return 0.0;
        }
    }
}
