using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

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
            storage = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("azure.service.blob.storage.key"));
            blobClient = storage.CreateCloudBlobClient();
        }

        public void UploadFileBlobStorage(string path, string blockName, string guid, string userId)
        {
            BlobStorageConfiguration(userId);
            AddContainerMetadata("Id", guid);
            AddContainerMetadata("UserId", userId);
            blockBlob = blobContainer.GetBlockBlobReference(blockName);
            using (var fileStream = System.IO.File.OpenRead(path))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        private void AddContainerMetadata(string key, string value)
        {
            blobContainer.Metadata.Add(key, value);
            blobContainer.SetMetadata();
        }

        public string DownloadFileBlobStorage(string path, string blockName)
        {
            string text = string.Empty;
            blockBlob = blobContainer.GetBlockBlobReference(blockName);
            using (var memoryStream = new MemoryStream())
            {
                blockBlob.DownloadToStream(memoryStream);
                text = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            return text;
        }

        public IEnumerable<IListBlobItem> GetFilesBlobStorage(string userId)
        {
            BlobStorageConfiguration(userId);
            List<IListBlobItem> blobs = new List<IListBlobItem>();
            BlobContinuationToken token = null;
            do
            {
                BlobResultSegment resultSegment = blobContainer.ListBlobsSegmented(token);
                token = resultSegment.ContinuationToken;

                foreach (IListBlobItem item in resultSegment.Results)
                {
                    blobs.Add(item);
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = (CloudBlockBlob)item;
                        Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);
                    }

                    else if (item.GetType() == typeof(CloudPageBlob))
                    {
                        CloudPageBlob pageBlob = (CloudPageBlob)item;

                        Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);
                    }

                    else if (item.GetType() == typeof(CloudBlobDirectory))
                    {
                        CloudBlobDirectory directory = (CloudBlobDirectory)item;

                        Console.WriteLine("Directory: {0}", directory.Uri);
                    }
                }
            } while (token != null);
            return blobs;
        }

        private void BlobStorageConfiguration(string userId)
        {
            blobContainer = blobClient.GetContainerReference(userId);
            blobContainer.CreateIfNotExists();
            blobContainer.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
        }
    }
}
