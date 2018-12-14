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
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
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
                int valA = random.Next(1, 10);
                int valB = random.Next(1, 10);
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

            //PasekStatusu.
            

            Pojazd auto = null;

            try
            {
                //auto = new KomisJanuszDane.Pojazdy.Samochody.Fordy.Mustang(1969, 100000, 12);

                

                foreach (var typ in typeof(Ford).TypyDziedziczace())
                {
                    //Console.WriteLine($" Typ=<{typ.Name}>");

                    if (!typ.IsAbstract)
                    {
                        auto = Activator.CreateInstance(typ, 1969, 100000, 12) as Pojazd;

                        if (auto != null)
                        {
                            TekstPasekStatusu.Text = auto.ToString();

                            Log.Write(GetType(), "Run", "Pojazd = {0} Cena = {1:F2}", auto, auto.CenaSprzedazy);
                        }
                    }

                    foreach (var podtyp in typ.TypyDziedziczace())
                    {
                        Console.WriteLine($"    Podtyp=<{podtyp.Name}>");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Log.Write(GetType(), "OnClosing", "Zamykamy okno <{0}>", sender);

            MessageBoxResult Opcja = MessageBox.Show("Czy zakończyć działanie programu?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);

            Log.Write(GetType(), "OnClosing", "Opcja <{0}>", Opcja);

            if (Opcja != MessageBoxResult.Yes)
            {
                e.Cancel = true; 
            }
        }

        private bool AuthorizeLoginDelegate(DialogLogowania sender)
        {
            Log.Write(GetType(), "AuthorizeLoginDelegate");

            if (sender.Login.Equals("admin") && (sender.Password.Equals(MagicNumber) || sender.Password.Equals("test")))
            {
                return true;
            }

            return false;
        }

    }
}
