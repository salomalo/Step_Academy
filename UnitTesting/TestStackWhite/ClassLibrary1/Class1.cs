using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestStack.White.UIItems.Finders;
using WhiteItems = TestStack.White.UIItems;


namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        private const string CNTRL_S = "^{p}";
        const string text = "test";
        const string name = "test.txt";


        [Test]
        public void RunNotepad()
        {
            Process notepad = new Process();
            notepad.StartInfo.FileName = "notepad.exe";
            notepad.Start();
            notepad.WaitForInputIdle();
            WriteToNotepad(text);
            Simulate();
        }

        private void WriteToNotepad(string line)
        {
            SendKeys.SendWait(line);
        }

        private void Simulate()
        {
            SendKeys.SendWait(CNTRL_S);
            TestStack.White.Application app = TestStack.White.Application.Attach("notepad");
            
            TestStack.White.Application appF = TestStack.White.Application.Attach("WFS");

            var pDi = app.GetWindows().Find(win => win.Name.Equals("Print"));

            var btnPrint = pDi.Get<WhiteItems.Button>(SearchCriteria.ByAutomationId("1"));

            var btnOk = 


        }//



    }



}