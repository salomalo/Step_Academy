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
            MyList<int> lis = new MyList<int>(0);

            lis.Add(1);
            lis.Add(8);
            lis.Add(10);
            lis.Add(5);
            lis.Add(3);

            //Console.WriteLine("IndexOf: {0}", lis.IndexOf(8));
            //Console.WriteLine("Sorted list: ");
            //lis.Sort();

            Console.WriteLine("Max: {0} ", lis.MaxIs());
            Console.WriteLine("Min: {0} ", lis.MinIs());

            //lis.MinIs();
            //Console.WriteLine("Min: {0} ", lis.Min);
            //lis.MaxIs();
            //Console.WriteLine("Max: {0} ", lis.Max);

            lis.Show();
            lis.Delete(5);
        }
    }

    class MyList<TType>  where TType : IComparable<TType>//,new()
    {
        TType[] Arr { set; get; }
        public static int Length { set; get; }

        public TType Min;
        public TType Max;

        public int listPointer;

        public MyList(int len)
        {
            listPointer = 0;
            Length = len;
            Arr = new TType[Length];
        }

        //public TType MinIs()
        //{ 
        //    for (int i = 0; i < Arr.Length; i++)
        //    {
        //        for (int j = i + 1; j < Arr.Length; j++)
        //        {
        //            if (Arr[i].CompareTo(Arr[j]) < 0)
        //            {
        //                Min = Arr[i];
        //            }
        //            //else
        //            //{
        //            //    Min = Arr[j];
        //            //}
        //        }
        //    }
        //    return Min;
        //}

        //public TType MaxIs()
        //{
        //    for (int i = 0; i < Arr.Length; i++)
        //    {
        //        for (int j = i + 1; j < Arr.Length; j++)
        //        {
        //            if (Arr[i].CompareTo(Arr[j]) > 0)
        //            {
        //                Max = Arr[i];
        //            }
        //            //else
        //            //{
        //            //    Max = Arr[j];
        //            //}
        //        }
        //    }
        //    return Max;
        //}

        public TType MaxIs()
        { 
            return Arr.Max(); 
        }

        public TType MinIs()
        { 
            return Arr.Min(); 
        }

        public void Add(TType item)
        {
            TType[] tmp = new TType[Arr.Length + 1];
            Array.Resize<TType>(ref tmp, Arr.Length + 1);
            Array.Copy(Arr, tmp, Arr.Length);
            tmp[Arr.Length] = item;
            Arr = tmp;
        }
     
        public void Delete(TType item) 
        {
            int rem = IndexOf(item);
            TType[] tmp = new TType[Arr.Length-1];
            Array.Resize<TType>(ref tmp, Arr.Length - 1);
            Array.Copy(Arr,tmp, rem);
            Array.Copy(Arr, rem + 1, tmp, rem, Arr.Length - rem-1);
            Arr = tmp;
        }

        public void Show()
        {
            foreach (var v in Arr)
            {
                Console.WriteLine(v.ToString());
            }        
        }

        public void Sort()
        {
            Array.Sort(Arr);
        }

        public int IndexOf(TType tmp)
        {
            return Array.IndexOf<TType>(Arr, tmp);
        }

        public TType this[int index]
        {
            set
            {
                if (index > Arr.Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException("to short");
                }
                Arr[index] = value;
            }
            get
            {
                if (index > Arr.Length - 1 || index > 0)
                {
                    throw new IndexOutOfRangeException("to long");
                }
                return Arr[index];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Arr.GetEnumerator();
        }


    }
}