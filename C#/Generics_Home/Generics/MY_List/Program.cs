using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_List
{
    class Program
    {
        static void Main(string[] args)
        {
            // MyList<int>.Arr = new int[] { 1, 2 };

            //foreach (int item in MyList<int>.Arr)
            //{
            //    Console.WriteLine(item);
            //}


            //   Console.WriteLine(MyList<int>.Arr[0]);

            MyList<int> lis = new MyList<int>(2);




            lis.Add(5);
            lis.Add(8);

            lis.MinIs<int>();
            Console.WriteLine(lis.tmp);

            //foreach (int item in MyList<int>.Arr)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }



    class MyList<TType> :IComparable, ICollection, IEnumerable
    {
        public static TType[] Arr { set; get; }

        public MyList(int size)
        {
            Arr = new TType[size + 1];
           
            //Arr = default(TType[]);
        }

        public MyList(TType [] size)
        {
            Arr = size;

            //Arr = default(TType[]);
        }
        public TType tmp {set; get;}
        
        public void MinIs<TType>() where TType : IComparable
        {
            TType [] t = new TType[Arr.Length+1];
            
            for (int i = 0; i < Arr.Length; i++)
            {
                for (int j = i+1; j < Arr.Length; j++)
                { 
                if (t[i].CompareTo(Arr[j]) > 0)
                {
                    tmp = Arr[i];
                  //  Console.WriteLine(tmp);
                }
                else
                {
                    tmp = Arr[j];
                }
            }
            }
            Console.WriteLine(tmp);
           // return tmp;
        }

        public static TType MaxIs<TType>(TType a, TType b) where TType : IComparable
        {
            if (a.CompareTo(b) < 0)
            {
                return b;
            }
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            return b;
        }

        // public static void Add<TType>(TType b) where TType : ICollection<TType>
        //   {
        //   Arr.ToArray().ToList().Add(b)
        // }

        int listPointer = 0;

        public void Add(TType item)
        {
            if (listPointer >= Arr.Length + 1)
                throw new StackOverflowException();
            Arr[listPointer] = item;
            listPointer++;
        }

        //public TType this[int index]
        //{
        //    set
        //    {
        //        if (index > Arr.Length - 1 || index < 0)
        //        {
        //            throw new IndexOutOfRangeException("to short");
        //        }
        //        Arr[index] = value;
        //    }
        //    get
        //    {
        //        if (index > Arr.Length - 1 || index > 0)
        //        {
        //            throw new IndexOutOfRangeException("to long");
        //        }
        //        return Arr[index];
        //    }
        //}



        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }


        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }


  




    }
}