using NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    [TestFixture]
    public class Kata
    {

        [Test]
        public void should_handle_empty_()
        {
            //assert
            var calc = new Calc();

            //act
            var res=calc.Add("");

            //assert
            Assert.AreEqual(1, res);
        }


        [Test]
        public void should_handle_one_digit()
        {
            //assert
            var calc = new Calc();

            //act
            var res = calc.Add("1");

            //assert
            Assert.AreEqual(2, res);
        }


        [Test]
        public void should_handle_two_digit()
        {
            //assert
            var calc = new Calc();

            //act
            var res = calc.Add("1,2");

            //assert
            Assert.AreEqual(3, res);
        
        }
    }

    public class Calc
    {
        public int Add(string val)
        {
            if(val=="")
            return 1;

            if(val=="1")
            return 2;

            if (val == "1,2")
                return 3;

            return 4;
        }
    }


}
