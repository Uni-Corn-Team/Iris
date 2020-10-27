using Iris;
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

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public static User user;

        public SignIn()
        {
            InitializeComponent();
            Iris.Database.Load();
            user = new User();

           // foreach (User user in Database.Users)
            //{
                //lbUncorects.Items.Add(user.Nickname + " " + user.Password);
           // }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_SignIn(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {

                foreach (User user in Database.Users)
                {
                    if (user.Nickname.Equals(tbNickname.Text) && user.Password.Equals(tbPassword.Text))
                    {
                        (new MainWindow()).Show();
                        this.Close();
                    }
                }
                // lbUncorects.Items.Add(DateTime.Now.ToString() + ": uncorect");

            }
        }
        private void Button_Click_SignUp(object sender, RoutedEventArgs e)
        {
           (new SignUpWindow()).Show();
            this.Close();
        }
    }
}
