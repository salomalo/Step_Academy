namespace AbstractFactory.Concrete
{
    class Genius720 : ISimpleKeyboard
    {
        public string Name
        {
            get { return "Genius KB-110 PS/2"; }
        }

        public int KeysCount
        {
            get { return 102; }
        }
    }
}
