using System;
using Abstractfactory;
using Abstractfactory.Abstract;
using Builder;
using Builder.Concrete;

namespace ConsoleApplication1
{
    class TextReport : IReportBuilder
    {
        public void CreateHeader()
        {
        }

        public void CreateBody()
        {
        }

        public void CreateFooter()
        {
        }

        public Report GetReport()
        {
            return new Report
            {
                Data = @"1. Head\n\r2.Body"
            };
        }
    }
    class HtmlReport : IReportBuilder
    {
        private string _data;
        public void CreateHeader()
        {
            _data += "<html><head>My head</head>";
        }

        public void CreateBody()
        {
            _data += "<body><p>Body text</p>";
        }

        public void CreateFooter()
        {
            _data += "<p>Footer part</p></body></html>";
        }

        public Report GetReport()
        {
            return new Report
            {
                Data = _data
            };
        }
    }


    public interface IReportBuilder
    {
        void CreateHeader();
        void CreateBody();
        void CreateFooter();
        Report GetReport();
    }

    public class Report
    {
        public string Data { get; set; }

        public void Print()
        {
            Console.WriteLine(Data);
        }
    }

    public class ReportCreator
    {
        private readonly IReportBuilder _builder;

        public ReportCreator(IReportBuilder builder)
        {
            _builder = builder;
        }

        public void CreateReport()
        {
            //ПОКРОКОВЕ КОНСТРУЮВАННЯ!!!!
            _builder.CreateHeader();
            _builder.CreateBody();
            _builder.CreateFooter();
        }

        public Report GetReport()
        {
            return _builder.GetReport();
        }
    }


    //class MyConsoleLogger : ILogger
    //{
    //    public void Log(string arg)
    //    {
    //        Console.WriteLine(arg);
    //    }
    //}

    //class MessageBoxLogger : ILogger
    //{
    //    public void Log(string arg)
    //    {
    //        MessageBox.Show(arg);
    //    }

    //    public void Log(string arg, params object[] dd )
    //    {
    //        string.Format(arg, dd);
    //        MessageBox.Show(arg);
    //    }
    //}


    class Program
    {
        static void Main(string[] args)
        {
            var first = new HtmlReport();
            var second = new TextReport();

            ReportCreator director = new ReportCreator(second);

            director.CreateReport();
            Report report = director.GetReport();

            report.Print();

            //VehicleCreator director = new VehicleCreator(new FordBuilder());

            ////construct
            //director.CreateVehicle();

            //Vehicle car = director.GetVehicle();


            ////var c = new Calc(new MessageBoxLogger());
            ////c.Add(1, 3);

            //IAbstracFactory fc = new NokiaFactory();
            //WorkWithAf(new NokiaFactory());

            //var ls = new List<int>();

            //int sum = ls.Sum();

            //Log("Sum = {0} {1}", sum, 1+2);
        }

        public static void Log(string format, params object[] dd)
        {
            Console.WriteLine(format, dd);
        }

        private static void WorkWithAf(IAbstracFactory fc)
        {
            DoSome(fc);
        }

        private static void DoSome(IAbstracFactory fc)
        {
            var simple = fc.CreateSimple();
            var smart = fc.CreateSmart();

            Print(simple);
            Print(smart);
        }


        private static void Print(ISimplePhone p)
        {
            const string simplePhone = "Simple phone: {0} {1}";
            Console.WriteLine(simplePhone, p.Name, p.Year);
        }

        private static void Print(ISmartPhoneMySuperPhone p)
        {
            Console.WriteLine("Smart phone: {0} {1}", p.Name, p.Year);
        }

    }
}
