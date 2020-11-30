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
        [DataMember] public List<Message> Messages { get; set; }
        public Chat(int id, string name)
        {
            this.ID = id;
            this.Name = name;
            this.Members = new List<User>();
            this.Messages = new List<Message>();
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
