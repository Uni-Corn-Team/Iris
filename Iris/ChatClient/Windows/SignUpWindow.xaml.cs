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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isUniqueNickname = true;
            foreach(User user in Database.Users)
            {
                if (tbNickname.Name == user.Nickname)
                {
                    isUniqueNickname = false;
                    break;
                }
            }
            if(isUniqueNickname)
            {
                SignIn.user = new User()
                {
                    Name = tbName.Text,
                    Surname = tbSurname.Text,
                    Nickname = tbNickname.Text,
                    Age = int.Parse(tbAge.Text),
                    Password = tbPassword.Text,
                    ID = Database.Users.Count == 0 ? 1 : Database.Users.Last<User>().ID + 1
                };
                Database.Users.Add(SignIn.user);
                Database.Save();
                (new MainWindow()).Show();
                this.Close();
            }
            else
            {
                throw new Exception("обработай меня");
            }
        }

        private void Button_Click_SignUp(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
