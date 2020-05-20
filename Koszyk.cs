using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KoszykZakupowy
{
    class Koszyk : ISuma, INotifyPropertyChanged
    {
        public List<Pozycja> Pozycje { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        private int _licznik;

        public int Licznik
        {
            get { return _licznik; }
            set { _licznik = value;
                OnPropertyChanged("Licznik");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public Koszyk()
        {
            Pozycje = new List<Pozycja>();
            Licznik = 0;
        }


        public double SumaRazem()
        {
            double suma = 0;
            if (Pozycje != null)
            {
                foreach (Pozycja pozycja in Pozycje)
                {
                    suma = suma + pozycja.Podsumuj();
                }
            }
            return suma;
        }

        public void Add(Pozycja p)
        {
            Pozycje.Add(p);
            Licznik += 1;
            //OnPropertyChanged("Pozycje");
            OnPropertyChanged("Licznik");
        }
    }
}
