using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Method("start service");
        }

        protected override void OnStop()
        {
            Method("stop service");
        }

        private void Method(string tmp)
        {
            StreamWriter stream = null;
            try
            {
                stream = new StreamWriter("test.txt", true);
                stream.WriteLine(tmp);
            }
            catch
            {
                //StreamWriter er = new StreamWriter();

            }
            finally
            {
                stream.Close();
            }
        
        }


    }
}
