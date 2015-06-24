using Client.ServiceNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{

        public class CallBackHendler : IDuplexCallback
        {
            static InstanceContext insCont = new InstanceContext(new CallBackHendler());
            public static DuplexClient duClient = new DuplexClient(insCont);

            public void ReciveTime(string time)
            {
                Console.WriteLine(time);
            }
        }

    public partial class Form1 : Form
    {




        public Form1()
        {
            InitializeComponent();

            CallBackHendler.duClient.CallClientMethod(100, 10);
            Console.ReadLine();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
}
