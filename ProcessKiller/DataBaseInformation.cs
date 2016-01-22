using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessKiller
{
    class DataBaseInformation
    {
        // Data base inforation
        public void getDataBaseInfo()
        {
            MainProfileRoot mainProfRoot = new MainProfileRoot().DeserializeXml();

            int dataBaseListSize = mainProfRoot.DataBaseList.Count;

            string Host;
            string PortNumber;
            string DataSource;
            string InitialCatalog;
            string UserId;
            string Password;

            Console.WriteLine("Data Base Information");
            Console.WriteLine("=====================");

            for (int i = 0; i < dataBaseListSize; i++)
            {
                Host = mainProfRoot.DataBaseList[i].Host;
                PortNumber = mainProfRoot.DataBaseList[i].PortNumber;
                DataSource = mainProfRoot.DataBaseList[i].DataSource;
                InitialCatalog = mainProfRoot.DataBaseList[i].InitialCatalog;
                UserId = mainProfRoot.DataBaseList[i].UserId;
                Password = mainProfRoot.DataBaseList[i].Password;

                Console.WriteLine("Host: " + Host + "   Port Number: " + PortNumber + "   Data Base: " + DataSource
                    + "   Data Table: " + InitialCatalog + "   User: " + UserId + "   Password: " + Password);
            }
            Console.ReadKey();
        }
    }
}
