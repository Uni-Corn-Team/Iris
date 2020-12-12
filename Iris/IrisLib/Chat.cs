using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IrisLib
{
    [Serializable]
    [DataContract]
    public class Chat
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public int ID { get; set; }
        [DataMember] public int RootID { get; set; }
        [DataMember] public List<User> Members { get; set; }
        [DataMember] public List<User> SilentMembers { get; set; }
        [DataMember] public List<Message> Messages { get; set; }
        
        public Chat(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            this.Members = new List<User>();
            this.SilentMembers = new List<User>();
            this.Messages = new List<Message>();
        }

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
