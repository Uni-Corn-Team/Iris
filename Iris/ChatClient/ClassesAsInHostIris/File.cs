using System;
using System.Collections;
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

        public ArrayList ConvertToArrayList()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(Name);
            arrayList.Add(fs);
            arrayList.Add(Size);

            return arrayList;
        }

        public static File Disconvert(ArrayList list)
        {
            return new File() 
            { 
                Name = (string)list[0], 
                fs = (FileStream)list[1], 
                Size = (int)list[2] 
            };
        }
    }
}
