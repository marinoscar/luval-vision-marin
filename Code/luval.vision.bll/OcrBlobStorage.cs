using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace luval.vision.bll
{
    public class OcrBlobStorage
    {
        private CloudStorageAccount storage;
        private CloudBlobClient blobClient;
        private CloudBlobContainer blobContainer;
        private CloudBlockBlob blockBlob;

        public OcrBlobStorage()
        {
            BlobStorageConfiguration();
        }

        public void UploadFileBlobStorage(string path)
        {
            using (var fileStream = System.IO.File.OpenRead(path))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        private void BlobStorageConfiguration()
        {
            storage = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("azure.service.blob.storage.key"));
            blobClient = storage.CreateCloudBlobClient();
            blobContainer = blobClient.GetContainerReference("celeris-container");
            blobContainer.CreateIfNotExists();
            blobContainer.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
            blockBlob = blobContainer.GetBlockBlobReference("celeris-blob");
        }
    }
}
