namespace AbstractFactory
{
    interface IKeyboradFactory
    {
        ISimpleKeyboard ClassicKeyboard { get; }
        IWireLessKeyboard WireLessKeyboard { get; }
    }
}
