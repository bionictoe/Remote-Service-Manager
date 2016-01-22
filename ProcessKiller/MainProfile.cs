using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace ProcessKiller
{
    [Serializable]
    [XmlRoot("MainProfile")]
    public class MainProfileRoot
    {
        [XmlElement("Server")]
        public List<Server> ServerList{ get; set; }
        [XmlElement("DataBase")]
        public List<DataBase> DataBaseList{ get; set; }
        [XmlElement("Profile")]
        public List<Profile> ProfileList { get; set; }

        public MainProfileRoot DeserializeXml()
        {
            string filepath = @"..\XmlFiles\XmlFormat2.xml";
            XmlSerializer tmpxmlserializer = new XmlSerializer(typeof(MainProfileRoot));
            StreamReader thereader = new StreamReader(filepath);
            MainProfileRoot mainprof = (MainProfileRoot)tmpxmlserializer.Deserialize(thereader);
            thereader.Close();
            return mainprof;
        }
    }
}
