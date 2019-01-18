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
using System.ComponentModel;
using KomisJanusz.Klasy;
using KomisJanusz.Komponenty;
using KomisJanuszDane;
using KomisJanuszDane.Pojazdy;
using KomisJanuszDane.Pojazdy.Samochody;

namespace KomisJanusz
{
    public partial class MainWindow : Window
    {
        private string MagicNumber;

        public MainWindow()
        {
            Log.Write(GetType());

            InitializeComponent();

            Activated += OnActivated;
        }

        private void OnActivated(object sender, EventArgs e)
        {
            if (sender is MainWindow)
            {
                MainWindow Okno = sender as MainWindow;

                Log.Write(GetType(), "OnActivated", "okno aktywowane");

                Okno.Activated -= OnActivated;                
            }

        }

        private void OnInitialized(object sender, EventArgs e)
        {
            Log.Write(GetType(), "OnInitialized", "okno zainicjalizowane");

            if (sender is MainWindow)
            {
                MainWindow Okno = sender as MainWindow;

                Random random = new Random();
                int valA = random.Next(1, 5);
                int valB = random.Next(1, 5);
                MagicNumber = $"{valA * valB}";

                DialogLogowania Dialog = new DialogLogowania()
                {
                    OnAuthorizeLogin = AuthorizeLoginDelegate,
                    Title = $"Logowanie ({valA},{valB})"
                };

                Dialog.ShowDialog();

                if (Dialog.CzyZalogowany)
                {
                    Okno.Run(); 
                }
                else
                {
                    Okno.Close();
                }

            }
        }

        private void Run()
        {
            Log.Write(GetType(), "Run");

            Title      += $" {DateTime.Now.ToString("dd-MM-yyyy")} wersja {Zasoby.WersjaAplikacji}";
            Closing    += OnClosing;

            Pojazd auto = null;

            try
            {
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Log.Write(GetType(), "OnClosing", "Zamykamy okno <{0}>", sender);

            MessageBoxResult Opcja = MessageBox.Show("Czy zamknąć program?", "Kierowniku, małe pytanko...", MessageBoxButton.YesNo, MessageBoxImage.Question);

            Log.Write(GetType(), "OnClosing", "Opcja <{0}>", Opcja);

            if (Opcja != MessageBoxResult.Yes)
            {
                e.Cancel = true; 
            }
        }

        private bool AuthorizeLoginDelegate(DialogLogowania sender)
        {
            Log.Write(GetType(), "AuthorizeLoginDelegate");

            if (sender.Login.Equals("mirek") && (sender.Password.Equals(MagicNumber) || sender.Password.Equals("mirek")))
            {
                return true;
            }

            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            okno1 okno = new okno1();
            okno.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            okno2 okno = new okno2();
            okno.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            okno3 okno = new okno3();
            okno.Show();
        }
    }
}
