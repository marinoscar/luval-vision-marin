using luval.vision.core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.tests
{
    [TestFixture]
    public class WhenAPDFIsConvertedToImage
    {
        [Test]
        public void ItShouldDoTheConversionWithoutErrors()
        {
            Pdf2Img.ConverToSingleImage(@"C:\Users\hmuir\Documents\Pernix\luval-vision\Docs\Sample1.pdf", @"C:\Users\hmuir\Documents\Pernix\luval-vision\Docs\Sample1.jpg");
        }
    }
}
