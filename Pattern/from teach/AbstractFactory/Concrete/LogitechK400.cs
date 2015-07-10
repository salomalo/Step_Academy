namespace AbstractFactory.Concrete
{
    class LogitechK400 : IWireLessKeyboard
    {
        public string Name
        {
            get { return "Logitech Wireless Touch Keyboard K400"; }
        }

        public int KeysCount
        {
            get { return 100; }
        }
    }
}
