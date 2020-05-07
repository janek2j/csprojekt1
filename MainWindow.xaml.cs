using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Collections.ObjectModel;

namespace KoszykZakupowy
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Produkt> produkty = new ObservableCollection<Produkt>();

        public MainWindow()
        {

            ArrayList produkty = new ArrayList();
            InitializeComponent();
            

            Produkt produkt1 = new Produkt("wkręt 5/35", 0.03m);
            Produkt produkt2 = new Produkt("produkt2", 2m);
            Produkt produkt3 = new Produkt("produkt3", 6m);
            Produkt produkt4 = new Produkt("produkt4", 8m);

            produkty.Add(produkt1);
            produkty.Add(produkt2);
            produkty.Add(produkt3);

            ComboBoxProdukty.ItemsSource = produkty;

            foreach (Produkt p in produkty)
            {
                if (p != null)
                {
                    //ComboBoxProdukty.Item
                }
            }
           
            //Simulation simulation = new Simulation();
            //MyObject myObject = new MyObject(simulation);
            //MySecondObject mySecondObject = new MySecondObject(simulation);

            //simulation.simulate();

        }

    }
}
