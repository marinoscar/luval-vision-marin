using luval.vision.core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace luval.tests
{
    [TestFixture]
    public class WhenOcrEngineIsCalled
    {
        [Test]
        public void ItShouldMakeAValidRequestToGoogleVision()
        {
            var bytes = File.ReadAllBytes(@"C:\Git\luval-vision\Code\luval.tests\TestFiles\sample1.png");
            var vision = new GoogleOcrEngine();
            var result = vision.Execute("sample1.png", bytes);
        }
    }
}
