using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProcessKiller
{
    public class DataBase
    {
        [XmlAttribute]
        public string Host { get; set; }
        [XmlAttribute]
        public string PortNumber { get; set; }
        [XmlAttribute]
        public string DataSource { get; set; }
        [XmlAttribute]
        public string InitialCatalog { get; set; }
        [XmlAttribute]
        public string UserId { get; set; }
        [XmlAttribute]
        public string Password { get; set; }
    }
}
