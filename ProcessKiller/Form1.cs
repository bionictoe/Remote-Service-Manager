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


namespace ProcessKiller
{
    public partial class frmProcessKiller : Form
    {
        private ManagementScope ms;
        private String service;
        /// <summary>
        /// constructor
        /// </summary>
        public frmProcessKiller()
        {
            InitializeComponent();
            //Connect to the remote computer
            ConnectionOptions co = new ConnectionOptions();
            co.Username = "administrator";
            co.Password = "PLan0Labs!";
            //target service
            //service = "Spooler";
            //connect to remote machine WMI directory and connection credentials
            ManagementScope ms = new ManagementScope(@"\\ACCCMHA2\root\cimv2", co);

            //create query 
            string query = String.Format("SELECT * FROM Win32_Service");
            //execute query
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(ms, new ObjectQuery(query));
            //save query results in rasds object
            ManagementObjectCollection rasds = searcher.Get();
            //iterate over IAsyncResult object
            //get an initial list of processes
            UpdateProcessList(ms);
        }
        /// <summary>
        /// Loop through the list of running processes
        /// and add each process name to the process
        /// listbox
        /// </summary>
        private void UpdateProcessList(ManagementScope ms)
        {
            int count=0;
            // clear the existing list of any items
            lstProcesses.Items.Clear();
            foreach (String s in services(ms))
            {
                lstProcesses.Items.Add(s);
                count++;
            }
            // display the number of running processes in
            // a status message at the bottom of the page
            tslProcessCount.Text = "Services running: " + count;
        }

        /// <summary>
        /// Kill the process selected in the process name
        /// and ID listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKill_Click(object sender, EventArgs e)
        {
            // loop through the running processes looking for a match
            // by comparing process name to the name selected in the listbox
            stopservice(ms, lstProcesses.SelectedItem.ToString());

            // update the list to show the killed process
            // has been removed
            UpdateProcessList(ms);
        }
        public void stopservice(ManagementScope scope, string svcname)
        {
            //define the wmi query to be executed on the remote machine
            SelectQuery query = new SelectQuery("select * from win32_service where name = '" + svcname + "'");

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                ManagementObjectCollection collection = searcher.Get();
                foreach (ManagementObject service in collection)
                {
                    if (service["started"].Equals(true))
                    {
                        //stop the service
                        service.InvokeMethod("stopservice", null);
                        label2.Text = "Stopping: " + svcname;
                    }
                }
            }
            
            UpdateProcessList(scope);
        }
        private void listbox1_selectedindexchanged(object sender, System.EventArgs e)
        {
            label2.Text = "item clicked ";
            // get the currently selected item in the listbox.
            string curitem = lstProcesses.SelectedItem.ToString();

            service = curitem;

            label2.Text = "Stopping: "+service;
        }
        public void startservice(ManagementScope scope, string svcname)
        {
            //define the wmi query to be executed on the remote machine
            SelectQuery query = new SelectQuery("select * from win32_service where name = '" + svcname + "'");

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
            {
                ManagementObjectCollection collection = searcher.Get();
                foreach (ManagementObject service in collection)
                {
                        //stop the service
                        service.InvokeMethod("startservice", null);
                        label2.Text = "Starting: " + svcname;
                }
            }
            
            UpdateProcessList(scope);
        }
        private static ArrayList services(ManagementScope connectionscope)
        {
            //new arraylist
            ArrayList services = new ArrayList();
            //construct query to select all services
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Service");
            //execute query
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionscope, query);
            //iterate over results
            foreach (ManagementObject o in searcher.Get())
            {
                //add the service to a list of running services
                services.Add(o["Name"].ToString()/*+" - ("+o["State"]+")"*/);
            }
            //return list of services
            return services;
        }
        private void btnUpdateProcessList_Click(object sender, EventArgs e)
        {
            startservice(ms, lstProcesses.SelectedItem.ToString());
        }
    }
}
