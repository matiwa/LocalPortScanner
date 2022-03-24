using System;
using System.Net;
using System.Net.Sockets;

namespace LocalPortScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "LocalPortScanner";
            Console.WriteLine("Enter port range from 0 to 65535");
            Console.WriteLine("Enter minimum port:");
            int minimum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter maximum port:");
            int maximum = int.Parse(Console.ReadLine());
            
            if ((minimum >= 0) && (minimum <= 65535) && (maximum >= 0) && (maximum <= 65535))
            {
                if (minimum > maximum)
                {
                    int tmp = minimum;
                    minimum = maximum;
                    maximum = tmp;
                    Console.WriteLine("The minimum port must be less than or equal to the maximum port!" +
                        " I swap them places.");
                }
                Console.WriteLine("\r\nStart scanning from port {0} to {1}...\r\n", minimum, maximum);
                for (int i = minimum; i <= maximum; i++)
                {
                    try
                    {
                        TcpListener serwer = new TcpListener(IPAddress.Loopback, i);
                        serwer.Start();
                        serwer.Stop();
                        Console.WriteLine("Currently scanned port: {0} is opened.", i);
                    }
                    catch
                    {
                        Console.WriteLine("Currently scanned port: {0} is closed.", i);
                    }
                }
                Console.WriteLine("\r\nScanning is completed.");
            }
            else
            {
                Console.WriteLine();
                if (minimum < 0) Console.WriteLine("The minimum port is below 0.");
                else if (minimum > 65535) Console.WriteLine("The minimum port is above 65535.");
                if (maximum < 0) Console.WriteLine("The maximum port is below 0.");
                else if (maximum > 65535) Console.WriteLine("The maximum port is above 65535.");
                Console.WriteLine("\r\nScanning is impossible.");
            }
            Console.ReadKey();
        }
    }
}
