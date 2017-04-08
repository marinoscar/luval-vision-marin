using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using luval.vision.core;
using luval.vision.entity;
using System.Text.RegularExpressions;

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

        public void UploadFileBlobStorage(string path, string blockName, ProcessResult processResult)
        {
            string ocrUser = Constants.prefix + processResult.UserId;
            BlobStorageConfiguration(ocrUser);
            AddContainerMetadata("Id", processResult.Id);
            AddContainerMetadata("UserId", ocrUser);
            setProcessResulToMetadata(processResult);
            blockBlob = blobContainer.GetBlockBlobReference(blockName);
            using (var fileStream = System.IO.File.OpenRead(path))
            {
                blockBlob.UploadFromStream(fileStream);
            }
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
            string ocrUser = Constants.prefix + userId;
            BlobStorageConfiguration(ocrUser);
            blobContainer.FetchAttributes();

            List<IListBlobItem> blobs = new List<IListBlobItem>();
            BlobContinuationToken token = null;
            do
            {
                BlobResultSegment resultSegment = blobContainer.ListBlobsSegmented(token);
                token = resultSegment.ContinuationToken;

                foreach (IListBlobItem blob in resultSegment.Results)
                {
                    foreach (var metadata in blobContainer.Metadata)
                    {
                        blob.Container.Metadata.Add(metadata.Key, metadata.Value);
                    }
                    blobs.Add(blob);
                }
            } while (token != null);
            return blobs;
        }

        private void AddContainerMetadata(string key, string value)
        {
            blobContainer.Metadata.Add(key, value);
            blobContainer.SetMetadata();
        }

        private void setProcessResulToMetadata(ProcessResult processResult)
        {
            foreach (var result in processResult.TextResults)
            {
                blobContainer.Metadata.Add(result.Map.AttributeName, result.Value);
            }
            blobContainer.SetMetadata();
        }

        private void BlobStorageConfiguration(string userId)
        {
            blobContainer = blobClient.GetContainerReference(userId.ToLower());
            blobContainer.CreateIfNotExists();
            blobContainer.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
        }
    }
}
