namespace Abstractfactory
{
    public interface ISimplePhone
    {
        string Name { get;  }
        int Year { get; }
        string GetColor();
    }
}