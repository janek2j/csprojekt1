﻿using System;
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


            Produkt produkt1 = new Produkt("wkręt 5/35", 0.03m);
            Produkt produkt2 = new Produkt("produkt2", 2m);
            Produkt produkt3 = new Produkt("produkt3", 6m);
            Produkt produkt4 = new Produkt("produkt4", 8m);
            Produkt produkt5 = new Produkt("produkt5", 10.01m);
            Produkt produkt6 = new Produkt("produkt6", 14.21m);

            produkty.Add(produkt1);
            produkty.Add(produkt2);
            produkty.Add(produkt3);
            produkty.Add(produkt4);
            produkty.Add(produkt5);
            produkty.Add(produkt6);

            ElementKoszyka elko1, elko2, elko3;
            elko1.produkt = produkt1;
            elko1.ilosc = 1;
            elko2.produkt = produkt2;
            elko2.ilosc = 12;
            elko3.produkt = produkt3;
            elko3.ilosc = 5;


            listaElementyKoszyka.Add(elko1);
            listaElementyKoszyka.Add(elko2);
            listaElementyKoszyka.Add(elko3);

            ListBoxListaImion.ItemsSource = listaElementyKoszyka;

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

        private void ListBoxListaImion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var str = ListBoxListaImion.SelectedItem.ToString();
            //MessageBox.Show(ListBoxListaImion.SelectedIndex.ToString() + " ---- " + str);

        }
    }
}
