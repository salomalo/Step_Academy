using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
   // public delegate void EventHandler();      // оголошуємо тип делегата який працює з нашою подією
    public delegate void EventHandler(object sender, EventArgs arg);  
    class Program
    {
        static void Main(string[] args)
        {
            WithEvent withevent = new WithEvent();
            Listener listener = new Listener();
            withevent.SomeEvent += listener.PerfomReaction;
            withevent.SomeEvent += ListenerStatic.PerfomReaction;
            withevent.OnSomeEvent();
            withevent.SomeEvent -= ListenerStatic.PerfomReaction;
            withevent.SomeEvent -= ListenerStatic.PerfomReaction;
            withevent.OnSomeEvent();
        }
    }

    class WithEvent                    //клас відправник події
    {
        public event EventHandler SomeEvent;          //оголошуємо подію

        public void OnSomeEvent()
        {
            Console.WriteLine("Some event happend");
            if (SomeEvent != null)       //перевірка чи хтось підписався на подію
            {
                SomeEvent(this, EventArgs.Empty);
            }
        }
    }


    class Listener
    {
        public void PerfomReaction(object sender, EventArgs arg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("after some event");
            Console.ResetColor();
        }
    }


    static class ListenerStatic 
    {
        public static void PerfomReaction(object sender, EventArgs arg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("STATIC after some event");
            Console.ResetColor();
        }
    }
}
