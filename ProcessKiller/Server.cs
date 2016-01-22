using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProcessKiller
{
    public class Server
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string HostName { get; set; }
        [XmlAttribute]
        public string Domain { get; set; }
        [XmlAttribute]
        public string UserName { get; set; }
        [XmlAttribute]
        public string UserPassword { get; set; }
    }
}
