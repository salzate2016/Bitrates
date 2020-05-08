using System;
using System.Collections.Generic;
using System.Text;

namespace Bitrate
{
    //class to organize and store json file values
    class JsonFile
    {
        public string Device { get; set; }
        public string Model { get; set; }
        public List<NICProperties> NIC { get; set; }
    }

    class NICProperties
    {
        public string Description { get; set; }
        public string MAC { get; set; }
        public string Timestamp { get; set; }
        public string Rx { get; set; }
        public string Tx { get; set; }
    }
}
