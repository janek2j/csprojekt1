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

namespace KoszykZakupowy
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Produkt produkt1 = new Produkt("wkręt 5/35", 0.03m);
            Produkt produkt2 = new Produkt("produtk2", 2m);
            Produkt produkt3 = new Produkt("produtk3", 6m);

            produkt1.Nazwa = "produkt1";

            Console.WriteLine(produkt1.ToString());


            Simulation simulation = new Simulation();
            MyObject myObject = new MyObject(simulation);
            MySecondObject mySecondObject = new MySecondObject(simulation);

            simulation.simulate();


        }

        private void Button_uruchom(object sender, RoutedEventArgs e)
        {
           

            textblock1.Text = "sgfkhdsfk";
        }
    }
}
