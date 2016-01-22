using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
using MetroFramework.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace ProcessKiller
{
    public partial class frmProcessKiller : MetroForm
    {
        public List<Service> services;
        Profile profile = new Profile();
        CurrencyManager currencyManager = null;
        private  ManagementScope ms;
        ServerInformation serverInformation = new ServerInformation();
        DataBaseInformation dbInformation = new DataBaseInformation();
        ServiceInformation serviceInformation = new ServiceInformation();
        //private String user =       "administrator";
        //private String pass =       "PLan0Labs!";
        private String hostname =   "ACCCMHA2";

        public static String selectedService;

        public frmProcessKiller()
        {
            //setup form elements and event handlers
            this.InitializeComponent();
            //setup XML
            consumeXML();
            //get connection info and details from services
            ProcessServices();

            metroGrid1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_RowClick);
        }
        public void consumeXML()
        {
            MainProfileRoot rootObject = new MainProfileRoot().DeserializeXml();
            int profileNumber = rootObject.ProfileList.Count;
            int serviceNumber;
            string serviceName;
            string serviceHost;
            string serviceDomain;
            string serviceStartType;
            int serviceGroup;
            for (int i = 0; i < profileNumber; i++)
            {
                serviceNumber = rootObject.ProfileList[i].ServiceList.Count;
                for (int j = 0; j < serviceNumber; j++)
                {
                    serviceName = rootObject.ProfileList[i].ServiceList[j].Name;
                    serviceHost = rootObject.ProfileList[i].ServiceList[j].Server;
                    serviceDomain = rootObject.ProfileList[i].ServiceList[j].Domain;
                    serviceStartType = rootObject.ProfileList[i].ServiceList[j].StartType;
                    serviceGroup = rootObject.ProfileList[i].ServiceList[j].Group;

                    if (serviceDomain == "")
                    {
                        serviceDomain = "null";
                    }


                    profile.ServiceList.Add(new Service() { Name = serviceName, Server = serviceHost, Domain = serviceDomain, StartType = serviceStartType, Group = serviceGroup, Status = "not set" });
                    
                } 
            }
        }

        
        public  void ProcessServices()
        {
            
            services = profile.ServiceList;
            foreach (Service s in services)
            {
                //send selected service to have state updated
                updateService(s);
            }
        }
        //connects to remote machine using username, password, and hostname loaded from XML
        private  void ConnectToTargetMachine(Service service)
        {
            String[] serviceDetails = service.ToStringArray();
            //Connect to the remote computer
            ConnectionOptions co = new ConnectionOptions();
            co.Username = serviceDetails[7];
            co.Password = serviceDetails[8];
            //connect to remote machine WMI directory and connection credentials
            //ms = new ManagementScope(@"\\" + serviceDetails[6] + "\\root\\cimv2", co);
            ms = new ManagementScope(@"\\" + this.hostname + "\\root\\cimv2", co);
        }
        //called when stop buton is clicked
        private void stop_Click(object sender, EventArgs e)
        {
            //pass name of selected item in listbox to method
            //method will find servicethat name and stop it
            stopservice(selectedService);
        }
        //called when stop buton is clicked
        private void start_Click(object sender, EventArgs e)
        {
            //pass name of selected item in listbox to method
            //method will find servicethat name and start it
            startservice(selectedService);
        }
        //called when a service needs to be stopped
        //takes parameter of scope(directory where services are located on target machine)
        //and 'svcname' the name of the service to be stopped
        public void stopservice(string svcname)
        {
            //construct the wmi query to be executed on the remote machine
            //get service on target machine that matches the parameter 'svcname'
            SelectQuery query = new SelectQuery("select * from win32_service where name = '" + svcname + "'");
            //execute the query. passing 'scope' WMI directory on target, and the query created in last step
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(ms, query))
            {
                ManagementObjectCollection collection = searcher.Get();
                //iterate over all search results (may be more than one?)
                foreach (ManagementObject service in collection)
                {
                    //stop the service
                    service.InvokeMethod("stopservice", null);
                }
            }
        }
        //called when a service needs to be started
        //takes parameter of scope(directory where services are located on target machine)
        //and 'svcname' the name of the service to be started
        public void startservice(string svcname)
        {
            //construct the wmi query to be executed on the remote machine
            //get service on target machine that matches the parameter 'svcname'
            SelectQuery query = new SelectQuery("select * from win32_service where name = '" + svcname + "'");
            //execute the query. passing 'scope' WMI directory on target, and the query created in last step
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(ms, query))
            {
                ManagementObjectCollection collection = searcher.Get();
                //iterate over all search results (may be more than one?)
                foreach (ManagementObject service in collection)
                {
                    //stop the service
                    service.InvokeMethod("startservice", null);
                }
            }
        }
        private void updateService(Service s)
        {
            ConnectToTargetMachine(s);
            //services.Clear();
            //construct query to select all services
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Service");
            //execute query
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(ms, query);
            //iterate over results
            foreach (ManagementObject o in searcher.Get())
            {
                //if selected service object is equal to passed service name
                if (o["DisplayName"].ToString().Contains(s.Name))
                {
                    //set service state
                    s.Status = o["State"].ToString();
                    //add service to 
                    //services.Add(new Service() { DisplayName = o["DisplayName"].ToString(), ServiceName = o["Name"].ToString(), Status = o["State"].ToString(), ServerLocation = hostname });
                    currencyManager = (CurrencyManager)metroGrid1.BindingContext[services];
                }
            }
            metroGrid1.DataSource = services;
        }
        private void metroGrid1_RowClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedService = (String)((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;
        }
        private void startAll_Click(object sender, EventArgs e)
        {
            foreach (Service s in services)
            {
                metroLabel3.Text = "Starting: " + s.Name;
                var threadReturnValue = 0; // Used to store the return value
                var thread = new Thread(
                  () =>
                  {
                      threadReturnValue = 7; // return value to update progress bar
                      startservice(s.Name);
                  });
                thread.Start();
                thread.Join();
                metroProgressBar1.Value += threadReturnValue; //use return value here
            }
            metroProgressBar1.Value = 0;
            metroLabel3.Text = "";
            //fillServiceList();
        }
        private void stopAll_Click(object sender, EventArgs e)
        {
            var mainThread = new Thread(
            () =>
            {
                foreach (Service s in services)
                {
                    var threadReturnValue = 0;
                    var servicethread = new Thread(
                      () =>
                      {
                          threadReturnValue = 7; // return value to update progress bar
                          stopservice(s.Name);
                      });
                    servicethread.Start();
                    servicethread.Join();
                    metroProgressBar1.Value += threadReturnValue; //use return value here
                }
            });
            mainThread.Start();
            mainThread.Join();
            metroProgressBar1.Value = 0;
            metroLabel3.Text = "";
            //fillServiceList();
        }
    }
}
