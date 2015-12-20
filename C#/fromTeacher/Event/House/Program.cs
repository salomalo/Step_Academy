using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public delegate void EventHandler(object sender, MoveEventArgs args);
    class Program
    {
        static void Main(string[] args)
        {
            MoveDetector md = new MoveDetector();
            House house = new House(md);
            Police police = new Police();
            house.IsAnyBodyHome = false;
            house.Move += police.SendTeam;
            house.Move += delegate(object sender, MoveEventArgs arg)
            {
                if (sender is House)
                {
                    bool isAny = (sender as House).IsAnyBodyHome;
                    if (isAny)
                    {
                        Console.WriteLine("I am thief. It will be better to run away!");
                    }
                    else
                    {
                        Console.WriteLine("I am thief.I have some minutes before team comes!");
                    }
                }
            };

            house.Move += (sender, arg) =>
            {               
               Console.WriteLine("I am host. I see you!!!");                
            };
            bool isAnyBodyOutside = false;
            house.OnMove(isAnyBodyOutside, 1);
         //   house.Move += md.PerfomMove;

        }
    }

    class House
    {
        public event EventHandler Move;

        public bool IsAnyBodyHome { set; get; }
        public MoveDetector Detector { set; get; }

        public House(MoveDetector detector)
        {
            Detector = detector;
            IsAnyBodyHome = true;
            Move += Detector.PerfomMove;
        }

        public void OnMove(bool isOutside, int count)
        {
            Console.WriteLine("Move");
            if (Move != null)
            {//виклик методів підписаних на подію
                Move(this, new MoveEventArgs(isOutside, count));  //додаткові параметри для методів - обробників подій
            }
        }
    }

    class MoveDetector
    {
        public void PerfomMove(object sender, EventArgs args)
        {
            if (sender is House )              
            {
                bool isAny = (sender as House).IsAnyBodyHome;
                if (isAny)
                {
                    Console.WriteLine("Any wishes, my master?");
                }
                else
                {
                    Console.WriteLine("Help me!!! SOS!!!");
                }
            }
           
        }
    }

    class Police
    {
        public void SendTeam(object sender, MoveEventArgs args)
        {
            if (sender is House && !(sender as House).IsAnyBodyHome && !args.IsAnyBodyOutside)
            {
                Console.WriteLine("The team is sent!");
            }
        }
    }

   public class MoveEventArgs : EventArgs
    {
        public bool IsAnyBodyOutside { set; get; }
        public int HowMany { set; get; }
        public MoveEventArgs(bool isOutside, int i)
        {
            IsAnyBodyOutside = isOutside;
            HowMany = i;
        }
    }
}
