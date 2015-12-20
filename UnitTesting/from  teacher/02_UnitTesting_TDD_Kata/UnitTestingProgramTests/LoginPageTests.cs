using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
    }
}
