using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IrisLib
{
    [Serializable]
    public class File
    {
        public string Name { get; set; }
        public FileStream fs { get; set; }
        public int Size { get; set; }
    }
}
