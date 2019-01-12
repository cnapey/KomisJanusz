using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace KomisJanusz.Komponenty
{
    /// <summary>
    /// Logika interakcji dla klasy okno3.xaml
    /// </summary>
    public partial class okno3 : Window
    {
        public okno3()
        {
            InitializeComponent();

                List<User> items = new List<User>();
                items.Add(new User (1972, 2000));
                items.Add(new User (1972, 25000));
                lvUsers.ItemsSource = items;
        }

        public class User
        {
            public User(int v1, int v2)
            {
            }

            public int Marka { get; set; }
            public int Model { get; set; }
        }
        /*      private void WypelnijKatalog()
              {
                  TreeViewItem pojazdy = new TreeViewItem();
                  pojazdy.Header = "Pojazdy w komisie";

                  TreeViewItem sam = new TreeViewItem();
                  sam.Header = "Samochody";

                  TreeViewItem mot = new TreeViewItem();
                  mot.Header = "Motocykle";

                  List<Pojazd> garaz = new List<Pojazd>();
                  garaz.Add(new Ranger(1972, 2000, 50));
                  garaz.Add(new Ranger(1972, 25000, 500));
                  garaz.Add(new Mustang(1972, 2000, 30));
                  garaz.Add(new Mustang(1922, 20, 50));

                  foreach (var samochod in garaz)
                  {
                      sam.Items.Add($"{samochod.Marka} {samochod.Model}");
                  }

                  pojazdy.Items.Add(sam);
                  pojazdy.Items.Add(mot);

                  Katalog.Items.Add(pojazdy);
              }
      */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
