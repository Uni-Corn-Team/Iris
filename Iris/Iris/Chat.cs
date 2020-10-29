using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris
{
    [Serializable]
    public class Chat
    {
        public Chat(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public string Name { get; set; }
        public int ID { get; set; }
        public List<User> Members { get; set; }
        public List<Message> Messages { get; set; }
    }
}
