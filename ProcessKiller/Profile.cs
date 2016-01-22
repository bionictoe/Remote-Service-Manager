using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProcessKiller
{
    public class Profile
    {
        [XmlElement("Service")]
        public List<Service> ServiceList { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        public Profile()
        {
            ServiceList = new List<Service>();
        }

       
    }
}
