﻿using Iris;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

namespace ChatClient.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private bool isShowID = true;
        private void ButtonClickBack(object sender, EventArgs e)
        {
           // new MainWindow().Show();
            this.Close();
        }
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void ButtonClickAddUserToChat(object sender, RoutedEventArgs e)
        {
            if (Database.getUserFromList(int.Parse(tbID.Text)) != null && MainWindow.CurrentUser.CurrentChat != null)
            {
                Database.getChatFromList(MainWindow.CurrentUser.CurrentChat.ID).Members.Add(Database.getUserFromList(int.Parse(tbID.Text)));
                Database.addChatToDB(Database.getChatFromList(MainWindow.CurrentUser.CurrentChat.ID));
               // new MainWindow().Show();
                this.Close();
            }
            else
            {
                //write that user isn't exists and delete next two lines
                //new MainWindow().Show();
                this.Close();
            }


        }

        private void RemoveTextID(object sender, EventArgs e)
        {
            if(isShowID)
            {
                tbID.Text = null;
                tbID.Foreground = Brushes.Black;
                isShowID = false;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}
