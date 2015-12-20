using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using TestStack.White.UIItems.Finders;
using Application = TestStack.White.Application;
using WhiteItems = TestStack.White.UIItems;

namespace NotepadTest
{
    [TestFixture]
    public class NotepadTest
    {
        private const string CNTRL_S = "^{s}";
        const string STRING_TO_COMPARE = "Hello, notepad!!!";
        const string FILE_NAME = "test.txt";
        private string PATH = string.Format(@"C:\{0}", FILE_NAME);

        [Test]
        public void RunAndWriteTextIntoNotepadTest()
        {
            Process notepad = new Process();
            notepad.StartInfo.FileName = "notepad.exe";
            notepad.Start();
            notepad.WaitForInputIdle();

            WriteLineToNotePad(STRING_TO_COMPARE);
            SimulateSaveProcessInNotepad();
            CompareResult();
            notepad.CloseMainWindow();
            File.Delete(Path.GetFullPath(PATH));
        }

        private void WriteLineToNotePad(string line)
        {
            SendKeys.SendWait(line);
        }

        private void SimulateSaveProcessInNotepad()
        {
            SendKeys.SendWait(CNTRL_S);

            Application application = Application.Attach("notepad");
            //Window saveDlg = application.GetWindow("Save As");
            //find window
            var saveDlg = application.GetWindows().Find(win => win.Name.Equals("Save As"));

            //find 
            var fileNameTextBox = saveDlg.Get<WhiteItems.TextBox>(SearchCriteria.ByAutomationId("1001"));
            fileNameTextBox.Text = FILE_NAME;
            var btnOk = saveDlg.Get<WhiteItems.Button>(SearchCriteria.ByAutomationId("1"));
            btnOk.Click();
        }

        private void CompareResult()
        {
            var text = File.ReadAllText(Path.GetFullPath(PATH));
            Assert.AreEqual(STRING_TO_COMPARE, text);
        }
    }
}