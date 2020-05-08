using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;



namespace Bitrate
{
    class Bitrates
    {
        private string device = string.Empty;
        private string model = string.Empty;
        private List<NICProperties> nic = new List<NICProperties>();
        private string description = string.Empty;
        private string mac = string.Empty;
        private string timestamp = string.Empty;
        private long rx;
        private long tx;
       

        public string Device { get => device; set => device = value; }
        public string Model { get => model; set => model = value; }
        public List<NICProperties> Nic { get => nic; set => nic = value; }
        public string Description { get => description; set => description = value; }
        public string Mac { get => mac; set => mac = value; }
        public string Timestamp { get => timestamp; set => timestamp = value; }
        public long Rx { get => rx; set => rx = value; }
        public long Tx { get => tx; set => tx = value; }

        /// <summary> 
        /// Method to parse a json file that contains network interface values  
        /// </summary> 
        public void ParseJson()
        {
            string fileName = "file.json";

            //json file path
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,fileName);

            //Newtonsoft.Json has to be installed to use Jsonconvert
            JsonFile file = JsonConvert.DeserializeObject<JsonFile>(File.ReadAllText(path));
            Device = file.Device;
            Model = file.Model;
            Nic = file.NIC;
            Description = Nic[0].Description;
            Mac = Nic[0].MAC;
            Timestamp = Nic[0].Timestamp;
            Rx = Convert.ToInt64(Nic[0].Rx);
            Tx = Convert.ToInt64(Nic[0].Tx);
        }

        /// <summary> 
        /// Method to print the json file values  
        /// </summary> 
        public void PrintJson()
        {
            Console.WriteLine("Device: {0}", Device);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Description: {0}", Description);
            Console.WriteLine("Mac: {0}", Mac);
            Console.WriteLine("Timestamp: {0}", Timestamp);
            Console.WriteLine("Rx: {0}", Rx);
            Console.WriteLine("Tx: {0}", Tx);
        }

        /// <summary> 
        /// Method to calculate the bitrates
        /// </summary> 
        /// <returns> a list with two values: RX rate and TX rate </returns>
        public List<long> CalculateBitRate()
        {
            var results = new List<long>();
            long rxRate = (Rx * 8) / 2;
            results.Add(rxRate);
            long txRate = (Tx * 8) / 2;
            results.Add(txRate);
            return results;
        }

    }
}
