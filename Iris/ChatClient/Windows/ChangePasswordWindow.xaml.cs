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

namespace ChatClient.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditProfile.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {

        public ChangePasswordWindow()
        {
            InitializeComponent();
        }
         

        private void ButtonClickChangePassword(object sender, RoutedEventArgs e)
        {
            if (MainWindow.CurrentUser.Password.Equals(tbPassword.Text))
            {
                MainWindow.CurrentUser.Password = tbNewPassword.Text;
                Database.changePassword(MainWindow.CurrentUser);
                (new MainWindow()).Show();
                this.Close();
            }
        }


        private void ButtonClickBack(object sender, EventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
          //  new MainWindow().Show();
            
        }
    }
}
