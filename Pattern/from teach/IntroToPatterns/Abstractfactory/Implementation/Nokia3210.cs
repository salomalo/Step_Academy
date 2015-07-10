using System;

namespace Abstractfactory
{
    class Nokia3210 : ISimplePhone
    {
        public string Name { get { return "Old good nokia 3310"; } }
        public int Year { get { return 1995; } }


        public string GetColor()
        {
            throw new NotImplementedException();
        }
    }
}