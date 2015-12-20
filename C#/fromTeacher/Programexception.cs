using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
            //    try
            //    {
            //        int b = Int32.Parse(Console.ReadLine());
            //        int a = 58 / b;
            //        Console.WriteLine("after readline in try");
            //        if (a < 1)
            //        {
            //           // throw new ArgumentOutOfRangeException();
            //            throw new ArgumentOutOfRangeException("b",b,String.Format("Enter numder less then 58 - you have entered {0}",b));
            //        }
            //        int size = 9;
            //        size *= a;
            //        break;
            //    }
            //    catch (DivideByZeroException e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //    catch (FormatException e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //    catch (OverflowException e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //    catch (ArgumentException e)
            //    {
            //        Console.WriteLine("Argument exception : {0}",e.Message);
            //    }
            //    catch (Exception e) //catch all C# Exception
            //    {
            //        Console.WriteLine("Base Exception");
            //        Console.WriteLine(e.Message);
            //    }
            //    /*   catch (ArgumentException e)  //will not work after Exception e
            //       {

            //       }*/
            //    catch
            //    {
            //        Console.WriteLine("Catch exceptions from other languges");
            //    }
            //    // Console.WriteLine(); //Error in code!!!

            //    finally
            //    {
            //        Console.WriteLine("Finally: I will work anyway");
            //    }
            //}

            /*--------------------------------------------------------------------------------------------------------*/

           //try
           // {
           //     Console.WriteLine("In outer try before exception");
           //     try
           //     {
           //         Console.WriteLine("In inner try before exception");
           //         throw new ArgumentException();
           //       /*  int a = 0;
           //         int b = 2 / a;*/
           //       //  throw new DivideByZeroException();
           //         Console.WriteLine("In inner try after exception");
           //     }
           //     catch (ArgumentException e)
           //     {
           //         Console.WriteLine("In inner catch");
           //         Console.WriteLine(e.Message);
           //         throw;
           //     }
           //     Console.WriteLine("In outer try after exception");
           // }
           // catch (DivideByZeroException e)
           // {
           //     Console.WriteLine("In out catch");
           //     Console.WriteLine(e.Message);
           // }
           // catch (ArgumentException e)
           // {
           //     Console.WriteLine("In secont out catch");
           //     Console.WriteLine(e.Message);
           // }

            /*-----------------------------------------------------------------------------------------------*/

           // Test.Print();//Error because not static
         
        /*    try
            {
                Test.Print();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }*/


            /*-----------------------------------------------*/
            byte b = 0;

            int i = 0;

            while (i < 1000)
            {
                checked //unchecked defaul (chhecked - check  type size - for byte will throw exception sfter 255)
                {
                    b++;
                    i++;
                }

                Console.Write("{0} ", b);
            }
        }
    }



    static class Test
    {
        public static int a = 6;
    /*    public void Print()
        {
            Console.WriteLine("Test Print {0}", a);
        }
        */
        public static void Print()
        {
            Console.WriteLine("Test Print");
            try
            {
                int a = 0;
                int b = 2 / a;
            }
            catch (DivideByZeroException e)
            {
               // throw;
                a = 5;
                throw new ArgumentException("Be attantion");
            }
        }
    }
}
