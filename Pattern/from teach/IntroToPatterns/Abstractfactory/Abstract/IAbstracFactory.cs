namespace Abstractfactory.Abstract
{
    public interface IAbstracFactory
    {
        ISimplePhone CreateSimple();
        ISmartPhoneMySuperPhone CreateSmart();
    }
}