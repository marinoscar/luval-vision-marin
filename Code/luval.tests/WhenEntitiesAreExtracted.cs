using luval.vision.core;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.tests
{
    [TestFixture]
    public class WhenEntitiesAreExtracted
    {
        private Tuple<OcrResult, List<AttributeMapping>> _data;
        
        [OneTimeSetUp]
        public void Setup()
        {
            var fileName = TestContext.CurrentContext.TestDirectory + @"\TestFiles\ocr-result-and-mappings.json";
            var json = File.ReadAllText(fileName);
            _data = JsonConvert.DeserializeObject<Tuple<OcrResult, List<AttributeMapping>>>(json);
        } 

        [Test]
        public void ItShouldNavigateTheAttributes()
        {
            var navigator = new Navigator(_data.Item1.Info, _data.Item1.Lines, _data.Item2);
            navigator.DoExtract();
        }
    }
}
