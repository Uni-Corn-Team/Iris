using IrisLib;
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
using Microsoft.Data.Sqlite;
using System.Runtime.CompilerServices;
using System.IO;
using IrisClient.ServiceChat;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignInWindow : Window, IrisLib.IServerChatCallback
    {
         private bool isShowLogin = true;
         private bool isShowPassword = true;
        public SignInWindow()
        {
            InitializeComponent();
            new ClientData();
            ClientData.isClose = true;
        }
        void WindowClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ClientData.isClose)
                Application.Current.Shutdown();
            else
                ClientData.isClose = true;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveTextLogin(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            if (isShowLogin)
            {
                tblogin.Text = null;
                tblogin.Foreground = Brushes.Black;
                isShowLogin = false;
            }
  
        }

        

        private void Button_Click_SignIn(object sender, RoutedEventArgs e)
        {
            ClientData.CurrentUser = ClientData.database.GetUserFromList(tblogin.Text);
            if (ClientData.CurrentUser != null)
            {
                if (ClientData.CurrentUser.Password.Equals(tbPassword.Password))
                {

                    //new MainWindow().Show();
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
            }
        }

        public void DatabaseCallback(Database database)
        {
            throw new NotImplementedException();
        }

        private void Button_Click_SignUp(object sender, RoutedEventArgs e)
        {
            (new SignUpWindow()).Show();
            ClientData.isClose = false;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
