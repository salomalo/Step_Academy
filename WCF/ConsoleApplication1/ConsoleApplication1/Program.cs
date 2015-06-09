﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyMath));
            sh.AddServiceEndpoint(typeof(IMyMath), new WSHttpBinding(), "http://localhost/MyMath/Ep1");
            sh.Open();

            Console.WriteLine("enter");
            Console.ReadLine();
            sh.Close();
        }
    }





    //[ServiceContract]
    //public class MyMath
    //{
    //    [OperationContract]
    //    public int Add(int a,int b)
    //    {
    //        return a + b;
    //    }
    
    //}

    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
    }

    public class MyMath : IMyMath
    {       
        public int Add(int a, int b)
        {
            return a + b;
        }
    }



    
}