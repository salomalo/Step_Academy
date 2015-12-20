using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace tetris_points
{
    class Program
    {
        static void Main(string[] args)
        {
            Player pl = new Player("nam", 9);
            Player pl2 = new Player("n", 2);
            Game gm = new Game();
            gm.AddPlayer(pl);
            gm.AddPlayer(pl2);
            // gm.Print();

            gm.SavePlayers_inFile();

            gm.LoadPlayers();
            gm.PrintPlayers();



        } // main 
    } // Program


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

        public Game()
        {
            Players = new List<Player>();
        }
        public void AddPlayer(Player p)
        {
            Players.Add(p);
        }

        public void SavePlayers_inFile()
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
                    Console.WriteLine("{0} - {1} ", pl.Name, pl.Points);
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
        public void Write_player_in_file(Player pl, XmlTextWriter writer)
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