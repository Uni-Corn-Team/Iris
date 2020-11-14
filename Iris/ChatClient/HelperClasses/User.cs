using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.HelperClasses
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

        public override string ToString()
        {
            return "User Id: " + this.ID + " Name: " + this.Name + " Surname: " + this.Surname + " Nickname: " + this.Nickname + " Login: " + this.Login + " Password: " + this.Password + "\n";
        }

        public ArrayList ConvertToArrayList()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(ID);
            arrayList.Add(Name);
            arrayList.Add(Surname);
            arrayList.Add(Nickname);
            arrayList.Add(Age);
            arrayList.Add(Login);
            arrayList.Add(Password);

            //no, will not add this
            //hope that will work without it
            //arrayList.Add(CurrentChat);
            return arrayList;
        }

        public static User Disconvert(object[] list)
        {
            return new User()
            {
                ID = (int)list[0],
                Name = (string)list[1],
                Surname = (string)list[2],
                Nickname = (string)list[3],
                Age = (int)list[4],
                Login = (string)list[5],
                Password = (string)list[6]
            };
        }
    }
}
