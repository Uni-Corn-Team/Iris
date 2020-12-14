using IrisLib;
using System;
using System.Windows;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignInWindow : Window, IrisLib.IServerChatCallback
    {
        public SignInWindow()
        {
            InitializeComponent();
            new ClientData();
            ClientData.isClose = true;
        }

        void WindowClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ClientData.isClose)
            {
                Application.Current.Shutdown();
            }
            else
            {
                ClientData.isClose = true;
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e) { }

        private void ButtonClickSignIn(object sender, RoutedEventArgs e)
        {
            ClientData.CurrentUser = ClientData.database.GetUserFromList(tblogin.Text);
            if (ClientData.CurrentUser != null)
            {
                if (ClientData.CurrentUser.Password.Equals(tbPassword.Password))
                {
                    ClientData.ShowMainWindow();
                    ClientData.isClose = false;
                    this.Close();
                }
                else
                {
                    lableLoginError.Visibility = Visibility.Visible;
                    tblogin.Text = null;
                    tbPassword.Password = null;
                }
            }
            else
            {
                lableLoginError.Visibility = Visibility.Visible;
                tblogin.Text = null;
                tbPassword.Password = null;
                ClientData.CurrentUser = new User();
            }
        }

        public void DatabaseCallback(Database database)
        {
            throw new NotImplementedException();
        }

        private void ButtonClickSignUp(object sender, RoutedEventArgs e)
        {
            (new SignUpWindow()).Show();
            ClientData.isClose = false;
            this.Close();
        }

        public void FileCallback(IrisLib.File file)
        {
            throw new NotImplementedException();
        }

        public void UserIdCallback(int id)
        {
            throw new NotImplementedException();
        }
    }
}
