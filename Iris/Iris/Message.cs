using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Iris
{
    [Serializable]
    [DataContract]
    public class Message
    {
        [DataMember] public int ID { get; set; }
        [DataMember] public User Sender { get; set; }
        [DataMember] public string Text { get; set; }
        [DataMember] public bool HasFile { get; set; }
        [DataMember] public File File { get; set; }
        [DataMember] public DateTime Date { get; set; }

        public Message()
        {

        }

        public Message(int id, User sender, string text)
        {
            this.ID = id;
            this.Sender = sender;
            this.Text = text;
            this.Date = DateTime.Now;
            this.HasFile = false;
        }

        public Message(int id, User sender, string text, DateTime time)
        {
            this.ID = id;
            this.Sender = sender;
            this.Text = text;
            this.Date = time;
            this.HasFile = false;
        }

        public override string ToString()
        {
            return "Mes Id: " + this.ID + " Text: " + this.Text + "\nSender: " + this.Sender.ToString();
        }

        
    }
}
