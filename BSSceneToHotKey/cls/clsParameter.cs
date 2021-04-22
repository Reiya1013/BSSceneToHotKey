using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSSceneToHotKey
{
    [Serializable]
    public class clsParameter
    {
        public string ClientIPAddress { get; set; } = "localhost";
        public int ClientPort { get; set; } = 59650;

        public bool ServerFlg { get; set; }
        public string ServerIPAddress { get; set; } = "localhost";
        public int ServerPort { get; set; } = 59651;

        public List<byte> Game { get; set; } = new List<byte>();
        public List<byte> Menu { get; set; } = new List<byte>();
        public List<byte> Start { get; set; } = new List<byte>();
        public List<byte> End { get; set; } = new List<byte>();
        public string GameMessage { get; set; }
        public string MenuMessage { get; set; }
        public string StartMessage { get; set; }
        public string EndMessage { get; set; }

    }
}
