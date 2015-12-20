using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.ComponentModel;

// Є біржа, на якій відбуваються зміни цін на акції,
// зявляються або закінчуються акції (події). 
// На цій біржі можуть реєструватись учасники торгів - банки, приватні особи, а в подальшому можливо ще хтось.
// Учасники як можуть реєструватись ( зберігати в колекції) так і відключатись від інформування.
// Учасники залежно від того росте ціна чи падає відповідно купують/продають, 
// алгоритм можете придумати самостійно, але кожен гравець може купувати лише в межах свого бюджету.
// На біржі в свою чергу кількість тих чи інших акцій обмежена і, хоча ціна на них може змінюватись, акцій може не бути в наявності.

namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Share sh1 = new Share("first", 16, 10);
            Share sh2 = new Share("second", 12.2, 4);
            Exchange ex = new Exchange();
            ex.AddShare(sh1);
            ex.AddShare(sh2);

            ex.Print();


            Player pl1 = new Player("New player");
         //   pl1.WasSubscribed += ex.Subscriptions;

            pl1.ToSubscribe(ex);
            //pl1.UnSubscribe(ex);

            // ex.RisePrice();
            // 
            ex.DecRisePrice();
            ex.Print();


            Console.WriteLine("pl");
            pl1.Print();

            // 
            // ex.Print();



        } // Main
    } // Program


    public class Share
    {
        protected String _title;
        protected double _price;
        protected int _count;

        public String Title
        {
            set
            {
                _title = value;
            }
            get
            {
                return _title;
            }
        }
        public double Price
        {
            set
            {
                _price = value;
            }
            get
            {
                return _price;
            }
        }
        public int Count
        {
            set
            {
                _count = value;
            }
            get
            {
                return _count;
            }
        }

        public Share(String title, double price, int count)
        {
            Title = title;
            Price = price;
            Count = count;
        }

        public void Print()
        {
            Console.WriteLine("Title: {0} Count: {1} Price: {2}", Title, Count, Price);
        }
    } // Share


    public class Player : ISubscribuble
    {
        public event PropertyChangedEventHandler WasSubscribed;   //   подія підписка

        protected List<Share> _plShare;
        public List<Share> PlShare
        {
            set
            {
                _plShare = value;
            }
            get
            {
                return _plShare;
            }
        }

        protected double _money;
        public double Money
        {
            set
            {
                _money = value;
            }
            get
            {
                return _money;
            }
        }

        protected String _fullName;
        public String FullName
        {
            set
            {
                _fullName = value;
            }
            get
            {
                return _fullName;
            }
        }

        public Player(String fullName)
        {
            PlShare = new List<Share>(0);
            FullName = fullName;
        }


        public void Buy(Share sh)
        {
            PlShare.Add(sh);
            Money -= sh.Price;
        }

        public void Sell(Share sh)
        {
            PlShare.Remove(sh);
            Money += sh.Price;
        }

        public void ToSubscribe(Exchange ex) // метод що генерує подію  підписує
        {
            ex.SubscribEx(this);
            RisePropertyChanged("Subscribe");
            ex.RisePrise += OnPriseRise;
            ex.DecrisePrise += OnPriseDecrise;
        }

        public void OnPriseRise(object sender, EventArgs args) // реагую на подію біржі підняття ціни 
        {
           
            Console.WriteLine("OnPriseRise");
            for (int i = 0; i < (sender as Exchange).ShList.Count; i++)
            {
                foreach (Share s in (sender as Exchange).ShList)
                {
                    if (s.Price >= 20)
                    {
                        Sell(s);
                      //  (sender as Exchange).RemShare(s);
                    }
                }
            }
        }

        public void OnPriseDecrise(object sender, EventArgs args) // реагую на подію біржі опускання ціни 
        {

            Console.WriteLine("OnPriseDecrise");
            for (int i = 0; i < (sender as Exchange).ShList.Count; i++)
            {
                foreach (Share s in (sender as Exchange).ShList)
                {
                    if (s.Price <= 15)
                    {
                        Buy(s);
                     //   (sender as Exchange).AddShare(s);
                    }
                }
            }
        }

        public void UnSubscribe(Exchange ex) // метод що генерує подію відписує
        {
            ex.UnSubscribEx(this);
            RisePropertyChanged("UnSubscribe");
          //  DirectoryInfo dir = new DirectoryInfo("D:\\");
         //   string pat = "fdg";
          //  dir.GetFiles(pat, SearchOption.AllDirectories)
        }

        public void RisePropertyChanged(String propertyName) // перевіряю чи була подія
        {
            if (WasSubscribed != null)
            {
                WasSubscribed(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Print()
        {
            foreach (Share s in PlShare)
            {
                s.Print();
            }
        }
    
    } // Player

    public class Exchange
    {
        public event EventHandler RisePrise;   //   event
        public event EventHandler DecrisePrise;   //   event

        public event PropertyChangedEventHandler OutStock;   //   event
        public event PropertyChangedEventHandler InStock;  //   event


        protected List<Share> _shList;
        public List<Share> ShList
        {
            set
            {
                _shList = value;
            }
            get
            {
                return _shList;
            }
        }

        protected List<Player> _pl;
        public List<Player> Pl
        {
            set
            {
                _pl = value;
            }
            get
            {
                return _pl;
            }
        }

        public Exchange()
        {
            _shList = new List<Share>(0);
            _pl = new List<Player>(0);
        }

        public void SubscribEx(Player pl)
        {
            Pl.Add(pl);
        }

        public void UnSubscribEx(Player pl)
        {
            Pl.Remove(pl);
        }

        public void RisePrice()
        {
            foreach (Share s in ShList)
            {
                s.Price += 1;
            }
        }


        public void DecRisePrice()
        {
            foreach (Share s in ShList)
            {
                s.Price -= 1;
            }

            ////////// ///////// ////////// ////////// ////////// ////////// 
            OnEventDecrisePrise();
        }

        ////////// ////////// ////////// ////////// ////////// ////////// 
        public void OnEventDecrisePrise()
        {
            if (DecrisePrise != null)
            {
                DecrisePrise(this, EventArgs.Empty);
            }
        }



        public void RemShare(Share sh)
        {
            ShList.Remove(sh);
        }

        public void AddShare(Share sh)
        {
            ShList.Add(sh);

            // для нової акції 
        }

        public void Print()
        {
            foreach (Share s in this._shList)
            {
                s.Print();
            }
        }

        public void Subscriptions(object sender, PropertyChangedEventArgs args) // метод який реагує на подію підписки.відписки плеєра
        {
            if (args.PropertyName == "Subscribe")
            {
                Console.WriteLine("You was subscribed on event of our Exchange");
            }
            if (args.PropertyName == "UnSubscribe")
            {
                Console.WriteLine("You was unsubscribed on event of our Exchange");
            }
        }

    } //Exchange

    interface ISubscribuble
    {
        void ToSubscribe(Exchange ex);
        void UnSubscribe(Exchange ex);
    }
}