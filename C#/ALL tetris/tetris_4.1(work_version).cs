using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace tetris_points
{
    class Program
    {
        static void Main(string[] args)
        {
            Game gm = new Game();
            gm.StartGame();
            //gm.EndGame();
            // gm.PrintPlayers();

            while (true)
            {
                Thread.Sleep(250);
                Console.Clear();

                //  Console.WriteLine("point X: {0} ; Y: {1}", _glas.CurFigure.X, _glas.CurFigure.Y); //виводжу координати стартової точки
                //  Console.WriteLine("arr   X: {0} ; Y: {1}", _glas.CurFigure.X, _glas.CurFigure.Y + 1);

                //foreach (Point p in _glas.CurFigure.Arr)
                //     p.Print(); //виводжу координати кожної точки


                gm.Glas.Paint();

                //if (gm.Glas.Paint() == false) // переношу фігурку в стакан
                //{
                //    gm.Glas.NewFigure();
                //}

                gm.Glas.Print(); // малюю стакан із падаючими фігурками !!!!!!!
                gm.Glas.Fall(); // змінюю координати фігурки для  реалізації падіння


                if (Console.KeyAvailable == true) // якщо є нажаття клавіші то зайти у функцію і перемістити фігурку в ліво чи право
                {
                    gm.KeyPress();
                }


                // перевірка на зіткнення з низом чи іншими фігурами
                if (gm.Glas.IsBottom() == true) // якщо низ стакана то почати малювати нову фігурку зверху
                {
                    gm.Glas.NewFigure();
                }


                gm.Glas.NewGlass(); // ініціалізую стакан новими значеннями


                Console.WriteLine("is - -- below {0}", gm.Glas.IsFigureBelow());

                //_glas.Print_BUFFER();

            } // while




        } // main

    } // Program

    public class Point // точка екрану з координатами Х У
    {
        protected int _x;
        public int X
        {
            set
            {
                _x = value;
            }
            get
            {
                return _x;
            }
        }

        protected int _y;
        public int Y
        {
            set
            {
                _y = value;
            }
            get
            {
                return _y;
            }
        }

        public Point(int x, int y) // конструктор
        {
            X = x;
            Y = y;
        }

        public void Print()
        {
            Console.WriteLine("X: {0} ; Y: {1}", X, Y);
        }

    } // Point




    public class line : Point  // фігурка 
    {
        protected char _check;
        public char Check
        {
            set
            {
                _check = value;
            }
            get
            {
                return _check;
            }
        }

        protected ArrayList _arr;
        public ArrayList Arr
        {
            set
            {
                _arr = value;
            }
            get
            {
                return _arr;
            }
        }
        public line(int x, int y)
            : base(x, y)  // конструктор
        {
            Check='v';
            Arr = new ArrayList();
            X = x;
            Y = y;
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X, Y + 1);
            Point tmp3 = new Point(X, Y + 2);
            Point tmp4 = new Point(X, Y + 3);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
        }
        public void NewPos(int x, int y) // присвоюю нові координати точкам фігури
        {
            Arr.Clear();
            X = x;
            Y = y;
            // вертикальна лінія
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X, Y + 1);
            Point tmp3 = new Point(X, Y + 2);
            Point tmp4 = new Point(X, Y + 3);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
        }

        public void Rotate(int x, int y) // присвоюю нові координати точкам фігури
        {
            X = x;
            Y = y;

            Arr.Clear();
            if (Check == 'v')
            {
                // горизонтальна лінія
                Point tmp1 = new Point(X, Y);
                Point tmp2 = new Point(X - 1, Y + 1);
                Point tmp3 = new Point(X + 1, Y + 1);
                Point tmp4 = new Point(X + 2, Y + 1);

                Arr.Add(tmp1);
                Arr.Add(tmp2);
                Arr.Add(tmp3);
                Arr.Add(tmp4);
                Check = 'g';
            }
            else 
            {
                // вертикальна лінія
                Point tmp1 = new Point(X, Y);
                Point tmp2 = new Point(X, Y + 1);
                Point tmp3 = new Point(X, Y + 2);
                Point tmp4 = new Point(X, Y + 3);

                Arr.Add(tmp1);
                Arr.Add(tmp2);
                Arr.Add(tmp3);
                Arr.Add(tmp4);
                Check = 'v';
            }
        }


    } // line


    public class RightZ : Point  // фігурка 
    {
        protected char _check;
        public char Check
        {
            set
            {
                _check = value;
            }
            get
            {
                return _check;
            }
        }

        protected ArrayList _arr;
        public ArrayList Arr
        {
            set
            {
                _arr = value;
            }
            get
            {
                return _arr;
            }
        }
        public RightZ(int x, int y)
            : base(x, y)  // конструктор
        {
            Check = 'g';
            Arr = new ArrayList();
            X = x;
            Y = y;
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X + 1, Y);
            Point tmp3 = new Point(X + 1, Y + 1);
            Point tmp4 = new Point(X + 2, Y + 1);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
        }
        public void NewPos(int x, int y) // присвоюю нові координати точкам фігури
        {
            Arr.Clear();
            X = x;
            Y = y;

            //Point tmp1 = new Point(X, Y);
            //Point tmp2 = new Point(X + 1, Y);
            //Point tmp3 = new Point(X + 1, Y + 1);
            //Point tmp4 = new Point(X + 2, Y + 1);

            //Arr.Add(tmp1);
            //Arr.Add(tmp2);
            //Arr.Add(tmp3);
            //Arr.Add(tmp4);

            G_View(X, Y);
        }

        public void V_View(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X - 1, Y + 1);
            Point tmp3 = new Point(X, Y + 1);
            Point tmp4 = new Point(X - 1, Y + 2);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = 'v';
        }

        public void G_View(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X + 1, Y);
            Point tmp3 = new Point(X + 1, Y + 1);
            Point tmp4 = new Point(X + 2, Y + 1);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = 'g';
        }

        public void Rotate(int x, int y)
        {
            X = x;
            Y = y;
           
            if (Check == 'g')
            {
                //Arr.Clear();
                //Point tmp1 = new Point(X, Y);
                //Point tmp2 = new Point(X - 1, Y+1);
                //Point tmp3 = new Point(X, Y + 1);
                //Point tmp4 = new Point(X -1, Y+2);

                //Arr.Add(tmp1);
                //Arr.Add(tmp2);
                //Arr.Add(tmp3);
                //Arr.Add(tmp4);
                //Check = 'v';

                V_View(X, Y);
            }
            else 
            {
                //Arr.Clear();
                //Point tmp1 = new Point(X, Y);
                //Point tmp2 = new Point(X + 1, Y);
                //Point tmp3 = new Point(X + 1, Y + 1);
                //Point tmp4 = new Point(X + 2, Y + 1);

                //Arr.Add(tmp1);
                //Arr.Add(tmp2);
                //Arr.Add(tmp3);
                //Arr.Add(tmp4);
                //Check = 'g';

                G_View(X, Y);

            }
        
        }


    } // RightZ
    public class Dot : Point // фігурка точка 
    {
        protected ArrayList _arr;
        public ArrayList Arr
        {
            set
            {
                _arr = value;
            }
            get
            {
                return _arr;
            }
        }
        public Dot(int x, int y)
            : base(x, y)  // 
        {
            Arr = new ArrayList();
            X = x;
            Y = y;
            Point tmp1 = new Point(X, Y);
            Arr.Add(tmp1);
        }
        public void NewPos(int x, int y)
        {
            Arr.Clear();
            X = x;
            Y = y;
            Point tmp1 = new Point(X, Y);
            Arr.Add(tmp1);
        }

    } // Dot 

    public class Glass // стакан 
    {
        protected int _score; // масив стакана
        public int Score
        {
            set
            {
                _score = value;
            }
            get
            {
                return _score;
            }
        }

        protected bool[,] _arr; // масив стакана
        public bool[,] Arr
        {
            set
            {
                _arr = value;
            }
            get
            {
                return _arr;
            }
        }

        protected bool[,] _buffer; // масив стакана
        public bool[,] Buffer
        {
            set
            {
                _buffer = value;
            }
            get
            {
                return _buffer;
            }
        }

        protected RightZ _curFigure; // поточна фігура (яка падає в даний момент)
        public RightZ CurFigure
        {
            set
            {
                _curFigure = value;
            }
            get
            {
                return _curFigure;
            }
        } // 

        protected int _curY; // значення основної координати У фігури (від якої перевизначатимуться координати всіх інших точок в фігурі)
        public int CurY
        {
            set
            {
                _curY = value;
            }
            get
            {
                return _curY;
            }
        }

        protected int _curX; // значення основної координати Х фігури (від якої перевизначатимуться координати всіх інших точок в фігурі)
        public int CurX
        {
            set
            {
                _curX = value;
            }
            get
            {
                return _curX;
            }
        }

        public Glass() // constructor 
        {
            Score = 0;
            CurY = 0;
            CurX = 9;
            CurFigure = new RightZ(CurX, CurY);
            Arr = new bool[20, 20];
            Buffer = new bool[20, 20];

            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(0); j++)
                {
                    Arr[i, j] = false; // ініціалізую стакан 
                    Buffer[i, j] = false;
                }
            }

        } // Glass

        ///////////////////////////////           дописати          //////////////////////////////////////////////////////////////////////
        // метод має зберігати стакан із фігурками які впали на дно і робити його поточним
        public void NewGlass() // переініціалізовую стакан новими занченнями 
        {
            Copy(Buffer, Arr); // ініціалізую свій стакан даними із буфера   Arr = Buffer 
        } // NewGlass

        public void Copy(bool[,] source, bool[,] destenation) // переініціалізовую стакан новими занченнями 
        {
            for (int i = 0; i < destenation.GetLength(0); i++)
            {
                for (int j = 0; j < destenation.GetLength(1); j++)
                {
                    destenation[i, j] = source[i, j];
                }
            }
        } // Copy

        public void NewFigure() // генерація нової фігурки на весрі стакану
        {
            CurY = 0;
            CurX = 9;
            CurFigure = new RightZ(CurX, CurY);
        }

        ///////////////////////////////////// дописати переміщення по Х 
        public void Fall() // змінюю координату У фігурки для  реалізації падіння
        {
            CurY += 1;
            CurFigure.NewPos(CurX, CurY);
        } // Fall
        public void Move(int x) // змінюю координатУ Х фігурки для  реалізації пересування в боки 
        {
            CurX += x;

            if (CurX <= 0)
                CurX = 0;

            if (CurX >= 19)
                CurX = 19;

            CurFigure.NewPos(CurX, CurY);
        } // Move

        public void Paint() // переношу фігурку в стакан
        {

            //foreach (Point p in CurFigure.Arr)
            //{
            //    if (Arr[p.Y, p.X] == true)
            //    {
            //        return false;
            //    }
            //}

            foreach (Point p in CurFigure.Arr)
            {
                Arr[p.Y, p.X] = true;
                //     return true;
            }


            //return true;


            //foreach (Point p in CurFigure.Arr)
            //    Arr[p.Y, p.X] = true;


        } // Paint



        ////////////// для великих фігур переписати

        public bool IsBottom() // перевірка на дно 
        {
            if (CurFigure.Y == Arr.GetLength(0))
            {

                Copy(Arr, Buffer); // копіюю з arr в buffer
                





                
                return true;
            }
            else
            {
                return false;
            }
        } // IsBottom

        public bool IsFigureBelow() // перевірка на фігурку під фігуркою
        {
            if (CurFigure.Y + 1 != Arr.GetLength(0) && Arr[CurFigure.X, CurFigure.Y + 1] == true)
            {
                Console.WriteLine("IsFigureBelow {0} ", CurFigure.Y + 1);
                Copy(Arr, Buffer); // копіюю з arr в buffer
                return true;
            }
            else
            {
                return false;
            }
        } // IsFigureBelow


        public int CheckLine() // перевірка чи є складена лінія 
        {

            int res = 0; // index of line with all true
            int num = 0;
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(0); j++)
                {
                    if (Arr[i, j] == true)
                    {
                        num++;
                    }
                }
                if (num == Arr.GetLength(0))
                {
                    res = i;
                }
                num = 0;
            }
            Console.WriteLine("res {0}", res);
            return res;
        }

        public void Shake(int num)
        {
            int i = num;
            for (int j = 0; j < Arr.GetLength(1); j++) // x col
            {
                Arr[i, j] = false;
                Score++;
            }

            for (i = num - 1; i >= 0; i--)
            {
                for (int j = 0; j < Arr.GetLength(0); j++) // x col
                {
                    if (Arr[i, j] == true)
                    {
                        if (Arr[i + 1, j] == false)
                        {
                            Arr[i, j] = false;
                            Arr[i + 1, j] = true;
                        }

                    }
                }
            }


            for (i = num; i >= 0; i--)
            {
                for (int j = 0; j < Arr.GetLength(0); j++) // x col
                {
                    if (Arr[i, j] == true)
                    {
                        if (Arr[i + 1, j] == false)
                        {
                            Arr[i, j] = false;
                            Arr[i + 1, j] = true;
                        }
                    }
                }
            }

            // Print(Arr);
            CheckLine();
        }

        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary>

        public void Print() // малюю стакан із фігурками !!!!!!!
        {
            for (int i = 0; i < Arr.GetLength(0); i++) // y row
            {
                for (int j = 0; j < Arr.GetLength(1); j++) // x col
                {
                    if (Arr[i, j] == false)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine(" {0}", i);
            }
            Console.WriteLine();
        } //Print

        public void Print_BUFFER() // малюю стакан із фігурками !!!!!!!
        {
            for (int i = 0; i < Buffer.GetLength(0); i++) // y row
            {
                for (int j = 0; j < Buffer.GetLength(1); j++) // x col
                {
                    if (Buffer[i, j] == false)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine(" {0}", i);
            }
            Console.WriteLine();
        } //Print

    } // Glass




    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public class Player
    {
        protected String _name;
        public String Name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }

        protected int _points;
        public int Points
        {
            set
            {
                _points = value;
            }
            get
            {
                return _points;
            }
        }

        public Player(String name, int points)
        {
            Name = name;
            Points = points;
        }
    } // Player

    public class Game
    {
        protected Glass _glas;
        public Glass Glas
        {
            set
            {
                _glas = value;
            }
            get
            {
                return _glas;
            }
        }

        protected List<Player> _players;
        public List<Player> Players
        {
            set
            {
                _players = value;
            }
            get
            {
                return _players;
            }
        }

        protected Player _curPlayer;
        public Player CurPlayer
        {
            set
            {
                _curPlayer = value;
            }
            get
            {
                return _curPlayer;
            }
        }

        protected bool _isGame;
        public bool IsGame
        {
            set
            {
                _isGame = value;
            }
            get
            {
                return _isGame;
            }
        }

        public Game()
        {
            Glas = new Glass();
            IsGame = false;
            Players = new List<Player>();
            CurPlayer = new Player("_name", 0);
        }

        public void KeyPress()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        if (IsGame == true)
                        {
                            Glas.Move(-1);
                        }
                        else
                        {
                            Console.WriteLine("game is not start yet");
                        }
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        Glas.Move(1);
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        Glas.CurFigure.Rotate(Glas.CurX,Glas.CurY);
                        break;
                    }
            }
        }

        public void StartGame()
        {
            //LoadPlayers_fromFile();
            //Console.WriteLine("name: ");
            //String name = Console.ReadLine();
            //CurPlayer = new Player(name, 0);
            IsGame = true;
        }

        public void EndGame() // якщо гра завершилася
        {
            CurPlayer.Points = Glas.Score;
            AddPlayer(CurPlayer); // додаю поточного юзера в список всіх юзерів що грали в гру
            Sort();
            SavePlayers_inFile(); // зберігаю список всіх юзерів у файл
        }

        public void Sort() // для виводу списку гравців в порядку найбільших балів
        {
            Players.Sort((b, a) => a.Points.CompareTo(b.Points));
        }



        public void AddPlayer(Player p)
        {
            Players.Add(p);
        }
        public void SavePlayers_inFile() // зберігаю всіх плеєрів у файл
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter("player.xml", Encoding.UTF8);
                writer.Formatting = Formatting.Indented; //для читабельного формату 
                writer.WriteStartDocument();
                writer.WriteStartElement("catalog");
                foreach (Player pl in Players)
                {
                    Write_player_in_file(pl, writer);
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            catch (XmlException xe)
            {
                Console.WriteLine(xe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        } // SavePlayers_inFile
        public void Write_player_in_file(Player pl, XmlTextWriter writer) // записую конкретного гравця в файл
        {
            writer.WriteStartElement("player");
            writer.WriteElementString("NAME", pl.Name);
            writer.WriteElementString("POINTS", pl.Points.ToString());
            writer.WriteEndElement();
        }
        public void LoadPlayers_fromFile() // read all players from from file
        {
            try
            {
                List<Player> catalogNEW = new List<Player>();
                XmlDocument doc = new XmlDocument();
                doc.Load("player.xml");
                XmlNodeList list = doc.GetElementsByTagName("player");
                foreach (XmlNode node in list)
                {
                    String n = node["NAME"].InnerText;
                    int pi;
                    String ps = node["POINTS"].InnerText;
                    Int32.TryParse(ps, out pi);
                    catalogNEW.Add(new Player(n, pi)); // add players from file in new list
                }
                Players = catalogNEW; // transport all players which was read from file to may player list
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        } // LoadPlayers_fromFile
        public void PrintPlayers()
        {
            foreach (Player pl in Players)
            {
                Console.WriteLine("{0} - {1} ", pl.Name, pl.Points);
            }
        } // PrintPlayers

    } // Game


}
