using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WindowsService1
{
    public partial class Win_Service1 : ServiceBase
    {
        internal static ServiceHost sh;
        public Win_Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            if (sh != null)
            {
                sh.Close();
            }
            sh = new ServiceHost(typeof(WCF_library.Service1));
            sh.Open();
        }
        protected override void OnStop()
        {
            if (sh != null)
            {
                sh.Close();
                sh = null;
            }
        }
    }
}
