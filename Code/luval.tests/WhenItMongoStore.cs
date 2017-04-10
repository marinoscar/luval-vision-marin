using luval.vision.bll;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.tests
{
    [TestFixture]
    class WhenItMongoStore
    {
        [Test]
        public void ItShouldStoreFile()
        {
            OcrBlobStorage blobStorage = new OcrBlobStorage();
            blobStorage.DeleteFile("harry182894gmailcom");
        }
    }
}
