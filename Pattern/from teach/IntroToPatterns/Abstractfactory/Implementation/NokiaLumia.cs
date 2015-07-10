using System;
using Abstractfactory.Abstract;

namespace Abstractfactory
{
    class NokiaLumia : ISmartPhoneMySuperPhone
    {
        public string Name { get { return "Lumia 930"; } }
        public int Year { get { return 2014; } }


        public int GetScreenSize()
        {
            throw new NotImplementedException();
        }
    }
}
