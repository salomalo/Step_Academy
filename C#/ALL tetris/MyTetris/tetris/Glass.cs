using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace tetris
{
    public class Glass // стакан 
    {
        public event EventHandler IsLine; //подія ЛІНІЯ 
        public event EventHandler IsGameOver; //подія програш 

        protected System.Timers.Timer _timer;
        public System.Timers.Timer Timer
        {
            set
            {
                _timer = value;
            }
            get
            {
                return _timer;
            }
        }

        protected int _lineNumber; // номер строки із лінією
        public int LineNumber
        {
            set
            {
                _lineNumber = value;
            }
            get
            {
                return _lineNumber;
            }
        }

        protected int _score; // бали за гру
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

        protected Figure _curFigure; // поточна фігура (яка падає в даний момент)
        public Figure CurFigure
        {
            set
            {
                _curFigure = value;
            }
            get
            {
                return _curFigure;
            }
        } // Figure

        protected Figure_Type _curType;
        public Figure_Type CurType
        {
            set
            {
                _curType = value;
            }
            get
            {
                return _curType;
            }
        } // CurType

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
            Timer = new System.Timers.Timer(1000);
            Timer.Interval = 250;
            Timer.Enabled = true;

            ////////////////
            LineNumber = -1;
            Score = 0;
            CurY = 0;
            CurX = 9;
            ////////////////////////////////
            CurType = Figure_Type.Piramida;
            CurFigure = new Piramida(CurX, CurY);

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
            IsLine += Shake; // підписую на подію ЛІНІЯ - обробнмка ШЕЙК
        } // Glass
        public void Paint() // переношу фігурку в стакан
        {
            foreach (Point p in CurFigure.Arr)
                Arr[p.Y, p.X] = true;
        } // Paint
        public void NewGlass() //// метод зберігає стакан із фігурками які впали на дно і робить його поточним( переініціалізовую стакан новими занченнями 
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
        public void NewFigure(Random r) // генерація нової фігурки на весрі стакану
        {
            Timer.Interval = 250;
            Clear_figure(); // clear current figure and set new type of figure in it
            CurY = 0;
            CurX = 9;
            ////////////////////////////
            CurFigure = New_Figure_Type(r);
            // CurFigure = new Piramida(CurX, CurY);
        }
        public void Clear_figure() // очищЯю значеннЯ ф?гурки щоб змінити тип падаючої фігурки
        {
            CurFigure.Arr.Clear();
        }
        public Figure New_Figure_Type(Random r) // присвоюю новий тип ф?гур?  
        {
            CurY = 0;
            CurX = 9;
            CurType = (Figure_Type)r.Next(1);
            if (CurType == Figure_Type.RightZ)
            {
                return new RightZ(CurX, CurY);
            }
            if (CurType == Figure_Type.Dot)
            {
                return new Dot(CurX, CurY);
            }
            if (CurType == Figure_Type.LeftL)
            {
                return new LeftL(CurX, CurY);
            }
            if (CurType == Figure_Type.line)
            {
                return new line(CurX, CurY);
            }
            if (CurType == Figure_Type.Piramida)
            {
                return new Piramida(CurX, CurY);
            }
            if (CurType == Figure_Type.Square)
            {
                return new Square(CurX, CurY);
            }
            return this.CurFigure;
        } // New_Figure_Type

        public void Move(int x) // змінюю координатУ Х фігурки для  реалізації пересування в боки 
        {
            CurX += x;
            CurFigure.NewPos(CurX, CurY);
        } // Move

        public bool IsRight()
        {
            int max = 1;
            int min = Arr.GetLength(0);
            foreach (Point p in CurFigure.Arr)
            {
                if (p.X > max) max = p.X;
                if (p.X < min) min = p.X;
            }

            int tf = Arr.GetLength(0) - 1 - min;
            int res = Arr.GetLength(0) - 1 - tf;

            foreach (Point p in CurFigure.Arr)
            {
                if (max == Arr.GetLength(0) - 1)
                {
                    return true;
                }

            }
            return false;
        }

        public bool IsLeft()
        {
            int min = Arr.GetLength(0);
            foreach (Point p in CurFigure.Arr)
            {
                if (p.X < min) min = p.X;
            }

            foreach (Point p in CurFigure.Arr)
            {
                if (min == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 
        public bool IsFigureRight()
        {
            int max = 1;
            int min = Arr.GetLength(0);
            int maxX = 1;
            foreach (Point p in CurFigure.Arr)
            {
                if (p.Y > max) max = p.Y;
                if (p.X > maxX) maxX = p.X;
                if (p.X < min) min = p.X;
            }

            // Console.WriteLine("max {0}", max);
            foreach (Point p in CurFigure.Arr)
            {
                //if (CurFigure.Check == "lv" && (Arr[p.Y, p.X] == true || Arr[p.Y + 1, p.X] == true || Arr[p.Y + 2, p.X] == true || Arr[p.Y + 3, p.X] == true))
                //{
                //    // Copy(Arr, Buffer); // копіюю з arr в buffer
                //    //   Console.WriteLine("is right CurX {0}", CurX);
                //    return true;
                //}


                // // працює для квадрата і для лінії
                if (CurFigure.Check == "s"&& Arr[p.Y, maxX + 1] == true)
                {
                    return true;
                }



                //if (CurFigure.Check == "Lefv" && (Arr[p.Y, min] == true || Arr[max, maxX] == true || Arr[p.Y+1, min] == true))
                //{
                //    return true;
                //}

                //if (CurFigure.Check == "Lefg" && (Arr[p.Y, maxX] == true || Arr[max, min] == true))
                //{
                //    return true;
                //}

                //if (CurFigure.Check == "LefvII" && (Arr[p.Y, maxX] == true))// || Arr[p.Y + 1, maxX] == true || Arr[p.Y+2, maxX] == true))
                //{
                //    return true;
                //}

                //if (CurFigure.Check == "LefgII" && (Arr[p.Y, maxX] == true || Arr[p.Y+1, maxX] == true))
                //{
                //    return true;
                //}





            }
            return false;
        } // IsFigureRight

        public bool IsFigureLeft()
        {
            int max = 1;
            int min = Arr.GetLength(0);
            int maxX = 1;
            foreach (Point p in CurFigure.Arr)
            {
                if (p.Y > max) max = p.Y;
                if (p.X > maxX) maxX = p.X;
                if (p.X < min) min = p.X;
            }

            foreach (Point p in CurFigure.Arr)
            {
                //if (CurFigure.Check == "lv" && (Arr[p.Y, p.X] == true || Arr[p.Y + 1, p.X] == true || Arr[p.Y + 2, p.X] == true || Arr[p.Y + 3, p.X] == true))
                //{
                //    // Copy(Arr, Buffer); // копіюю з arr в buffer
                //    //   Console.WriteLine("is right CurX {0}", CurX);
                //    return true;
                //}


                // працює для квадрата
                //if (CurFigure.Check == "s" && (Arr[p.Y, min - 1] == true))
                //{
                //    Console.WriteLine(" check FigureLeft {0}", min);
                //    return true;
                //}

                //if (Arr[p.Y, min - 1] == true)
                //{
                //    return true;
                //}


                //if (CurFigure.Check == "Lefv" && (Arr[p.Y, min] == true || Arr[p.Y + 1, min] == true || Arr[p.Y+2, min] == true))
                //{
                //    return true;
                //}
                //if (CurFigure.Check == "Lefg" && (Arr[p.Y, min] == true || Arr[p.Y+1, min] == true))
                //{
                //    return true;
                //}

                //if (CurFigure.Check == "LefvII" && (Arr[p.Y, min] == true || Arr[p.Y + 1, maxX] == true || Arr[p.Y+2, maxX] == true))
                //{
                //    return true;
                //}

                //if (CurFigure.Check == "LefgII" && (Arr[p.Y+1, min] == true || Arr[p.Y, maxX] == true))
                //{
                //    return true;
                //}

            }
            return false;
        } // IsFigureLeft

        public void Fall() // змінюю координату У фігурки для  реалізації падіння
        {
            CurY += 1;
            CurFigure.NewPos(CurX, CurY);
        } // Fall


        public bool IsBottom() // перевірка на дно 
        {
            int max = 1;
            foreach (Point p in CurFigure.Arr)
            {
                if (p.Y > max) max = p.Y;
            }
            foreach (Point p in CurFigure.Arr)
            {
                if (max == Arr.GetLength(0))
                {
                    Copy(Arr, Buffer); // копіюю з arr в buffer
                    return true;
                }
            }
            return false;
        } // IsBottom

        /// ///////////////////////////////////////////////////////////////////////
        public bool IsFigureBelow() // перевірка на фігурку під фігуркою
        {
          

            int max = 1;
            int min = Arr.GetLength(0);
            int minY = Arr.GetLength(0);
            int maxX = 1;
            foreach (Point p in CurFigure.Arr)
            {
                if (p.Y > max) max = p.Y;
                if (p.X > maxX) maxX = p.X;
                if (p.X < min) min = p.X;
                if (p.Y < minY) minY = p.Y;
            }

            foreach (Point p in CurFigure.Arr)
            {
                if (CurFigure.Check == "lv" && (Arr[max, p.X] == true)) // || Arr[max, p.X + 1] == true))
                {
                    Copy(Arr, Buffer); // копіюю з arr в buffer
                    return true;
                }
                if (CurFigure.Check == "s" && (Arr[max, p.X] == true || Arr[max, p.X + 1] == true))
                {
                    Copy(Arr, Buffer); // копіюю з arr в buffer
                    return true;
                }
                if (CurFigure.Check == "zg" && (Arr[max, p.X + 1] == true || Arr[max, p.X + 2] == true || Arr[p.Y, min] == true))
                {
                    Copy(Arr, Buffer); // копіюю з arr в buffer
                    return true;
                }
                if (CurFigure.Check == "zv" && (Arr[max - 1, maxX] == true || Arr[max, maxX - 1] == true))
                {
                    Copy(Arr, Buffer); // копіюю з arr в buffer
                    return true;
                }

   /////////////////////////////
                //if (CurFigure.Check == "Lefv" && (Arr[max, p.X] == true)) // || Arr[max, p.X + 1] == true))
                //{
                //    Copy(Arr, Buffer); // копіюю з arr в buffer
                //    return true;
                //}

                //if (CurFigure.Check == "Lefg" && ( Arr[p.Y+1, min] == true))// || Arr[minY, p.X+1] == true ))
                //{
                //    Copy(Arr, Buffer); // копіюю з arr в buffer
                //    return true;
                //}

                //if (CurFigure.Check == "LefvII" && (Arr[p.Y, p.X] == true || Arr[max, maxX] == true))
                //{
                //    Copy(Arr, Buffer); // копіюю з arr в buffer
                //    return true;
                //}
                //if (CurFigure.Check == "LefgII" && (Arr[max, p.X] == true || Arr[max, p.X + 1] == true || Arr[max, p.X + 2] == true))
                //{
                //    Copy(Arr, Buffer); // копіюю з arr в buffer
                //    return true;
                //}

                //////////////////////////////////////
                //// piramida
                if (CurFigure.Check == "pg" && (Arr[max, p.X] == true || Arr[max, p.X + 1] == true || Arr[max, p.X - 1] == true))
                {
                    Copy(Arr, Buffer); // копіюю з arr в buffer
                    return true;
                }

                if (CurFigure.Check == "pv" && (Arr[max, p.X] == true || Arr[max - 1, p.X + 1] == true))
                {
                    Copy(Arr, Buffer); // копіюю з arr в buffer
                    return true;
                }

                if (CurFigure.Check == "pgII" && (Arr[max, p.X + 1] == true || Arr[p.Y, min] == true || Arr[p.Y, maxX] == true))
                {
                    Copy(Arr, Buffer); // копіюю з arr в buffer
                    return true;
                }

                if (CurFigure.Check == "pvII" && (Arr[p.Y + 1, min] == true || Arr[max, p.X] == true))
                {
                    Copy(Arr, Buffer); // копіюю з arr в buffer
                    return true;
                }

                if (CurFigure.Check == "d" && Arr[p.Y, p.X])
                {
                    //Arr[CurFigure.Y, CurFigure.X] = true;
                    Copy(Arr, Buffer); // копіюю з arr в buffer
                    return true;
                }
            }

            return false;
        } // IsFigureBelow

        public void CheckLine() // перевірка чи є складена лінія 
        {
            LineNumber = -1;
            int tmp = 0;
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(0); j++)
                {
                    if (Arr[i, j] == true)
                    {
                        tmp++;
                    }
                }
                if (tmp == Arr.GetLength(0))
                {
                    LineNumber = i;
                    if (LineNumber > -1)
                        OnIsLine();
                }
                tmp = 0;
            }
        } // CheckLine

        public void Shake(object sender, EventArgs args)
        // public void Shake(int num)
        {
            int i = LineNumber;
            for (int j = 0; j < Arr.GetLength(1); j++) // x col
            {
                Score++;
                Arr[i, j] = false;
                Copy(Arr, Buffer); // копіюю з arr в buffer
            }
            for (i = LineNumber - 1; i > 0; i--)
            {
                for (int j = 0; j < Arr.GetLength(0); j++) // x col
                {
                    if (Arr[i, j] == true)
                    {
                        if (Arr[i + 1, j] == false)
                        {
                            Arr[i, j] = false;
                            Arr[i + 1, j] = true;
                            Copy(Arr, Buffer); // копіюю з arr в buffer
                        }
                    }
                }
            }
            for (i = LineNumber; i > 0; i--)
            {
                for (int j = 0; j < Arr.GetLength(0); j++) // x col
                {
                    if (i == Arr.GetLength(0) - 1)
                    {
                        if (Arr[i - 1, j] == true)
                        {
                            Arr[i, j] = true;
                            Copy(Arr, Buffer); // копіюю з arr в buffer
                        }
                        if (Arr[i - 1, j] == false)
                        {
                            Arr[i, j] = false;
                            Copy(Arr, Buffer); // копіюю з arr в buffer
                        }
                    }
                    else if (i != Arr.GetLength(0))
                    {
                        if (Arr[i, j] == true)
                        {
                            if (Arr[i + 1, j] == false)
                            {
                                Arr[i, j] = false;
                                Arr[i + 1, j] = true;
                                Copy(Arr, Buffer); // копіюю з arr в buffer
                            }
                        }
                    }
                }
            }
        } // Shake

        /// <summary>
        /// ////////////////////////////////////////////////////
        /// </summary>

        public bool GameOver()
        {
            foreach (Point p in CurFigure.Arr)
            {
                if (CurY == 0 && IsFigureBelow() == true)
                {
                    Console.WriteLine("GAME OVER");
                    Console.ReadLine();
                    OnIsGameOver();
                    return true;
                }
            }
            return false;
        } // GameOver

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


        public void OnIsLine() // перевіряю чи хтось підписаний на подію IsLine
        {
            if (IsLine != null)  //перевірка чи хтось підписався на подію
            {
                IsLine(this, EventArgs.Empty);
            }
        } // OnIsLine

        public void OnIsGameOver() // перевіряю чи хтось підписаний на подію IsLine
        {
            if (IsGameOver != null)  //перевірка чи хтось підписався на подію
            {
                IsGameOver(this, EventArgs.Empty);
            }
        } // IsGameOver

    } // Glass
}