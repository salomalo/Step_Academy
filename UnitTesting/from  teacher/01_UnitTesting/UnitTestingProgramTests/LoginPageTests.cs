using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting;

namespace UnitTestingProgramTests
{
    [TestFixture]
    public class LoginPageTests
    {
        [Test]
        public void should_login_with_valid_user_name_and_id()
        {
            //arrange
            //TODO: mock object or substitute real life objects with some strubs or mocks / or fake object
            var validatorMock = Substitute.For<IValidator>();
            var requestMock = Substitute.For<IRequest>();
            var logger = Substitute.For<ILogger>();

            //validate method should return true in any cases
            validatorMock.Validate(Arg.Any<string>(), Arg.Any<string>()).Returns(true);

            //LoginPage is real instance
            var page = new LoginPage(validatorMock, requestMock, logger);
            string userName = Guid.NewGuid().ToString();
            string userPassword = Guid.NewGuid().ToString();

            var testPack = userName + userPassword;
            var message = "Send request with user {0} and password {1}";

            //act
            var res = page.DoLogin(userName, userPassword);

            //assert
            Assert.AreEqual(LoginResult.Ok, res);
            validatorMock.Received().Validate(userName, userPassword);
            requestMock.Received().Send(testPack + "0xABCDE");
            logger.Received().Log(message, userName, userPassword);
        }


        [Test]
        public void should_not_login_with_invalid_user_name_and_password()
        {
            //arrange
            var requestMock = Substitute.For<IRequest>();
            var logger = Substitute.For<ILogger>();
            var validatorMock = Substitute.For<IValidator>();

            validatorMock.Validate(Arg.Any<string>(), Arg.Any<string>()).Returns(false);

            //LoginPage is real instance
            var page = new LoginPage(validatorMock, requestMock, logger);
            string userName = Guid.NewGuid().ToString();
            string userPassword = Guid.NewGuid().ToString();

            //act
            var res = page.DoLogin(userName, userPassword);

            //assert
            Assert.AreEqual(LoginResult.Error, res);
            validatorMock.Received().Validate(userName, userPassword);

        }

        [Test]
        public void should_validate_not_valid_data()
        {
            //arrange
            //To Do
            var validator = new Validator();
            var name = string.Empty;
            var password = string.Empty;

            //act
            var invalidSymbols = new char[] { '@', '%', '#' };
            foreach (var s in invalidSymbols)
            {
                name += "name" + s;
                var res = validator.Validate(name, password);

                //assert
                Assert.AreEqual(false, res);
            }
        }

        [Test]
        public void should_validate_valid_data()
        {
            //arrange
            //To Do
            var validator = new Validator();
            string name = Guid.NewGuid().ToString();
            string password = Guid.NewGuid().ToString();
            //act
            var res = validator.Validate(name, password);
            //assert
            Assert.AreEqual(true, res);
        }


        [Test]
        public void Should_add_Loog()
        {
            //arrange
            //TODO: mock object or substitute real life objects with some strubs or mocks / or fake object
            var validatorMock = Substitute.For<IValidator>();
            var requestMock = Substitute.For<IRequest>();


            var logger = Substitute.For<ILogger>();

            //validate method should return true in any cases
            validatorMock.Validate(Arg.Any<string>(), Arg.Any<string>()).Returns(true);

            //LoginPage is real instance
            var page = new LoginPage(validatorMock, requestMock, logger);
            string userName = Guid.NewGuid().ToString();
            string userPassword = Guid.NewGuid().ToString();

            var testPack = userName + userPassword;
            var message = "Send request with user {0} and password {1}";

            //act
            var res = page.DoLogin(userName, userPassword);
            //var res2 = logger.Log(testPack + "0xABCDE");

            logger.Received().Log(message, userName, userPassword);


            //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Trace.WriteLine(logger);
            
            Trace.Listeners.Add(new ConsoleTraceListener(false));//(Console.Out)); 
            Trace.WriteLine(message);


            //assert
            Assert.AreEqual(LoginResult.Ok, res);
            validatorMock.Received().Validate(userName, userPassword);
            requestMock.Received().Send(testPack + "0xABCDE");

        }




    }
}