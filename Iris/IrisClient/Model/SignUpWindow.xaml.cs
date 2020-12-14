using System;
using System.Windows;
using IrisLib;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
            ClientData.isClose = true;
        }

        private void ButtonClickSignUp(object sender, RoutedEventArgs e)
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
            {
                Application.Current.Shutdown();
            }
            else
            {
                ClientData.isClose = true;
            }
        }
    }
}
