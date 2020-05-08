using System;
using System.Collections.Generic;

namespace Bitrate
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitrates properties = new Bitrates();
            List<long> rates = new List<long>();

            //parsing the json file
            properties.ParseJson();

            //print json file values
            properties.PrintJson();

            // calculating the bitrates
            rates = properties.CalculateBitRate();

            //printing RX bitrate
            Console.WriteLine("The Rx bitrate is: {0} bits per second", rates[0]);

            //printing TR bitrate
            Console.WriteLine("The Tx bitrate is: {0} bits per second", rates[1]); 

        }
    }
}
