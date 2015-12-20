using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singletone
{
    class Program
    {
        // потокобезпечний + лейзі
        public sealed class SafeSingleton
        {
            static Lazy<SafeSingleton> mySingl = new Lazy<SafeSingleton>(() => { return new SafeSingleton(); });

            public SafeSingleton()
            {
                //mySingl = new SafeSingleton();
            }

            public SafeSingleton Instance
            {
                get
                {
                    return mySingl.Value;
                }
            }

        }

        static void Main(string[] args)
        {
            SafeSingleton sing = new SafeSingleton();
        }

    }
}