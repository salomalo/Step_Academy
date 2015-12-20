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


            //while (true)
            //{
            for (int i = 0; i < 3; i++)
            {
                switch (r.Next(0, 2))
                {
                    case 0:
                        for (i = 0; i < group2.Length; i++)
                        {
                            if ((group1[i].With_enemy == false) && (group2[i].With_enemy == false))
                            {
                                if (group1[i].Name == group2[i].Name)
                                {
                                    Console.WriteLine("{0} gr1 vs {1} gr2", group1[i].Name, group2[i].Name);
                                    group1[i].Attack(group2[i]);
                                    group2[i].Print();
                                    group2[i].Alive();
                                    Console.WriteLine(" ");
                                    group1[i].With_enemy = true;
                                    group2[i].With_enemy = true;
                                }
                                else
                                {
                                    Console.WriteLine("{0} gr1 vs {1} gr2", group1[i].Name, group2[i].Name);
                                    group1[i].Attack(group2[i]);
                                    group2[i].Print();
                                    group2[i].Alive();
                                    Console.WriteLine(" ");
                                    group1[i].With_enemy = true;
                                }
                            }

                            if (group2[i].Is_alive == false)
                            {
                                Console.WriteLine("dead - {0}", group2[i].Name);

                                Unit[] tmp = new Unit[group2.Length - 1];
                                for (int j = 0, k = 0; j < tmp.Length; j++)
                                {
                                    if (group2[j].Is_alive == true)
                                    {
                                        tmp[j] = group2[k];
                                        k++;
                                    }
                                }
                                group2 = tmp;
                            } // (group2[i].Is_alive == false)
                        }
                        break;

                    case 1:
                        for (i = 0; i < group1.Length; i++)
                        {
                            if ((group2[i].With_enemy == false) && (group1[i].With_enemy == false))
                            {
                                if (group2[i].Name == group1[i].Name)
                                {
                                    Console.WriteLine("{0} gr2 vs {1} gr1", group2[i].Name, group1[i].Name);
                                    group2[i].Attack(group1[i]);
                                    group1[i].Print();
                                    group1[i].Alive();
                                    Console.WriteLine(" ");
                                    group2[i].With_enemy = true;
                                    group1[i].With_enemy = true;
                                }
                                else
                                {
                                    Console.WriteLine("{0} gr2 vs {1} gr1", group2[i].Name, group1[i].Name);
                                    group2[i].Attack(group1[i]);
                                    group1[i].Print();
                                    group1[i].Alive();
                                    Console.WriteLine(" ");
                                    group2[i].With_enemy = true;
                                }
                            }
                            if (group1[i].Is_alive == false)
                            {
                                Console.WriteLine("dead - {0}", group1[i].Name);

                                Unit[] tmp = new Unit[group1.Length - 1];
                                for (int j = 0, k = 0; j < tmp.Length; j++)
                                {
                                    if (group1[j].Is_alive == true)
                                    {
                                        tmp[j] = group2[k];
                                        k++;
                                    }
                                }
                                group1 = tmp;
                            }
                        }
                        break;

                }//switch

            }//for

            // }//while


            Console.WriteLine("group1");
            foreach (Unit el in group1)
            {
                Console.WriteLine(" {0} {1}", el.Name, el.Hp);
            }
            Console.WriteLine("\n");


            Console.WriteLine("group2");
            foreach (Unit el in group2)
            {
                Console.WriteLine(" {0} {1}", el.Name, el.Hp);
            }
            Console.WriteLine("\n");





        }//main

    }//program


    public abstract class Unit
    {
        protected String name;
        protected int hp;    // життя
        protected int dmg;   // урон
        protected int dodge; // ухилення
        protected Random r;
        protected bool is_alive;
        protected bool with_enemy;
        public Unit(Random r, int hp, int dmg, int dodge, String name) // constructor
        {
            this.r = r;
            this.name = name;
            this.hp = hp;
            this.dmg = dmg;
            this.dodge = dodge;
            this.is_alive = true;
            this.with_enemy = false;
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

        public bool With_enemy
        {
            get { return with_enemy; }
            set { with_enemy = value; }
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