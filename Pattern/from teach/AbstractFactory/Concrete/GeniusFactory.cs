namespace AbstractFactory.Concrete
{
    class GeniusFactory : IKeyboradFactory
    {
        public ISimpleKeyboard ClassicKeyboard
        {
            get { return new Genius720(); }
        }

        public IWireLessKeyboard WireLessKeyboard
        {
            get { return new GeniusT8020(); }
        }
    }
}
