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
            BlobStorageLogic blobStorage = new BlobStorageLogic();
            String guid = Guid.NewGuid().ToString();
            blobStorage.UploadFileBlobStorage(@"C:\Users\hmuir\Documents\Pernix\luval-vision\Docs\Sample1.jpg", "Sample1.jpg", null);
        }

        [Test]
        public void ItShouldGetFilesStored()
        {
            BlobStorageLogic blobStorage = new BlobStorageLogic();
            IEnumerable<IListBlobItem> blobs = blobStorage.GetFilesBlobStorage("");
            Assert.IsTrue(blobs.Count() > 0);
        }

        [Test]
        public void ItShouldDownloadFilesStored()
        {
            BlobStorageLogic blobStorage = new BlobStorageLogic();
            string text = blobStorage.DownloadFileBlobStorage(@"C:\Users\hmuir\Documents\Pernix\luval-vision\Docs\Sample1.jpg", "Sample1.jpg");
            Assert.IsNotEmpty(text);
        }

        [Test]
        public void ItShouldDeleteFile()
        {
            BlobStorageLogic blobStorage = new BlobStorageLogic();
            blobStorage.DeleteFile("harry182894gmailcom");
        }
    }
}
