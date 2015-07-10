using System;
namespace AbstractFactory.Concrete
{
    class LogitechFactory : IKeyboradFactory
    {
        public ISimpleKeyboard ClassicKeyboard
        {
            get { return new LogitechK120(); }
        }

        public IWireLessKeyboard WireLessKeyboard
        {
            get { return new LogitechK400(); }
        }
    }
}
