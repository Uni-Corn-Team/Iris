using System;
using System.ServiceModel;

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
