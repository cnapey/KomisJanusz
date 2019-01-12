using KomisJanuszDane;
using KomisJanuszDane.Pojazdy.Samochody.Fordy;
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
using System.Windows.Shapes;

namespace KomisJanusz.Komponenty
{
    /// <summary>
    /// Logika interakcji dla klasy okno1.xaml
    /// </summary>
    public partial class okno1 : Window
    {
        private void WyslijKatalog(Pojazd pojazd)
        {
            marka.Text = pojazd.Marka;
            model.Text = pojazd.Model;
            cena.Text = pojazd.CenaSprzedazy.ToString();
            rok.Text = pojazd.RokProdukcji.ToString();
        }

        private void WypelnijKatalog()
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
        public okno1()
        {
            InitializeComponent();

            Ranger test1 = new Ranger(1998, 3895, 21);
            WyslijKatalog(test1);
            WypelnijKatalog();
        }

        private void rok_text(object sender, TextChangedEventArgs e)
        {

        }

        private void model_text(object sender, TextChangedEventArgs e)
        {

        }

        private void marka_text(object sender, TextChangedEventArgs e)
        {

        }

        private void cena_text(object sender, TextChangedEventArgs e)
        {

        }
    }
}
