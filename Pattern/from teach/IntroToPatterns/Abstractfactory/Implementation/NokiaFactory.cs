using Abstractfactory.Abstract;

namespace Abstractfactory
{
    public class NokiaFactory : IAbstracFactory
    {
        public ISimplePhone CreateSimple()
        {
            return new Nokia3210();
        }

        public ISmartPhoneMySuperPhone CreateSmart()
        {
            return new NokiaLumia();
        }
    }
}