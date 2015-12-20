using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

namespace TDD
{
    [TestFixture]
    public class StringCalculatorTest
    {
        [Test]
        public void should_return_zero_for_empty_string()
        {
            //arrange
            var calc = new StringCalculator();

            //act
            var result = calc.Add("");

            //assert
            result.ShouldBeEquivalentTo(0);
        }

        [Test]
        public void should_handle_one_digit()
        {
            //arrange
            var calc = new StringCalculator();
            var d = new Random().Next(10);

            //act
            var result = calc.Add(d.ToString());

            //assert
            result.ShouldBeEquivalentTo(d);
        }

        [Test]
        public void should_add_two_random_digits()
        {
            //arrange
            var calc = new StringCalculator();
            var one = new Random().Next(10);
            var two = new Random().Next(10);

            //act
            var result = calc.Add(one + "," + two);

            //assert
            result.ShouldBeEquivalentTo(one + two);
        }

        [Test]
        public void should_handle_unknown_amount_of_digits()
        {
            //arrange
            var calc = new StringCalculator();
            var count = new Random().Next(10);

            var digiList = new List<int>();
            for (int i = 0; i < count; i++)
            {
                digiList.Add(new Random().Next(10));
            }
            
            //act
            var result = calc.Add(String.Join(",", digiList));

            //assert
            result.ShouldBeEquivalentTo(digiList.Sum()); 
        }

        [Test]
        public void should_handle_new_line_separator()
        {
            //arrange
            var calc = new StringCalculator();

            //act
            var result = calc.Add("1\n2,3");

            //assert
            result.ShouldBeEquivalentTo(6);
        }
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
                return 0;

            int val;
            if (int.TryParse(numbers, out val))
            {
                return val;
            }

            var ret = numbers.Split(',', '\n').Select(x => int.Parse(x)).Sum();

            return ret;
        }
    }
}
