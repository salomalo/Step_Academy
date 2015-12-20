using System;
using NUnit.Framework;
using UnitTesting;
using FluentAssertions;

namespace UnitTestingProgramTests
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        public void should_handle_invalid_user_name(string userName)
        {
            //arrange
            var validator = new Validator();

            //act
            var ret = validator.Validate(userName, Guid.NewGuid().ToString());

            //assert
            //Assert.AreEqual(false, ret);
            ret.ShouldBeEquivalentTo(false);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        public void should_handle_invalid_user_password(string userPassword)
        {
            //arrange
            var validator = new Validator();

            //act
            var ret = validator.Validate(Guid.NewGuid().ToString(), userPassword);

            //assert
            //Assert.AreEqual(false, ret);
            ret.ShouldBeEquivalentTo(false);
        }

        [Test]
        [TestCaseSource("InvalidCases")]
        public void should_handle_invalid_data_for_user_name(char symb)
        {
            //arrange
            var validator = new Validator();

            //act
            var ret = validator.Validate(Guid.NewGuid().ToString() + symb, Guid.NewGuid().ToString());

            //assert
            //Assert.AreEqual(false, ret);
            ret.ShouldBeEquivalentTo(false);
        }

        static object[] InvalidCases =
        {
            new object[] { '@' },
            new object[] { '#' },
            new object[] { '%' },
        };
    }
}
