using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        ServiceHost sh;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            sh = new ServiceHost(typeof(Service1), new Uri("http://localhost/Service1/"));
            sh.Open();
        }


        protected override void OnStop()
        {
            sh.Close();
        }


    }


}
