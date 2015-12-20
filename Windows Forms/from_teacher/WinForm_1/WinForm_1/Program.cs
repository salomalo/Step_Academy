using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            TextBox tb = new TextBox();
            Button btn = new Button();
           
            btn.Click += (sender, arg) =>
            {
                Console.WriteLine("Button click");
            };
            form.Text = "Hello";
            form.Controls.Add(tb);
            form.Controls.Add(btn);
            form.ShowDialog();
        }
    }
}
