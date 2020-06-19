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

      

        private void ButtonDodajDoKoszyka_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxProdukty.SelectedItem != null)
            {
                //str = ComboBoxProdukty.SelectedItem.ToString();
                //int index = ComboBoxProdukty.SelectedIndex;
                Produkt produkt = (Produkt)ComboBoxProdukty.SelectedItem;
                int ilosc = Convert.ToInt32(TextBoxLiczbaSztuk.Text);

                //int tempIlosc = ilosc;
                bool duplikat = false; //czy w koszyku jest juz ten produkt (produkt o tej samej nazwie)
                
                foreach (Pozycja poz in koszyk.Pozycje)
                {
                    if (poz.Produkt.Nazwa == produkt.Nazwa)
                    {
                        poz.Ilosc = ilosc + poz.Ilosc;
                        duplikat = true;
                        break;
                    }
                }

                if (duplikat == false) {
                    Pozycja pozycja = new Pozycja(produkt, ilosc);
                    //ListBoxListaElementow.Items.Add(pozycja);
                    koszyk.Pozycje.Add(pozycja);
                } 

            }

            ListBoxListaElementow.ItemsSource = null;
            ListBoxListaElementow.ItemsSource = koszyk.Pozycje;
            //TextBlockSumaRazem.IsEnabled = true;
            TextBlockSumaRazem.Text = Convert.ToString(koszyk.SumaRazem());
        }

        

        private void ButtonUsunZKoszyka_Click(object sender, RoutedEventArgs e)
        {
            int index = ListBoxListaElementow.SelectedIndex;
            object selectedItem = ListBoxListaElementow.SelectedItem;
            
            Pozycja pozycja;

            if (index != -1)
               
            {                

                pozycja = (Pozycja)selectedItem;

                int ind;
                foreach (Pozycja poz in koszyk.Pozycje)
                {
                    
                    if (pozycja.Produkt.Nazwa == poz.Produkt.Nazwa)
                    {
                        ind = koszyk.Pozycje.IndexOf(pozycja);
                        //koszyk.Pozycje.RemoveAt(ind);
                        koszyk.Pozycje.Remove(poz);
                        MessageBox.Show(ind + " ; " + poz.Produkt.Nazwa);
                        break;
                    }
                }
                ListBoxListaElementow.ItemsSource = null;
                ListBoxListaElementow.ItemsSource = koszyk.Pozycje;
                TextBlockSumaRazem.Text = Convert.ToString(koszyk.SumaRazem());
            }
            
        }

       private void ListBoxListaElementow_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void ListBoxListaImion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var str = ListBoxListaElementow.SelectedItem.ToString();
            //MessageBox.Show(ListBoxListaImion.SelectedIndex.ToString() + " ---- " + str);
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

        private void WyslijZamowienie_Click(object sender, RoutedEventArgs e)
        {
            Zamowienie zamowienie = new Zamowienie(koszyk);

            string str = "Twoje zamówienie: \n";

            if (zamowienie.Koszyk.Pozycje == null)
            {
                MessageBox.Show("Koszyk jest pusty!");
            }
            else
            {
                foreach (Pozycja poz in zamowienie.Koszyk.Pozycje)
                {
                    if (poz != null)
                    {
                        str = str + "\nProdukt: " + poz.Produkt.Nazwa + ",  Cena/szt.: " + poz.Produkt.Cena + ", Ilosc: " + poz.Ilosc;
                    }

                    str = str + "\n\nZamówienie zostało wysłane."
                }

                MessageBox.Show(str);
            }
            
        }
    }
}
