using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSSceneToHotKey
{
    [Serializable]
    public sealed class clsParameter
    {
        public string ClientIPAddress { get; set; } = "localhost";
        public int ClientPort { get; set; } = 6557;

        public List<byte> Game { get; set; } = new List<byte>();
        public List<byte> Menu { get; set; } = new List<byte>();
        public List<byte> Start { get; set; } = new List<byte>();
        public List<byte> End { get; set; } = new List<byte>();
        public int StartTime { get; set; } 
        public int EndTime { get; set; } 

    }
}
