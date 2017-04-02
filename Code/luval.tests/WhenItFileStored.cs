using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.bll;

namespace luval.tests
{
    [TestFixture]
    class WhenItFileStored
    {
        [Test]
        public void ItShouldStoreFile()
        {
            OcrBlobStorage blobStorage = new OcrBlobStorage();
            blobStorage.UploadFileBlobStorage(@"C:\Users\hmuir\Documents\Pernix\luval-vision\Docs\Sample1.jpg");
        }
    }
}
