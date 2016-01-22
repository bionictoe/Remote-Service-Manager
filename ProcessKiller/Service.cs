using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ProcessKiller
{
    public class Service
    {
        [XmlAttribute]
        public string   Name { get; set; }
        [XmlAttribute]
        public string   Server { get; set; }
        [XmlAttribute]
        public string   Domain { get; set; }
        [XmlAttribute]
        public string   StartType { get; set; }
        [XmlAttribute]
        public int      Group { get; set; }

        public string Status { get; set; }

        public String ServerHostname { get; set; }
        public String ServerUsername { get; set; }
        public String ServerPassword { get; set; }

        public Service()
        {
            //new instance of server class
            Server server = new Server();
            //get server details from server object
            this.ServerHostname = server.HostName;
            this.ServerUsername = server.UserName;
            this.ServerPassword = server.UserPassword;
        }

        public String[] ToStringArray()
        {
            String[] details = {    this.Name,              //service name
                                    this.Server,            //server this service is located
                                    this.Domain,            //domain of this service????
                                    this.StartType,         //initial start type
                                    this.Group.ToString(),  //dependancy/start time group
                                    this.Status,            //current seervice state
                                    this.ServerHostname,    //hostname of server
                                    this.ServerUsername,    //server username
                                    this.ServerPassword     //server password
                               };

            return details;
        }
    }
}
