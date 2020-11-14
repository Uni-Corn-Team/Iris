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
using ChatClient.HelperClasses;
using ChatClient.ServiceChat;

namespace ChatClient
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


        private void RemoveTextPassword(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            if (isShowPassword)
            {
                tbPassword.Text = null;
                tbPassword.Foreground = Brushes.Black;
                isShowPassword = false;
            }

        }


        private void Button_Click_SignUp(object sender, RoutedEventArgs e)
        {
            if (User.Disconvert(Clienter.client.getUserFromList1(tbNickname.Text)) == null)
            {
                MainWindow.CurrentUser = new User(0, tbName.Text, tbSurname.Text, tbNickname.Text, int.Parse(tbAge.Text), tbLogin.Text, tbPassword.Text);
                Clienter.client.addUserToDB(MainWindow.CurrentUser.ConvertToArrayList().ToArray());
                (new MainWindow()).Show();
                this.Close();
            }
            else
            {
                lErorrMes.Visibility = Visibility.Visible;
            }
        }

        private void ButtonClickBack(object sender, EventArgs e)
        {
            new SignIn().Show();
            this.Close();
        }
    }
}
