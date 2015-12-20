using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;

namespace tetris
{

    public class Game
    {
        public Random R { set; get; }

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
            R = new Random(1);
            Glas = new Glass();
            IsGame = false;
            Players = new List<Player>();
            CurPlayer = new Player("_name", 0);
            Glas.IsGameOver += EndGame;
        } // Game

        public void Menu()
        {
            //Menu_lists;
            int MaxNo_Menu = 3;
            String[] menu_list = { "START", "SCORES", "EXIT" };
            int i;
            int xpos = 10;
            int[] ypos = { 3, 6, 9, 12 };

            if (IsGame == false)
            {
                for (i = 0; i < MaxNo_Menu; ++i)// list the menu
                {
                    Console.SetCursorPosition(xpos, ypos[i]);
                    Console.Write(" {0}", menu_list[i]);
                }
                Console.WriteLine(" ");
            }
            i = 0;// make menu available to choose
            while (true)
            {
                if (IsGame == false)
                {
                    Console.SetCursorPosition(xpos, ypos[i]);
                    Console.Write(" {0}", menu_list[i]);
                }
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (Glas.IsLeft() == false)
                                if (Glas.IsFigureLeft() == false)
                                    Glas.Move(-1);
                                else
                                    Glas.Move(0);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (Glas.IsRight() == false)// || Glas.IsFigureRight() == false)
                                if (Glas.IsFigureRight() == false)
                                    Glas.Move(1);
                                else
                                    Glas.Move(0);
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        if (IsGame == false && i > 0)
                        {
                            Console.SetCursorPosition(xpos, ypos[i]);

                            Console.Write(" {0}", menu_list[i]);
                            --i;
                        }
                        else if (IsGame == true)
                        {
                            Glas.CurFigure.Rotate(Glas.CurX, Glas.CurY);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (IsGame == false && i < MaxNo_Menu - 1)
                        {
                            Console.SetCursorPosition(xpos, ypos[i]);

                            Console.Write(" {0}", menu_list[i]);
                            ++i;
                        }
                        else if (IsGame == true)
                        {
                            Glas.Timer.Interval = 100;
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (i == 0)
                        {
                            Console.SetCursorPosition(10, 1);
                            StartGame();
                            Console.Clear();
                        }
                        if (i == 1)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(10, 1);
                            PrintPlayers();

                        }
                        if (i == 2)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(10, 1);
                            Console.Write("you choose EXIT ");
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        Console.Clear();
                        Menu();
                        break;
                }
            }
        } // Menu

        public void StartGame()
        {
            Console.Clear();
            LoadPlayers_fromFile();
            Console.WriteLine("name: ");
            String name = Console.ReadLine();
            CurPlayer = new Player(name, 0);
            IsGame = true;
            Glas.Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        } // StartGame

        public void EndGame(object sender, EventArgs args) // якщо гра завершилася
        {
            // Console.WriteLine("GAME OVER");
            IsGame = false;
            Glas.Timer.Stop();
            CurPlayer.Points = Glas.Score;
            AddPlayer(CurPlayer); // додаю поточного юзера в список всіх юзерів що грали в гру
            Sort();
            SavePlayers_inFile(); // зберігаю список всіх юзерів у файл
            Console.Clear();
            PrintPlayers();

        } // EndGame

        public void Sort() // для виводу списку гравців в порядку найбільших балів
        {
            Players.Sort((b, a) => a.Points.CompareTo(b.Points));
        } // Sort

        public void AddPlayer(Player p)
        {
            Players.Add(p);
        } // AddPlayer

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Random r = new Random(6);
            Console.Clear();

            Glas.Paint();
            Glas.Print(); // малюю стакан із падаючими фігурками !!!!!!!
            Glas.Fall(); // змінюю координати фігурки для  реалізації падіння

            if (Console.KeyAvailable == true) // якщо є нажаття клавіші то зайти у функцію і перемістити фігурку в ліво чи право
            {
                // KeyPress();
                Menu();
            }

            if (Glas.IsBottom() == true || Glas.IsFigureBelow() == true) // якщо низ стакана чи інша фігурка  то почати малювати нову фігурку зверху
            {
                Glas.NewFigure(R);
            }

            Glas.CheckLine();
            // gm.Glas.Shake(gm.Glas.CheckLine());

            Glas.NewGlass(); // ініціалізую стакан новими значеннями
            Glas.GameOver();
        } // OnTimedEvent

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
        } // Write_player_in_file

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
            Console.Clear();
            Console.SetCursorPosition(15, 0);
            Console.WriteLine(" besTScores: ");
            LoadPlayers_fromFile();

            int i = 2;
            foreach (Player pl in Players)
            {
                Console.SetCursorPosition(10, i);
                Console.WriteLine("{0,10} - {1} ", pl.Name, pl.Points);
                i++;
            }
        } // PrintPlayers

    } // Game
}