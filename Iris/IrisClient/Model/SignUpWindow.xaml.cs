using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
using IrisClient.ServiceChat;
using IrisLib;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private bool isShowName = true, isShowSurname = true, isShowNickname = true, isShowAge = true, isShowLogin = true, isShowPassword = true; 
        public SignUpWindow()
        {
            InitializeComponent();
            ClientData.isClose = true;
        }

        private void RemoveTextName(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            if (isShowName)
            {
                tbName.Text = null;
                tbName.Foreground = Brushes.Black;
                isShowName = false;
            }
        }

        private void RemoveTextSurname(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            if (isShowSurname)
            {
                tbSurname.Text = null;
                tbSurname.Foreground = Brushes.Black;
                isShowSurname = false;
            }

        }

        private void RemoveTextNickname(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            if (isShowNickname)
            {
                tbNickname.Text = null;
                tbNickname.Foreground = Brushes.Black;
                isShowNickname = false;
            }

        }

        private void RemoveTextAge(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            if (isShowAge)
            {
                tbAge.Text = null;
                tbAge.Foreground = Brushes.Black;
                isShowAge = false;
            }
        }

        private void RemoveTextLogin(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            if (isShowLogin)
            {
                tbLogin.Text = null;
                tbLogin.Foreground = Brushes.Black;
                isShowLogin = false;
            }
        }


       

        private void Button_Click_SignUp(object sender, RoutedEventArgs e)
        {
            if (ClientData.database.GetUserFromList(tbLogin.Text) == null)
            {
                try
                {
                    int age = Int32.Parse(tbAge.Text);
                    int ID = ClientData.database.UsersCountAsNextID + 1;
                    ClientData.CurrentUser = new User(0, tbName.Text, tbSurname.Text, tbNickname.Text, age, tbLogin.Text, tbPassword.Password);
                    ClientData.client.GetNewUser(ClientData.CurrentUser);
                    ClientData.CurrentUser.ID = ID;
                    ClientData.ShowMainWindow();
                    ClientData.isClose = false;
                    this.Close();
                }
                catch (FormatException exp)
                {
                    Console.WriteLine(exp.ToString());
                    lAgeErorr.Visibility = Visibility.Visible;
                    tbAge.Text = "";
                }
            }
            else
            {
                lErorrMes.Visibility = Visibility.Visible;
            }
        }

        private void ButtonClickBack(object sender, EventArgs e)
        {       
            new SignInWindow().Show();
            ClientData.isClose = false;
            this.Close();
        }

        void WindowClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ClientData.isClose)
                Application.Current.Shutdown();
            else
                ClientData.isClose = true;
        }
    }
}
