using luval.vision.core.resolvers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.tests
{
    [TestFixture]
    public class WhenItLooksForEntities
    {

        private StringResolverManager _resManager;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            _resManager = new StringResolverManager();
        }

        [Test]
        public void ItShouldFindAValidDate()
        {
            var dates = new string[] { "30/12/2017", "30-12-17", "30-12-2017", "30/12/17", "2017-1-1", "2017/01/01", "1/2/2017", "1/2/17" };
            ValidateExpressionWithArray(_resManager.Get<DateResolver>(), dates);
        }

        [Test]
        public void ItShouldFindAValidNumber()
        {
            var nums = new string[] { "12345", "123456.78", "1,000.00", "1,000.000", "1,000,000,000.00" };
            ValidateExpressionWithArray(_resManager.Get<NumberResolver>(), nums);
        }

        private void ValidateExpressionWithArray(IStringResolver res, string[] vals)
        {
            foreach(var val in vals)
            {
                Assert.IsTrue(res.IsMatch(val), "Unable to parse {0}", val);
            }
        }
    }
}
