using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
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
}