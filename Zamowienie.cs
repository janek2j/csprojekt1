using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KoszykZakupowy
{
    class Zamowienie : ISuma
    {

        private Koszyk koszyk;

        public Zamowienie(Koszyk koszyk)
        {
            this.koszyk = koszyk;
        }

        public Koszyk Koszyk {
            get {
                return koszyk;
            }
        }

        public double SumaRazem()
        {
            return koszyk.SumaRazem();
        }

        public string Opis()
        {
            string str = "";
            foreach (Pozycja poz in this.Koszyk.Pozycje)
            {
                if (poz != null)
                {
                    str = str + "\nProdukt: " + poz.Produkt.Nazwa + ",  Cena/szt.: " + poz.Produkt.Cena + ", Ilosc: " + poz.Ilosc;
                }
            }
            str = str + "\n\nSuma razem: " + string.Format("{0:0.00}", this.SumaRazem()) + " zł";
      
            return str;
        }
    }
}
