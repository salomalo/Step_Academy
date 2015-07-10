using AbstractFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;



//create database LogMessages

//use LogMessages


//create table [Masseges]
//(
//ID int identity primary key
//,Messages  nvarchar (512) not NULL
//,Data_Today DATETIME
//)

//select *from [Masseges]




namespace AbstractLogFactory
{
    public interface IAbstaractLoger
    {
        ITxtLog CreateTxtLog();
        IXmlLog CreateXmlLog();
        IDbLog CreateDbLog();
    }

    public interface ITxtLog
    {
        string Data { set; get; }
        void SaveLog();
    }

    public interface IXmlLog
    {
        string Data { set; get; }
        void SaveLog();
    }

    public interface IDbLog
    {
        string Data { set; get; }
        void SaveLog();
    }

    public class MyTxtLog : ITxtLog
    {
        public string Data { set; get; }
        public MyTxtLog(string _data)
        {
            Data = _data;
        }
        public void SaveLog()
        {
            StreamWriter writer = null;
            try
            {
                FileStream file = new FileStream("d:\\TXT_Log.txt", FileMode.Append);
                writer = new StreamWriter(file);
                writer.Write(Data);
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

    }//MyTxtLog



    public class MyXMLLog : IXmlLog
    {
        public string FilePath;

        public string Data { get; set; }

        public MyXMLLog(string data)
        {
            FilePath = @"D:\test.xml";
            Id = 0;
            Data = data;
        }
        public int Id { set; get; }
        public void SaveLog()
        {
            Id++;
           
            XmlTextWriter writer = new XmlTextWriter(FilePath, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("Messages");


            /////////////////
            // Начинаем записывать значение parameter
            writer.WriteStartElement("Message");

            // Записываем атрибут
            writer.WriteAttributeString("Id", Id.ToString());

            // Записываем еще 2 значения в текущее значение
            writer.WriteElementString("Text",Data );
            writer.WriteElementString("Date", DateTime.Today.ToString());

            // Закрываем наше значение parameter
            writer.WriteEndElement();
            
            /////////////////

            writer.WriteEndElement(); // Закрываем значение parameters
            writer.WriteEndDocument(); // Закрываем элемент
            writer.Flush();
            writer.Close();

        }
    }
    // http://aione.ru/kak-zapisyivat-dannyie-v-xml_iz_csharp/
    public class MyDBLog : IDbLog
    {
        public string Data { set; get; }

        public MyDBLog(string data)
        {
            Data = data;
        }

        public void SaveLog()
        {
            using (var ctx = new LogMessagesEntities())
            {
                Masseges mes = new Masseges();
                mes.Messages = Data;
                mes.Data_Today = DateTime.Today;
                ctx.Masseges.Add(mes);
                ctx.SaveChanges();
            }
        }

    }

    public class MyConcreteLoger : IAbstaractLoger
    {
        public ITxtLog CreateTxtLog()
        {
            return new MyTxtLog("Log into txt.file");
        }
        public IXmlLog CreateXmlLog()
        {
            return new MyXMLLog("Log into Xml");
        }
        public IDbLog CreateDbLog()
        {
            return new MyDBLog("Log into DB");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAbstaractLoger abLoger = new MyConcreteLoger();
            abLoger.CreateTxtLog().SaveLog();
            abLoger.CreateDbLog().SaveLog();
            abLoger.CreateXmlLog().SaveLog();

        }
    }
}