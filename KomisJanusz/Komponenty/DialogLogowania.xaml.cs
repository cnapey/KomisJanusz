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
using KomisJanusz.Klasy;

namespace KomisJanusz.Komponenty
{
    /// <summary>
    /// Logika interakcji dla klasy DialogLogowania.xaml
    /// </summary>
    public partial class DialogLogowania : Window
    {
        public delegate bool AuthorizeLoginDelegate(DialogLogowania dialog);

        public bool CzyZalogowany { get; private set; }
        public AuthorizeLoginDelegate OnAuthorizeLogin;

        public string Login
        {
            get
            {
                return LoginField.Text;
            }
        }

        public string Password
        {
            get
            {
                return PasswordField.Password;
            }
        }

        public DialogLogowania()
        {
            Log.Write(GetType());

            InitializeComponent();

            CzyZalogowany = false;

            Activated += OnActivated;

            LoginBtn.Click += OnButtonClick;
            CancelBtn.Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button instancja = sender as Button;

                Log.Write(GetType(), "OnButtonClick", "Przycisk = <{0}>", instancja.Name);

                switch (instancja.Name)
                {
                    case "LoginBtn":                        
                        AuthorizeLoginDialog(); break;

                    case "CancelBtn":
                        CancelLoginDialog(); break;

                }
            }
            
        }

        public void Clear()
        {
            Log.Write(GetType(), "Clear");

            LoginField.Text = "";
            PasswordField.Password = "";

            LoginField.Focus();
        }

        private void AuthorizeLoginDialog()
        {
            Log.Write(GetType(), "AuthorizeLoginDialog");

            if (string.IsNullOrEmpty(Login))
            {
                MessageBox.Show("Pole <Login> nie może być puste!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginField.Focus();                
            }
            else if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Pole <Hasło> nie może być puste!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                PasswordField.Focus();
            }
            else
            {
                CzyZalogowany = OnAuthorizeLogin?.Invoke(this) ?? false;

                if (CzyZalogowany)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Błędny login lub hasło!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    Clear();
                }
                    
            }


        }

        private void CancelLoginDialog()
        {
            Log.Write(GetType(), "CancelLoginDialog");

            Close();
        }

        private void OnActivated(object sender, EventArgs e)
        {
            Log.Write(GetType(), "OnActivated");

            if (sender is DialogLogowania)
            {
                DialogLogowania instancja = sender as DialogLogowania;

                instancja.Activated -= OnActivated;

                instancja.LoginField.Focus();
            }
        }
    }
}
