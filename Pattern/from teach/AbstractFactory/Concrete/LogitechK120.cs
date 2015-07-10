namespace AbstractFactory.Concrete
{
    class LogitechK120 : ISimpleKeyboard
    {
        public string Name
        {
            get { return "Logitech Keyboard K120 USB"; }
        }

        public int KeysCount
        {
            get { return 102; }
        }
    }
}
