//http://www.codeproject.com/Articles/571139/Foreach-On-IEnumerable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime data = new DateTime(2014, 12, 10);
            DateTime data2 = new DateTime(2014, 12, 11);

            Article articl = new Article(20, "Artemon", 9.9, ArticleType.cookies);
            Article articl2 = new Article(21, "M&M", 12, ArticleType.sweet);

            RequestItem item = new RequestItem(articl, 1);
            RequestItem item2 = new RequestItem(articl2, 2);

            Request allItems = new Request(100, data, PayType.Cash);
            allItems.AddItems(item);
            allItems.AddItems(item2);
            allItems.PrintInfo();

            Console.WriteLine();
            foreach (var el in allItems)
            {
                ((RequestItem)el).Print();
            }

            Article articl3 = new Article(22, "Neskweek", 5.6, ArticleType.tea);
            RequestItem item3 = new RequestItem(articl3, 2);
            Request allItems2 = new Request(101, data2, PayType.CreditCard);
            allItems2.AddItems(item3);


            Client client1 = new Client("Tesa Testova", 3333, 097544678, ClientType.Ordinary);
            client1.AddRequest(allItems);
            client1.AddRequest(allItems2);

            client1.PrintInfo();

        }
    }

    public struct Article
    {
        public int Code;
        public String Title;
        public double Price;
        public ArticleType typ;
        public Article(int code, String title, double price, ArticleType type)
        {
            Code = code;
            Title = title;
            Price = price;
            typ = type;
        }
        public void Print()
        {
            Console.WriteLine(" Info about Article\n Article code: {0}\n Title: {1}\n Price: {2}\n type: {3}\n", Code, Title, Price, typ);
        }
    }
    public struct RequestItem
    {
        public Article article;
        public int quantity;
        public RequestItem(Article art, int quant)
        {
            article = art;
            quantity = quant;
        }
        public void Print()
        {
            Console.WriteLine(" Info about RequestItem \n article: {0}\n quantity: {1}\n", article.Title, quantity);
        }
    }
    public class Request : Printable, IEnumerable
    {
        protected int code;
        protected DateTime date;
        protected RequestItem[] items;
        protected PayType pay;
        protected double summa;
        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        public double Summa
        {
            get { return summa; }
            set { summa = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public PayType Pay
        {
            get { return pay; }
            set { pay = value; }
        }
        public Request(int code, DateTime date, PayType pay)
        {
            items = new RequestItem[0];
            this.code = code;
            this.date = date;
            this.pay = pay;
            this.summa = 0;
        }
        public void AddItems(RequestItem item)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
            Summa += (item.article.Price * item.quantity);
        }
        public void PrintInfo()
        {
            Console.WriteLine(" Info about whole Request\n Request code: {0}\n Date: {1}\n Pay Type: {2}\n Summa: {3}\n", Code, Date, Pay, Summa);
        }
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }

    public struct Client
    {
        public String FullName;
        public int Code;
        public int Phone;
        public int CountOrder;
        public double SummaOrder;
        public ClientType Type;

        public int C_CountOrder
        {
            get { return CountOrder; }
            set { CountOrder = value; }
        }

        public void AddRequest(Request a)
        {
            CountOrder++;
            SummaOrder += a.Summa;
        }

        public Client(String fullName, int code, int phone, ClientType type)
        {
            FullName = fullName;
            Code = code;
            Phone = phone;
            CountOrder = 0;
            SummaOrder = 0;
            Type = type;
        }

        public void PrintInfo()
        {
            Console.WriteLine(" Info about Client \n Code: {0}\n fullName: {1}\n Phone: {2}\n CountOrder: {3}\n SummaOrder: {4} \n ClientType {5}", Code, FullName, Phone, CountOrder, SummaOrder, Type);
        }

    }
    public enum ClientType
    {
        VeryImportant, Important, Ordinary, Unimportant
    }
    public enum ArticleType
    {
        chocolate, cookies, pancake, tea, sweet
    }
    public enum PayType
    {
        Cash, Cashless, CreditCard
    }
    interface Printable
    {
        void PrintInfo();
    }

}