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
    public partial class okno2 : Window
    {
        public okno2()
        {
            InitializeComponent();
        }

        private void dodaj_auto(object sender, RoutedEventArgs e)
        {
            /*pobiera wpisane dane
            dodaj_marke.Text
            dodaj_model.Text
            dodaj_rok.Text
            dodaj_cene.Text */
        }

        private void anuluj_dodawanie(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
