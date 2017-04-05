using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.bll;
using Microsoft.WindowsAzure.Storage.Blob;

namespace luval.tests
{
    [TestFixture]
    class WhenItFileStored
    {
        [Test]
        public void ItShouldStoreFile()
        {
            OcrBlobStorage blobStorage = new OcrBlobStorage();
            String guid = Guid.NewGuid().ToString();
            blobStorage.UploadFileBlobStorage(@"C:\Users\hmuir\Documents\Pernix\luval-vision\Docs\Sample1.jpg", "Sample1.jpg", "","");
        }

        [Test]
        public void ItShouldGetFilesStored()
        {
            OcrBlobStorage blobStorage = new OcrBlobStorage();
            IEnumerable<IListBlobItem> blobs = blobStorage.GetFilesBlobStorage();
            Assert.IsTrue(blobs.Count() > 0);
        }

        [Test]
        public void ItShouldDownloadFilesStored()
        {
            OcrBlobStorage blobStorage = new OcrBlobStorage();
            string text = blobStorage.DownloadFileBlobStorage(@"C:\Users\hmuir\Documents\Pernix\luval-vision\Docs\Sample1.jpg", "Sample1.jpg");
            Assert.IsNotEmpty(text);
        }
    }
}
