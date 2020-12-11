using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace IrisLib
{
    [Serializable]
    [DataContract]
    public class User
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public string Surname { get; set; }
        /// <summary>
        /// user's name
        /// </summary>
        [DataMember] public string Nickname { get; set; }
        [DataMember] public int Age { get; set; }
        [DataMember] public string Login { get; set; }
        [DataMember] public string Password { get; set; }
        /// <summary>
        /// user's id
        /// </summary>
        [DataMember] public int ID { get; set; }

        [DataMember] public int CurrentChatID { get; set; }

        public User()
        {
            CurrentChatID = -1;
        }
        
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

        public override bool Equals(Object other)
        {
            User user = other as User;
            if (user != null && this.Name == user.Name && this.Surname == user.Surname && this.Nickname == user.Nickname &&
                this.Age == user.Age && this.Login == user.Login && this.Password == user.Password && this.ID == user.ID)
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
