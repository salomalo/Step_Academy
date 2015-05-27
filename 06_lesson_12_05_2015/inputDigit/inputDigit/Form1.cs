using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inputDigit
{
    public partial class Form1 : Form
    {

        Module m { set; get; }
        object fact;


        public Form1()
        {
            InitializeComponent();
        }


        public Form1(Module m, object target )
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //переписати  asm.GetModule("inputDigit.exe").GetType("ClassLibrary1.Form1").GetMethod("Method").Invoke(null, null);
            m.GetType("outputDigit.Form1").GetMethod("DigitShow").Invoke(fact, new object[] { this.textBox1.Text });
        }


        public int Method()
        {
            int tmp = Int32.Parse(textBox1.Text);
            return tmp;
        }

    }
}
