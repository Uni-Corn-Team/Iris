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
using Microsoft.Data.Sqlite;

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            Database.Update();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_SignIn(object sender, RoutedEventArgs e)
        {
            MainWindow.CurrentUser = Database.getUserFromList(tbNickname.Text);
            if (MainWindow.CurrentUser != null)
            {
                if (MainWindow.CurrentUser.Password.Equals(tbPassword.Text))
                {
                    (new MainWindow()).Show();
                    this.Close();
                }
                else
                {
                    //write that pass or log is incorrect
                }
            }
            else
            {
                //write that pass or log is incorrect
            }

            //foreach (User user in Database.Users)
            //{
            //    if (user.Nickname.Equals(tbNickname.Text) && user.Password.Equals(tbPassword.Text))
            //    {
            //        (new MainWindow()).Show();
            //        this.Close();
            //    }
            //}
            // lbUncorects.Items.Add(DateTime.Now.ToString() + ": uncorect");

        }
        private void Button_Click_SignUp(object sender, RoutedEventArgs e)
        {
            (new SignUpWindow()).Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
