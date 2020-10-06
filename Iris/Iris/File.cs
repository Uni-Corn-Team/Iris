using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris
{
    public class File
    {
        public String Name { get; set; }
        public FileStream fs { get; set; }
        public int Size { get; set; }
    }
}
