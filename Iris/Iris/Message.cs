using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris
{
    [Serializable]
    public class Message
    {
        public Message(int id, User sender, string text)
        {
            this.ID = id;
            this.Sender = sender;
            this.Text = text;
            this.Date = DateTime.Now;
            this.HasFile = false;
        }
        public int ID { get; set; }
        public User Sender { get; set; }
        public string Text { get; set; }
        public bool HasFile { get; set; }
        public File File { get; set; }
        public DateTime Date { get; set; }

    }
}
