using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace IrisLib
{
    /// <summary>
    /// Класс для описания объекта "Чат".
    /// </summary>
    [Serializable]
    [DataContract]
    public class Chat
    {
        /// <summary>
        /// Название чата.
        /// </summary>
        [DataMember] public string Name { get; set; }
        
        /// <summary>
        /// Идентификатор чата.
        /// </summary>
        [DataMember] public int ID { get; set; }
        
        /// <summary>
        /// Идентификатор создателя чата.
        /// </summary>
        [DataMember] public int RootID { get; set; }
        
        /// <summary>
        /// Список участников чата.
        /// </summary>
        [DataMember] public List<User> Members { get; set; }

        /// <summary>
        /// Список заглушенных участников чата (не имеют возможности отправлять сообщения).
        /// </summary>
        [DataMember] public List<User> SilentMembers { get; set; }

        /// <summary>
        /// Список сообщений в чате.
        /// </summary>
        [DataMember] public List<Message> Messages { get; set; }
        
        /// <summary>
        /// Конструктор с параметрами для объекта типа "Чат".
        /// </summary>
        /// <param name="id"> идентификатор чата </param>
        /// <param name="name"> название чата </param>
        public Chat(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            this.Members = new List<User>();
            this.SilentMembers = new List<User>();
            this.Messages = new List<Message>();
        }

        /// <summary>
        /// Метод, проверяющий, заглушен ли конкретный пользователь в чате.
        /// </summary>
        /// <param name="userID"> идентификатор проверяемого пользователя </param>
        /// <returns> true (если пользователь заглушен) и false (если пользователь не заглушен) </returns>
        public bool IsUserInChatSilent(int userID)
        {
            for (int i = 0; i < SilentMembers.Count; i++)
            {
                if (userID == SilentMembers[i].ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Метод, заглушающий конкретного пользователя в чате.
        /// Добавляет пользователя в список заглушенных участников.
        /// </summary>
        /// <param name="userID"> идентификатор заглушаемого пользователя </param>
        /// <returns> true (если пользователь успешно заглушен) и false (если пользователь не заглушен) </returns>
        public bool MakeUserSilent(int userID)
        {
            User user = GetUserFromChat(userID);
            if (user != null)
            {
                if (!SilentMembers.Contains(user))
                {
                    SilentMembers.Add(user);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Метод, снимающий заглушку с конкретного пользователя в чате.
        /// Убирает пользователя из списока заглушенных участников.
        /// </summary>
        /// <param name="userID"> идентификатор пользователя </param>
        /// <returns> true (если заглушка успешно снята) и false (если заглушка не снята) </returns>
        public bool MakeUserNotSilent(int userID)
        {
            User user = GetUserFromChat(userID);
            if (user != null)
            {
                if (SilentMembers.Contains(user))
                {
                    SilentMembers.Remove(user);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Метод, проверяющий наличие конкретного пользователя в чате.
        /// </summary>
        /// <param name="user"> идентификатор проверяемого пользователя </param>
        /// <returns> true (если пользователь присутствует в чате) и false (если пользователь не присутствует в чате) </returns>
        public bool IsUserInChat(User user)
        {
            if (user != null)
            {
                for (int i = 0; i < Members.Count; i++)
                {
                    if (user.ID == Members[i].ID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Метод получения пользователя из чата по идентификатору.
        /// </summary>
        /// <param name="userID"> идентификатор искомого пользователя </param>
        /// <returns> объект класса User (если пользователь присутствует в чате) либо null (если пользователь отсутствует в чате) </returns>
        public User GetUserFromChat(int userID)
        {
            for (int i = 0; i < Members.Count; i++)
            {
                if (userID == Members[i].ID)
                {
                    return Members[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Перегруженный метод преобразования объекта класса Чат в строковое представление.
        /// Возвращает строку, состоящую из идентификатора чата, списков участников и сообщений.
        /// </summary>
        /// <returns> строковое представление объекта класса Чат </returns>
        public override string ToString()
        {
            string str = "Chat id: " + this.ID + "\nMembers:\n";
            for (int i = 0; i < this.Members.Count(); i++)
            {
                str += this.Members[i].ToString();
            }
            str += "\nMessages:\n";
            for (int i = 0; i < this.Messages.Count(); i++)
            {
                str += this.Messages[i].ToString();
            }
            return str;
        }

    }
}
