using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ra = new Random();
            ra.Next(1, 100);

            Random r = new Random();

            int size = 3;
            Unit[] group1 = new Unit[size];
            for (int i = 0; i < 3; i++)
            {
                switch (r.Next(0, 3))
                {
                    case 0:
                        group1[i] = new Archer(ra);
                        break;
                    case 1:
                        group1[i] = new Swordsman(ra);
                        break;
                    case 2:
                        group1[i] = new Mage(ra);
                        break;
                }
            }
            Console.WriteLine("group1");
            foreach (Unit el in group1)
            {
                Console.WriteLine(" {0} {1}", el.Name, el.Hp);
            }

            Console.WriteLine("\n");

            Unit[] group2 = new Unit[size];
            for (int i = 0; i < 3; i++)
            {
                switch (r.Next(0, 3))
                {
                    case 0:
                        group2[i] = new Archer(ra);
                        break;
                    case 1:
                        group2[i] = new Swordsman(ra);
                        break;
                    case 2:
                        group2[i] = new Mage(ra);
                        break;
                }
            }
            Console.WriteLine("group2");
            foreach (Unit el in group2)
            {
                Console.WriteLine(" {0} {1}", el.Name, el.Hp);
            }
            Console.WriteLine("\n");

            Console.WriteLine(" \n War \n ");

            
                for (int i = 0; i < size; i++)
                {
                    switch (r.Next(0, 2))
                    {
                        case 0:

                            if ((group1[i].Is_alive == true) && ((group2[i].Is_alive == true)))
                            {
                                Console.WriteLine("{0} gr1 vs {1} gr2", group1[i].Name, group2[i].Name);
                                group1[i].Attack(group2[i]);
                                group2[i].Print();
                                group2[i].Alive();
                                Console.WriteLine(" ");
                            }
                           
                            //if (group2[i].Is_alive == false)
                           // {
                           //     Console.WriteLine("this one is dead {0}", group2[i].Name);
						   
                          //  }
                            break;

                        case 1:
                            if ((group1[i].Is_alive == true) && ((group2[i].Is_alive == true)))
                            {
                                Console.WriteLine("{0} gr2 vs {1} gr1", group2[i].Name, group1[i].Name);
                                group2[i].Attack(group1[i]);
                                group1[i].Print();
                                group1[i].Alive();
                                Console.WriteLine(" ");
                            }
                            //if (group1[i].Alive() != true)
                            //{
                            //    Console.WriteLine("this one is dead {0}", group1[i].Name);
                            //}
                            break;
                    }
                }
        }
    }


    public abstract class Unit
    {
        protected String name;
        protected int hp;    // життя
        protected int dmg;   // урон
        protected int dodge; // ухилення
        protected Random r;
        protected bool is_alive;

        public Unit(Random r, int hp, int dmg, int dodge, String name) // constructor
        {
            this.r = r;
            this.name = name;
            this.hp = hp;
            this.dmg = dmg;
            this.dodge = dodge;
            this.is_alive = true;
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public bool Is_alive
        {
            get { return is_alive; }
            set { is_alive = value; }
        }

        public bool Alive()
        {
            if (hp <= 0)
            {
                this.is_alive = false;
                return false;
            }
            return true;
        }

        public int Protection()
        {
            int res = r.Next(1, 100);
            return res;
        }
        public void Attack(Unit a)
        {
            if (a.Protection() > a.dodge)
            {
                a.hp -= this.dmg;
                Console.WriteLine("{0} - HIT ", this.Name);
            }
            // else
            //     Console.WriteLine("{0} - AVOIDED ", a.Name);

        }
        public void Print()
        {
            Console.WriteLine("{0} hp {1}", this.Name, this.hp);
        }
    }

    public class Archer : Unit
    {
        public Archer(Random ra)
            : base(ra, 12, 4, 40, "Archer")
        { }
    }
    public class Mage : Unit
    {
        public Mage(Random ra)
            : base(ra, 8, 10, 30, "Mage")
        { }
    }
    public class Swordsman : Unit
    {
        public Swordsman(Random ra)
            : base(ra, 15, 10, 60, "Swordsman")
        { }
    }

}