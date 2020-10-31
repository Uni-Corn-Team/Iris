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
using ChatClient.ServiceChat;
using Iris;

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_SignUp(object sender, RoutedEventArgs e)
        {
            if (Database.getUserFromList(tbNickname.Text) == null)
            {
                MainWindow.CurrentUser = new User(Database.Users.Count == 0 ? 1 : Database.Users.Last<User>().ID + 1,
                    tbName.Text, tbSurname.Text, tbNickname.Text, int.Parse(tbAge.Text), tbLogin.Text, tbPassword.Text);
                Database.addUserToDB(MainWindow.CurrentUser);
                (new MainWindow()).Show();
                this.Close();
            }
            else
            {
                lErorrMes.Visibility = Visibility.Visible;
            }
        }
    }
}
