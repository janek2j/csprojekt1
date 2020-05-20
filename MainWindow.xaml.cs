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
        //ObservableCollection<Produkt> produkty = new ObservableCollection<Produkt>();
        ObservableCollection<ElementKoszyka> listaElementyKoszyka = new ObservableCollection<ElementKoszyka>();

        public MainWindow()
        {
            ArrayList produkty = new ArrayList();
            InitializeComponent();

            Produkt produkt1 = new Produkt("wkręt 5/35", 0.03);
            Produkt produkt2 = new Produkt("produkt2", 2.99);
            Produkt produkt3 = new Produkt("produkt3", 6.30);
            Produkt produkt4 = new Produkt("produkt4", 8.0);
            Produkt produkt5 = new Produkt("produkt5", 10.01);
            Produkt produkt6 = new Produkt("produkt6", 14.21);

            produkty.Add(produkt1);
            produkty.Add(produkt2);
            produkty.Add(produkt3);
            produkty.Add(produkt4);
            produkty.Add(produkt5);
            produkty.Add(produkt6);

            ElementKoszyka elko1 = new ElementKoszyka(produkt1, 1);
            ElementKoszyka elko2 = new ElementKoszyka(produkt2, 12);
            ElementKoszyka elko3 = new ElementKoszyka(produkt3, 5);

            listaElementyKoszyka.Add(elko1);
            listaElementyKoszyka.Add(elko2);
            listaElementyKoszyka.Add(elko3);

            ListBoxListaElementow.ItemsSource = listaElementyKoszyka;

            //ComboBoxProdukty.ItemsSource = produkty;

            foreach (Produkt p in produkty)
            {
                if (p != null)
                {
                    ComboBoxProdukty.Items.Add(p);
                }
            }

            //Simulation simulation = new Simulation();
            //MyObject myObject = new MyObject(simulation);
            //MySecondObject mySecondObject = new MySecondObject(simulation);
            //simulation.simulate();
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            string str;
            if (ComboBoxProdukty.SelectedItem != null)
            {
                str = ComboBoxProdukty.SelectedItem.ToString();
                ListBoxKoszyk.Items.Add(str);
            }
        }

        private void ButtonDodajProdukt_Click(object sender, RoutedEventArgs e)
        {
            string str = TextBoxProdukt.Text;
            ComboBoxProdukty.Items.Add(str);
        }

        private void ButtonWyswietlListeProduktow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonWyswietlSzczegoly_Click(object sender, RoutedEventArgs e)
        {
            //object li = ListBoxKoszyk.SelectedItem.ToString();  //.Items.CurrentItem;
            object li = ListBoxKoszyk.SelectedItem.ToString();   //.Items.CurrentItem;

            int k = ListBoxKoszyk.SelectedIndex;

            MessageBox.Show(li.ToString() + ", indeks: " + k);
        }

        private void ButtonUsun_Click(object sender, RoutedEventArgs e)
        {
            int k = ListBoxKoszyk.SelectedIndex;
            if (k != -1)
                ListBoxKoszyk.Items.RemoveAt(k);
        }

        private void ListBoxListaElementow_SelectionChanged(object sender, EventArgs e)
        {
            ElementKoszyka elko = (ElementKoszyka)ListBoxListaElementow.SelectedItem;
            try
            {
                TextBoxProdukt.Text = elko.Produkt.Nazwa;
                TextBoxIlosc.Text = Convert.ToString(elko.Ilosc);
                //TextBoxIlosc.Text = String.Format("{0:0.00}", elko.Ilosc); //string.Format("{0:0.000}", number)
            }
            catch
            {

            }
        }

        private void ListBoxListaImion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var str = ListBoxListaElementow.SelectedItem.ToString();
            //MessageBox.Show(ListBoxListaImion.SelectedIndex.ToString() + " ---- " + str);
        }

        private void ButtonZmienIlosc_Click(object sender, RoutedEventArgs e)
        {
            int nowaIlosc;
            ElementKoszyka elko = (ElementKoszyka)ListBoxListaElementow.SelectedItem;

            int index = ListBoxListaElementow.SelectedIndex;

            if (index != -1)
            {
                string nazwaProduktu = elko.Produkt.Nazwa;
                double cenaProduktu = elko.Produkt.Cena;
                int ilosc = elko.Ilosc;

                nowaIlosc = Convert.ToInt32(TextBoxIlosc.Text);

                listaElementyKoszyka.RemoveAt(index);
                listaElementyKoszyka.Insert(index, new ElementKoszyka(new Produkt(nazwaProduktu, cenaProduktu), nowaIlosc));
                //ListBoxListaElementow.Items.RemoveAt(index);
                //ListBoxListaElementow.Items.Insert(index, new ElementKoszyka(new Produkt(nazwaProduktu, cenaProduktu), ilosc));
            }
        }
    }
}
