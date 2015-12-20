using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface ILowLevelKeyboardListener
    {
        [OperationContract]
         void HookKeyboard();

         event EventHandler<KeyPressedArgs> OnKeyPressed;
        [OperationContract]
         void UnHookKeyboard();
    }


    public class KeyPressedArgs : EventArgs
    {
        public Key KeyPressed { get; private set; }

        public KeyPressedArgs(Key key)
        {
            KeyPressed = key;
        }
    }


}
