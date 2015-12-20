using System;

namespace UnitTesting
{
    public interface IConsoleProvider
    {
        void WriteLine(string format, params object[] objs);
    }

    class ConsoleProvider : IConsoleProvider
    {
        public void WriteLine(string format, params object[] objs)
        {
            //untestable!
            Console.WriteLine(format, objs);
        }
    }
}