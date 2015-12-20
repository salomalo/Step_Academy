using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tetris_points
{
   class Program
    {
        static void Main(string[] args)
        {
            bool[,] Arr = new bool[20, 20];


            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(0); j++)
                {
                    Arr[16, 5] = true;
                    Arr[17, 5] = true;
                    Arr[19, 18] = true;

                    if (/*i == 19 ||*/ i == 18)
                    {
                        Arr[i, j] = true;
                    }
                    else
                    {
                        Arr[i, j] = false; // ініціалізую стакан 
                    }
                }
            }
            Print(Arr);
            CheckLine(Arr);

            int number_line = CheckLine(Arr);

            DeleteLine(Arr, number_line);

        } // main 

        public static int CheckLine(bool[,] Arr)
        {
            int res = 0; // index of line with all true
            int num = 0;
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(0); j++)
                {
                    if (Arr[i, j] == true)
                    {
                        num++;
                    }
                }
                if (num == Arr.GetLength(0))
                {
                    res = i;
                }
                num = 0;
            }
            //Console.WriteLine("res {0}", res);
            return res;
        }


        public static void DeleteLine(bool[,] Arr, int num)
        {
            int i = num;
            for (int j = 0; j < Arr.GetLength(1); j++) // x col
            {
                Arr[i, j] = false;
            }

            for (i = num - 1; i >= 0; i--)
            {
                for (int j = 0; j < Arr.GetLength(0); j++) // x col
                {
                    if (Arr[i, j] == true)
                    {
                        if (Arr[i + 1, j] == false)
                        {
                            Arr[i, j] = false;
                            Arr[i + 1, j] = true;
                        }
                    }
                }
            }

            for (i = num; i > 0; i--)
            {
                for (int j = 0; j < Arr.GetLength(0); j++) // x col
                {
                    if (Arr[i, j] == true)
                    {
                        if (Arr[i + 1, j] == false)
                        {
                            Arr[i, j] = false;
                            Arr[i + 1, j] = true;
                        }
                    }
                }
            }


//////////////////

            for (i = num; i > 0; i--)
            {
                for (int j = 0; j < Arr.GetLength(0); j++) // x col
                {
                    Arr[i, j] = Arr[i - 1, j];
                }
            }


//////////////////
    int i = num;
            for (int j = 0; j < Arr.GetLength(1); j++) // x col
            {
			//Score++;
               Arr[i, j] = false;
            }


            for (i = num - 1; i >= 0; i--)
            {
                for (int j = 0; j < Arr.GetLength(0); j++) // x col
                {
                    if (Arr[i, j] == true)
                    {
                        if (Arr[i + 1, j] == false)
                        {
                            Arr[i, j] = false;
                            Arr[i + 1, j] = true;
                        }
                    }
                }
            }

            for (i = num; i > 0; i--)
            {
                for (int j = 0; j < Arr.GetLength(0); j++) // x col
                {
                    if (i == Arr.GetLength(0))
                    {
                        if (Arr[i - 1, j] == true)
                        {
                            Arr[i, j] = true;
                        }
                        if (Arr[i - 1, j] == false)
                        {
                            Arr[i, j] = false;
                        }
                    }

                    if (i != Arr.GetLength(0))
                    {
                        if (Arr[i, j] == true)
                        {
                            if (Arr[i + 1, j] == false)
                            {
                                Arr[i, j] = false;
                                Arr[i + 1, j] = true;
                            }
                        }
                    }
                }
            }






             Print(Arr);
           


            ////////////////////////////////////////////////

        }


        public static void Print(bool[,] Arr) // малюю стакан із фігурками !!!!!!!
        {
            for (int i = 0; i < Arr.GetLength(0); i++) // y row
            {
                for (int j = 0; j < Arr.GetLength(1); j++) // x col
                {
                    if (Arr[i, j] == false)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine(" {0}", i);
            }
            Console.WriteLine();
        } //Print
    } // Program





}