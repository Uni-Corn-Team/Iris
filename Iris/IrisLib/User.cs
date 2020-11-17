using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace IrisLib
{
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

        //public Chat CurrentChat { get; set; }

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

        public override string ToString()
        {
            return "User Id: " + this.ID + " Name: " + this.Name + " Surname: " + this.Surname + " Nickname: " + this.Nickname + " Login: " + this.Login + " Password: " + this.Password + "\n";
        }
        /// <summary>
        /// information about connection user to server
        /// </summary>
        public OperationContext OperationContext { get; set; }

        public bool Equals(User other)
        {
            if (other != null && this.Name == other.Name && this.Surname == other.Surname && this.Nickname == other.Nickname &&
                this.Age == other.Age && this.Login == other.Login && this.Password == other.Password && this.ID == other.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
