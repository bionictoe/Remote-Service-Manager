using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessKiller
{
    class ServiceInformation
    {
        // Information on services
        public void getServiceInfo()
        {
            MainProfileRoot mainProfRoot = new MainProfileRoot().DeserializeXml();

            int profileListSize = mainProfRoot.ProfileList.Count;
            int serviceListSize;
            string ServiceName;
            string Server;
            string Domain;
            string StartType;

            Console.WriteLine("Service Information");
            Console.WriteLine("==================");

            for (int i = 0; i < profileListSize; i++)
            {
                serviceListSize = mainProfRoot.ProfileList[i].ServiceList.Count;
                Console.WriteLine("Profile: " + profileListSize);
                Console.WriteLine();
                Console.WriteLine("Service: " + "                                  " + "Current Server: " + "          " + "Domain: " + "          " + "Start Type: ");
                Console.WriteLine("________________________________________________________________________________________________");

                for (int j = 0; j < serviceListSize; j++)
                {
                    ServiceName = mainProfRoot.ProfileList[i].ServiceList[j].Name;
                    Server = mainProfRoot.ProfileList[i].ServiceList[j].Server;
                    Domain = mainProfRoot.ProfileList[i].ServiceList[j].Domain;
                    StartType = mainProfRoot.ProfileList[i].ServiceList[j].StartType;

                    //Console.WriteLine(ServiceName);
                    Console.WriteLine(ServiceName + "               " + Server.PadRight(20) + "          " + Domain + "               " + StartType.PadRight(20));
                }
            }

            Console.ReadKey();
        }
    }
}
