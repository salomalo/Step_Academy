using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder
{
    public class Report
    {
        public int[] MaxArr { set; get; }
        public string Name { set; get; }
        public int Min { set; get; }
        public int Max { set; get; }
        public int Mid { set; get; }

        public Report()
        {
            MaxArr = new int[0];
            Name = "";
            Min = 0;
            Max = 0;
            Mid = 0;
        }

        public Report(int[] _MaxArr, string _Name, int _Min, int _Max, int _Mid)
        {
            MaxArr = new int[0];
            Name = _Name;
            Min = _Min;
            Max = _Max;
            Mid = _Mid;
        }
    } // Report

    public interface IReportBuilder
    {
        void ReaciveMarks(int[] arr);
        void FindMinMax();
        void FindMaxMax();
        void CountMidMax();
        void SetStudName(string name);
        void CreateTxtReport();
        void CreateHtmlReport();

        void OpenReport();
    } // IReportBuilder

    public class ReportDirector
    {
        public IReportBuilder ReportBuilder { set; get; }



        public void CreateReport(string name, int[] arr)
        {
            ReportBuilder.ReaciveMarks(arr);
            ReportBuilder.FindMinMax();
            ReportBuilder.FindMaxMax();
            ReportBuilder.CountMidMax();
            ReportBuilder.SetStudName(name);
            ReportBuilder.CreateTxtReport();
            ReportBuilder.CreateHtmlReport();
        }
    } // ReportDirector





    public class MyTxtReportBuilder : IReportBuilder
    {
        Report report = new Report();
        public string path { set; get; }

        public MyTxtReportBuilder()
        {
            path = "d:\\REPORT.txt";
        }

        public void ReaciveMarks(int[] arr)
        {
            report.MaxArr = arr;
        }

        public void FindMinMax()
        {
            report.Min = report.MaxArr.Min();
        }

        public void FindMaxMax()
        {
            report.Max = report.MaxArr.Max();
        }

        public void CountMidMax()
        {
            int tmp = 0;
            for (int i = 0; i < report.MaxArr.Length; i++)
            {
                tmp += report.MaxArr[i];
            }
            report.Mid = tmp / report.MaxArr.Length;
        }

        public void SetStudName(string name)
        {
            report.Name = name;
        }

        public void CreateTxtReport()
        {
            StreamWriter writer = null;
            try
            {
                FileStream file = new FileStream(path, FileMode.Append);
                writer = new StreamWriter(file);
                writer.Write("Name:{0}\n MinMax: {1}\n MaxMax: {2}\n MidMax: {3}\n", report.Name, report.Min, report.Max, report.Mid);
                writer.Write(Environment.NewLine);
            }
            catch (Exception c)
            {
                Console.WriteLine(c.Message);
            }
            finally
            {
                writer.Close();            
            }
        }

        public void CreateHtmlReport()
        {
          //  throw new NotImplementedException();
        }

        public void OpenReport()
        {
            Process.Start(@"notepad.exe", path);
        }
    } // MyTxtReportBuilder

    //
    public class MyHTMLReportBuilder : IReportBuilder
    {
        Report report = new Report();
        public string path { set; get; }

        public MyHTMLReportBuilder()
        {
            path = "d:\\htmlREPORT.html";
        }

        public void ReaciveMarks(int[] arr)
        {
            report.MaxArr = arr;
        }

        public void FindMinMax()
        {
            report.Min = report.MaxArr.Min();
        }

        public void FindMaxMax()
        {
            report.Max = report.MaxArr.Max();
        }

        public void CountMidMax()
        {
            int tmp = 0;
            for (int i = 0; i < report.MaxArr.Length; i++)
            {
                tmp += report.MaxArr[i];
            }
            report.Mid = tmp / report.MaxArr.Length;
        }

        public void SetStudName(string name)
        {
            report.Name = name;
        }

        public void CreateTxtReport()
        {
            //StreamWriter writer = null;
            //try
            //{
            //    FileStream file = new FileStream(path, FileMode.Append);
            //    writer = new StreamWriter(file);
            //    writer.Write("Name:{0}\n MinMax: {1}\n MaxMax: {2}\n MidMax: {3}\n", report.Name, report.Min, report.Max, report.Mid);
            //    writer.Write(Environment.NewLine);
            //}
            //catch (Exception c)
            //{
            //    Console.WriteLine(c.Message);
            //}
            //finally
            //{
            //    writer.Close();
            //}
        }

        public void CreateHtmlReport()
        {
            StreamWriter writer = null;
            try
            {
                FileStream file = new FileStream(path, FileMode.Append);
                writer = new StreamWriter(file);
                writer.Write("Name:{0} \n MinMax: {1} \n MaxMax: {2} \n MidMax: {3} \n", report.Name, report.Min, report.Max, report.Mid);
                writer.Write(Environment.NewLine);
            }
            catch (Exception c)
            {
                Console.WriteLine(c.Message);
            }
            finally
            {
                writer.Close();
            }
        }

        public void OpenReport()
        {
            Process.Start(@"chrome.exe", path);

        }
    } // MyHTMLReportBuilder
    //
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter student name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter count of max: ");
            int count ;
            Int32.TryParse(Console.ReadLine(), out count);
            Console.WriteLine(count.ToString());

            Console.WriteLine("Enter {0} max:", count);

            int[] arr = new int[count];

            for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = Int32.Parse(Console.ReadLine());
                }
      

            ReportDirector director = new ReportDirector();
           
            //IReportBuilder repbuild = new MyTxtReportBuilder();
            //director.ReportBuilder = repbuild;
            //director.CreateReport(name, arr);
            //repbuild.OpenReport();


            IReportBuilder htmlrepbuild = new MyHTMLReportBuilder();
            director.ReportBuilder = htmlrepbuild;
            director.CreateReport(name, arr);
            htmlrepbuild.OpenReport();
        }
    }




}