using System;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace IrisLib
{
    /// <summary>
    /// Класс для описания объекта "Пользователь".
    /// </summary>
    [Serializable]
    [DataContract]
    public class User
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [DataMember] public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        [DataMember] public string Surname { get; set; }

        /// <summary>
        /// Никнейм (псевдоним) пользователя.
        /// </summary>
        [DataMember] public string Nickname { get; set; }

        /// <summary>
        /// Возраст пользователя.
        /// </summary>
        [DataMember] public int Age { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [DataMember] public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        [DataMember] public string Password { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [DataMember] public int ID { get; set; }

        /// <summary>
        /// Идентификатор открытого у пользователя на данный момент чата.
        /// </summary>
        [DataMember] public int CurrentChatID { get; set; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// Инициализирует CurrentChatID значением -1.
        /// </summary>
        public User()
        {
            CurrentChatID = -1;
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="id"> идентификатор пользователя </param>
        /// <param name="name"> имя пользователя </param>
        /// <param name="surname"> фамилия пользователя </param>
        /// <param name="nickname"> никнейм (псевдоним) пользователя </param>
        /// <param name="age"> возраст пользователя </param>
        /// <param name="login"> логин пользователя </param>
        /// <param name="password"> пароль пользователя </param>
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
        /// Перегруженный метод преобразования объекта пользователя к строке.
        /// Строка содержит полную информацию о пользователе.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "User Id: " + this.ID + " Name: " + this.Name + " Surname: " + this.Surname + " Nickname: " + this.Nickname + " Login: " + this.Login + " Password: " + this.Password + "\n";
        }

        /// <summary>
        /// Информачия о соединении клиента с сервером.
        /// </summary>
        public OperationContext OperationContext { get; set; }

        /// <summary>
        /// Перегруженный метод для определения эквивалентности пользователей.
        /// Сравнивает по значениям всех полей.
        /// </summary>
        /// <param name="other"> пользователь, с которым проводится сравнение </param>
        /// <returns> true(если объекты эквивалентны) либо false(если объекты не эквивалентны) </returns>
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
