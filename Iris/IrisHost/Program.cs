using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using IrisLib;

namespace IrisHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(IrisLib.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Host started");
                Console.ReadLine();
            }
        }
    }
}
