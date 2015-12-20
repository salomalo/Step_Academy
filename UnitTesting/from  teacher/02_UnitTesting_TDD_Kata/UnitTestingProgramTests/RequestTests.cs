using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnitTesting;

namespace UnitTestingProgramTests
{
    [TestFixture]
    public class RequestTests
    {
        private Request _request;
        private IConsoleProvider _provider;

        [SetUp]
        public void InitData()
        {
            _provider = Substitute.For<IConsoleProvider>();
            this._request = new Request(_provider);
        }

        [Test]
        public  void should_calc_requests_count_properly()
        {
            //arrange
            var randomCount = new Random().Next(100);

            //act
            for (int i = 0; i < randomCount; i++)
            {
                _request.Send("");
            }

            //assert
            randomCount.ShouldBeEquivalentTo(_request.GetRequestCount());
        }

        [Test]
        public void should_output_data()
        {
            //arrange
            var pack = Guid.NewGuid().ToString();
            var rr = Substitute.For<Request>(_provider);

            //rr.SomeScaryLegacyCode(Arg.Do<string>(x => { throw new Exception();}));

            //act
            rr.Send(pack);

            //assert
            rr.Received().SomeScaryLegacyCode(Arg.Is("LIL"));
        }

    }
}
