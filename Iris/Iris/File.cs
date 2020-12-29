using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris
{
    [Serializable]
    public class File
    {
        public string Name { get; set; }
        public FileStream fs { get; set; }
        public int Size { get; set; }
    }
}
