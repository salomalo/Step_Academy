using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Tetris
{
   

    public class Tetraid : ICloneable
    {
        //public 


        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }


    public partial class Form1 : Form
    {
        Bitmap zfigure = new Bitmap("download.png");
        Bitmap line = new Bitmap("images.png");

        List<Bitmap> list;

        public Form1()
        {
            InitializeComponent();
            list = new List<Bitmap>();
            list.Add(zfigure);
            list.Add(line);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            

            List<Bitmap> tmp = new List<Bitmap>();

            Timer t = new Timer();
            t.Interval = 100000;

            for (int i = 0; i < 10; i++)
            { 
                Random r = new Random(2);
                pictureBox1.Image=list.ElementAt(r.Next(2));
                tmp.Add(list.ElementAt(r.Next(2)));
                pictureBox1.Dispose();
            }
             
        }




        public object Clone()
        {
            return this.MemberwiseClone();
        }

        // http://msdn.microsoft.com/en-us/library/orm-9780596527730-01-05.aspx
        public object DeepClone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);

            var copy = formatter.Deserialize(stream);

            stream.Close();
            return copy;
        }



    }



}
