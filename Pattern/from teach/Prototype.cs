using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var pool = GetFigurePool();
            Console.WriteLine("Enter figure type:");
            string tmp = Console.ReadLine();

            var f = pool.SingleOrDefault(x => x.Type.ToString().StartsWith(tmp));

            if (f != null)
            {
                //var clonableFigure = (TetrisFigure)f.Clone();
                var clonableFigure = (TetrisFigure)f.DeepClone();

                Console.WriteLine("Clonable type: {0}", clonableFigure.Type);


                //oopsss...
                //clonableFigure and f have a shared link to MyPoint
                var pos = clonableFigure.Position;
                pos.X = 300;



                Console.WriteLine("");

            }

        }

        private static IEnumerable<TetrisFigure> GetFigurePool()
        {
            IEnumerable<TetrisFigure> pool = new List<TetrisFigure>
            {
                new TetrisFigure
                {
                    Color = "Red",
                    Type = FigureType.LineFigure,
                    Position = new MyPoint
                    {
                        X = 10,
                        Y = 10
                    }
                }
                ,
                new TetrisFigure
                {
                    Color = "Green",
                    Type = FigureType.SquareFigure,
                    Position = new MyPoint
                    {
                        X = 10,
                        Y = 20
                    }
                }
                ,
                new TetrisFigure
                {
                    Color = "Blue",
                    Type = FigureType.ZFigure,
                    Position = new MyPoint
                    {
                        X = 10,
                        Y = 30
                    }
                }
            };

            return pool;
        }


    }

    enum FigureType
    {
        LineFigure,
        SquareFigure,
        ZFigure
    }

    [Serializable]
    class TetrisFigure : ICloneable
    {
        public FigureType Type { get; set; }

        //just for MemberwiseClone test
        public string Color { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }


       // http://msdn.microsoft.com/en-us/library/orm-9780596527730-01-05.aspx
        public object DeepClone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            
            var copy = formatter.Deserialize(stream);

            stream.Close();
            return copy;
        }

        public MyPoint Position { get; set; }
    }

    [Serializable]
    class MyPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
