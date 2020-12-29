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
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public SignUpWindow()
        {
            InitializeComponent();
            ClientData.isClose = true;
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Зарегистрироваться".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
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

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Назад".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickBack(object sender, EventArgs e)
        {       
            new SignInWindow().Show();
            ClientData.isClose = false;
            this.Close();
        }

        /// <summary>
        /// Метод для обработки события закрытия окна.
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
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
