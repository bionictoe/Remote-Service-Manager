using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessKiller
{
    class ServerInformation
    {
        //Server information
        public void getServerInfo()
        {
            MainProfileRoot mainProfRoot = new MainProfileRoot().DeserializeXml();

            // Get the number of servers in the xml
            int serverListSize = mainProfRoot.ServerList.Count;
            // All of the available attributes and their values
            string ServerId;
            string HostName;
            string Domain;
            string UserName;
            string UserPassword;

            Console.WriteLine("Server Information");
            Console.WriteLine("==================");

            for (int i = 0; i < serverListSize; i++)
            {
                ServerId = mainProfRoot.ServerList[i].Name;
                HostName = mainProfRoot.ServerList[i].HostName;
                Domain = mainProfRoot.ServerList[i].Domain;
                UserName = mainProfRoot.ServerList[i].UserName;
                UserPassword = mainProfRoot.ServerList[i].UserPassword;

                Console.WriteLine("Server ID: " + ServerId + "   Host: " + HostName + "   Domain: " + Domain + "   User: " + UserName + "   Password: " + UserPassword);
            }

            Console.ReadKey();
        }
    }
}
