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
            var dates = new string[] { "30/12/2017", "30-12-17", "30-12-2017", "30/12/17" };
            var res = _resManager.Get<DateResolver>();
            foreach(var date in dates)
            {
                Assert.IsTrue(res.IsMatch(date), string.Format("Failed to match date {0}", date));
            }
        }
    }
}
