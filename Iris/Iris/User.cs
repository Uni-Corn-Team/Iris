using System.ServiceModel;
using System.Runtime.Serialization;
using System;
using System.Collections;

namespace Iris
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

        public override string ToString()
        {
            return "User Id: " + this.ID +" Name: "+ this.Name + " Surname: " + this.Surname + " Nickname: " + this.Nickname + " Login: " + this.Login + " Password: " + this.Password + "\n";
        }
        /// <summary>
        /// information about connection user to server
        /// </summary>
        public OperationContext OperationContext { get; set; }

    }


}
