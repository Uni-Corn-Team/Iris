using System.ServiceModel;
using System.Runtime.Serialization;
using System;

namespace Iris
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        /// <summary>
        /// user's name
        /// </summary>
        public string Nickname { get; set; }
        public int Age { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// user's id
        /// </summary>
        public int ID { get; set; }

        public Chat CurrentChat { get; set; }

        public User() { }
        public User(int id, string name, string surname, string nickname, int age, string login, string password)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
            this.Nickname = nickname;
            this.Age = age;
            this.Login = login;
            this.Password = password;
        }

        /// <summary>
        /// information about connection user to server
        /// </summary>
        public OperationContext OperationContext { get; set; }
    }


}
