﻿using Iris;
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

        private void RemoveTextLogin(object sender, EventArgs e)//происходит когда элемент стает активным
        {
            tblogin.Text = null;
            tblogin.Foreground = Brushes.Black;

        }

        private void RemoveTextPassword(object sender, EventArgs e)
        {
            tbPassword.Text = null;
            tbPassword.Foreground = Brushes.Black;
        }

        private void Button_Click_SignIn(object sender, RoutedEventArgs e)
        {
            /* lableLoginError.Visibility = Visibility.Visible;  это команда отображает надпись которая говорит об ошибке логина и пароля
            */
            MainWindow.CurrentUser = Database.getUserFromList(tblogin.Text);
            if (MainWindow.CurrentUser != null)
            {
                if (MainWindow.CurrentUser.Password.Equals(tbPassword.Text))
                {
           
                    (new MainWindow()).Show();
                    this.Close();
                }
                else
                {
                    lableLoginError.Visibility = Visibility.Visible;
                    tblogin.Text = null;
                    tbPassword.Text = null;
                    
                }
            }
            else
            {
                lableLoginError.Visibility = Visibility.Visible;
                tblogin.Text = null;
                tbPassword.Text = null;
                
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
