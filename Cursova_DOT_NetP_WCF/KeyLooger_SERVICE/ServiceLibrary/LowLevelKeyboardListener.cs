using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServiceLibrary
{

    public class LowLevelKeyboardListener : ILowLevelKeyboardListener
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;


        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        public event EventHandler<KeyPressedArgs> OnKeyPressed;
        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;


        //установка хука
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, //idHook – это числовая константа WH_* которая задает тип устанавливаемого хука.
            LowLevelKeyboardProc lpfn,//адрес функции-фильтра
            IntPtr hMod, //хэндл модуля, содержащего фильтрующую функцию
            uint dwThreadId);//идентификатор потока, для которого устанавливается хук.


        //зняття хука
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);//IntPtr hhk - хендл установленного хука.

        //вызывает следующую процедуру ловушки в текущей цепочке. Процедура ловушки может вызывать эту функцию как до, так и после обработки информации о ловушке.
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, //hhk Дескриптор текущей ловушки. Приложение получает этот дескриптор после вызова функции SetWindowsHookEx.
            int nCode, //nCode Код ловушки, переданный в текущую функцию ловушки. Следующая процедура ловушки использует этот код, чтобы обработать информацию о ловушке.
            IntPtr wParam, //wParam Значение wParam, переданное в текущую процедуру ловушки. Значение этого параметра зависит от типа ловушки.
            IntPtr lParam);//lParam Значение lParam, переданное в текущую процедуру ловушки. Значение этого параметра зависит от типа ловушки


        //Функция GetModuleHandle извлекает дескриптор указанного модуля, если файл был отображен в адресном пространстве вызывающего процесса.
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [Out] StringBuilder lParam);


        public LowLevelKeyboardListener()
        {
            _proc = HookCallback;
        }

        public void HookKeyboard()
        {
            _hookID = SetHook(_proc);
        }

        public void UnHookKeyboard()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (OnKeyPressed != null) { OnKeyPressed(this, new KeyPressedArgs(KeyInterop.KeyFromVirtualKey(vkCode))); }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


    }
}
