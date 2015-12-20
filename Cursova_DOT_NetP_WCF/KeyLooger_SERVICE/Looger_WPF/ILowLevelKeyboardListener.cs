using System;
namespace Looger_WPF
{
    interface ILowLevelKeyboardListener
    {
        void HookKeyboard();
        event EventHandler<KeyPressedArgs> OnKeyPressed;
        void UnHookKeyboard();
    }
}