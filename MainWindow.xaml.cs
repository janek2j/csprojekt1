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
using System.ComponentModel;

namespace KoszykZakupowy
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Pozycja> listaElementyKoszyka = new ObservableCollection<Pozycja>();
        Koszyk koszyk = new Koszyk();
        ObservableCollection<Koszyk> listaKoszyk = new ObservableCollection<Koszyk>();

        public MainWindow()
        {
            InitializeComponent();

            ArrayList produkty = new ArrayList();
            produkty = ZainicjujListeProduktow();


            Pozycja elko1 = new Pozycja((Produkt)produkty[0], 1);
            Pozycja elko2 = new Pozycja((Produkt)produkty[1], 12);
            Pozycja elko3 = new Pozycja((Produkt)produkty[2], 5);

            koszyk.Add(elko1);
            koszyk.Add(elko2);
            koszyk.Add(elko3);
            ListBoxListaElementow.ItemsSource = koszyk.Pozycje;
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

        private void ButtonDodajDoKoszyka_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxProdukty.SelectedItem != null)
            {
                //str = ComboBoxProdukty.SelectedItem.ToString();
                //int index = ComboBoxProdukty.SelectedIndex;
                Produkt produkt = (Produkt)ComboBoxProdukty.SelectedItem;
                int ilosc = Convert.ToInt32(TextBoxLiczbaSztuk.Text);

                Pozycja pozycja = new Pozycja(produkt, ilosc);
                //ListBoxListaElementow.Items.Add(pozycja);
                koszyk.Pozycje.Add(pozycja);
            }
        }

        private void ButtonDodajDoKoszyka2_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxProdukty.SelectedItem != null)
            {
                string str = ComboBoxProdukty.SelectedItem.ToString();
                ListBoxKoszyk.Items.Add(str);
            }
        }

        //private void ButtonDodajProdukt_Click(object sender, RoutedEventArgs e)
        //{
        //    string str = TextBoxProdukt.Text;
        //    ComboBoxProdukty.Items.Add(str);
        //}


        private void ButtonWyswietlSzczegoly_Click(object sender, RoutedEventArgs e)
        {
            //object li = ListBoxKoszyk.SelectedItem.ToString();  //.Items.CurrentItem;
            object li = ListBoxKoszyk.SelectedItem.ToString();   //.Items.CurrentItem;

            int k = ListBoxKoszyk.SelectedIndex;

            MessageBox.Show(li.ToString() + ", indeks: " + k);
        }

        private void ButtonUsunZKoszyka_Click(object sender, RoutedEventArgs e)
        {
            int index = ListBoxListaElementow.SelectedIndex;
            if (index != -1)
            {
                ListBoxKoszyk.Items.RemoveAt(index);

            }
        }

        private void ButtonUsunZKoszyka2_Click(object sender, RoutedEventArgs e)
        {
            int k = ListBoxKoszyk.SelectedIndex;
            if (k != -1)
                ListBoxKoszyk.Items.RemoveAt(k);
        }

        private void ListBoxListaElementow_SelectionChanged(object sender, EventArgs e)
        {
            Pozycja elko = (Pozycja)ListBoxListaElementow.SelectedItem;
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
            Pozycja elko = (Pozycja)ListBoxListaElementow.SelectedItem;

            int index = ListBoxListaElementow.SelectedIndex;

            if (index != -1)
            {
                string nazwaProduktu = elko.Produkt.Nazwa;
                double cenaProduktu = elko.Produkt.Cena;
                int ilosc = elko.Ilosc;

                nowaIlosc = Convert.ToInt32(TextBoxIlosc.Text);

                koszyk.Pozycje.RemoveAt(index);
                koszyk.Pozycje.Insert(index, new Pozycja(new Produkt(nazwaProduktu, cenaProduktu), nowaIlosc));

                MessageBox.Show("Index= " + index);
            }
        }

        private ArrayList ZainicjujListeProduktow()
        {
            ArrayList produkty = new ArrayList();
            Produkt produkt1 = new Produkt("produkt1", 0.23);
            Produkt produkt2 = new Produkt("produkt2", 2.99);
            Produkt produkt3 = new Produkt("produkt3", 6.30);
            Produkt produkt4 = new Produkt("produkt4", 1.76);

            produkty.Add(produkt1);
            produkty.Add(produkt2);
            produkty.Add(produkt3);
            produkty.Add(produkt4);

            foreach (Produkt p in produkty)
            {
                if (p != null)
                {
                    ComboBoxProdukty.Items.Add(p);
                }
            }

            return produkty;
        }

        private void ComboBoxProdukty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBoxLiczbaSztuk.Text = "1";
            Produkt produkt = (Produkt)ComboBoxProdukty.SelectedItem;
            TextBoxCenaJednostkowa.Text = Convert.ToString(produkt.Cena);
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            string str = "";
            double sumaRazem = koszyk.SumaRazem();
            int len = koszyk.Pozycje.Count;

            foreach (Pozycja pozycja in koszyk.Pozycje)
            {
                str = str + "\n" + pozycja.Produkt.Nazwa + "  " + pozycja.Produkt.Cena + "  " + pozycja.Ilosc + "  " + pozycja.Podsuma;
            }
            MessageBox.Show("Liczba pozycji: " + Convert.ToString(len) + str);
        }

        private void ListBoxListaElementow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("wybór");
        }
    }
}
