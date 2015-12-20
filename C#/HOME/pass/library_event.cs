using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("How to be good person", "ddd");
            Book book2 = new Book("hello world: program antology", "ggg");
            Book book3 = new Book("....", "---");
            Client cl = new Client("New Client GoodOne", 2);
            cl.AddBookOnHeand(book1);
            cl.AddBookOnHeand(book2);
            cl.AddBookOnHeand(book3);
            // cl.ReturnBook(book2);

            Catalogue cat = new Catalogue();

            cat.PropertyChanged += cl.ifAddBook;
            cat.AddBook(book1);
            cat.AddBook(book2);

            cl.Print();
        }
    }

    public class Author
    {
        public String FullName { set; get; }
        public Author(String name)
        {
            FullName = name;
        }
    }

    public class Book : Author
    {
        public String Title { set; get; }
        public Book(String title, String FullName)
            : base(FullName)
        {
            Title = title;
        }
    }

    public class Client : LibraryCard    ////////    INotifyPropertyChanged
    {
        public String FullName { set; get; }
        public List<Book> arr_wantRead;
        public List<Book> Arr_wantRead
        {
            set
            {
                arr_wantRead = value;
            }
            get
            {
                return arr_wantRead;
            }
        }

        public Client(String name, int numb)
            : base(numb)
        {
            arr_wantRead = new List<Book>(0);
            FullName = name;
        }

        public void WantRead(Book book)
        {
            Arr_wantRead.Add(book);
        }

        public void Print()
        {
            Console.WriteLine("Full Name - {0} ", FullName);
            Console.WriteLine("CardNumber - {0} ", CardNumber);
            Console.WriteLine("books onHeand: ");
            int count = 0;
            for (int i = 0; i < onHeand.Length; i++)
            {
                count++;
                Console.WriteLine("    {0}. {1} ", count, onHeand[i].Title);
            }

            //  foreach(Book b in arr_wantRead)
            //{
            //  Console.WriteLine("    {0}. {1} ", b.Title);
            //}
        }

        public void ifAddBook(object sender, PropertyChangedEventArgs args)  //  метод що реагуватиме на подію
        {
            string name = args.PropertyName;
            for (int i = 0; i < (sender as Catalogue).Bookarr.Length; i++) //шукаємо книжку, якщо є - беремо
            {
                if ((sender as Catalogue).Bookarr[i].Title == "hello world: program antology")
                {
                    WantRead((sender as Catalogue).Bookarr[i]);
                }
            }

            Console.WriteLine("i want this book");

        }

    }// Client

    public class LibraryCard
    {
        public int CardNumber { set; get; }

        public Book[] onHeand;
        public Book[] OnHeand
        {
            get
            {
                return onHeand;
            }
        }

        public Book[] retBook;
        public Book[] RetBook
        {
            get
            {
                return retBook;
            }
        }

        public LibraryCard(int numb)
        {
            retBook = new Book[0];
            onHeand = new Book[0];
            CardNumber = numb;
        }


        public void AddBookOnHeand(Book book)
        {
            Array.Resize(ref onHeand, onHeand.Length + 1);
            onHeand[onHeand.Length - 1] = book;
        }

        public void ReturnBook(Book book)
        {
            // Array.Resize(ref retBook, retBook.Length + 1);

            Book[] tmp = new Book[this.onHeand.Length - 1];
            for (int i = 0, k = 0; i < tmp.Length; i++)
            {
                if (this.onHeand[i].Title != book.Title)
                {
                    tmp[i] = this.onHeand[k];
                    k++;
                    // retBook[retBook.Length - 1] = book;
                }
            }
            onHeand = tmp;
        }

        //public void Print()
        //{
        //    Console.WriteLine("CardNumber - {0} ", CardNumber);
        //    Console.WriteLine("books onHeand ");
        //    for (int i = 0; i < onHeand.Length;i++ )
        //    {
        //        Console.WriteLine(onHeand[i].Title);
        //    }
        //}

    }//LibraryCard 


    public class Catalogue : INotifyPropertyChanged      ////////    INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;   //   event

        private Book[] bookarr;
        public Book[] Bookarr
        {
            get { return bookarr; }
        }

        public Catalogue()
        {
            bookarr = new Book[0];
        }

        public void AddBook(Book book)
        {
            Array.Resize(ref bookarr, bookarr.Length + 1);
            bookarr[bookarr.Length - 1] = book;
            RisePropertyChanged("AddBook");
        }

        public void RisePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }//Catalogue
}