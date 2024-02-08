using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace SFTP
{

    public class ObjectStorageProtocol
    {
        private String strErrorDes = "";

        private AmazonS3Client _s3Client;

        public ObjectStorageProtocol(string accessKey, string secretKey)
        {
            // Use a default, dummy region for MinIO since it doesn't rely on AWS region settings
            var dummyRegion = "us-east-1"; // This is a commonly used AWS region, but it doesn't affect MinIO

            // Initialize the S3 client with provided credentials and dummy region
            var regionEndpoint = RegionEndpoint.GetBySystemName(dummyRegion);
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            _s3Client = new AmazonS3Client(credentials, regionEndpoint);
        }

        public ObjectStorageProtocol(string accessKey, string secretKey, string region)
        {
            // Initialize the S3 client with provided credentials and region
            var regionEndpoint = RegionEndpoint.GetBySystemName(region);
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            _s3Client = new AmazonS3Client(credentials, regionEndpoint);
        }

        public bool CheckIfFileExists(string bucketName, string objectKey)
        {
            try
            {
                var response = _s3Client.GetObjectMetadata(new GetObjectMetadataRequest
                {
                    BucketName = bucketName,
                    Key = objectKey,
                });

                return true;
            }
            catch (AmazonS3Exception e)
            {
                if (e.ErrorCode == "NotFound" || e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return false;
                else
                    throw;
            }
        }


        // Function that connects to the Object Storage
        public bool ConnectToObjectStorage(string strHost, int iPort, string strUserName, string strPassword, int iTimeout)
        {
            try
            {
                this.strErrorDes = "";

                // Check if the MinIO server uses HTTP or HTTPS
                string protocol = "http"; // Change to "https" if your server uses HTTPS
                string serviceUrl = $"{protocol}://{strHost}:{iPort}";

                // MinIO-specific configurations
                var config = new AmazonS3Config
                {
                    ServiceURL = serviceUrl,
                    ForcePathStyle = true,
                    Timeout = TimeSpan.FromSeconds(iTimeout),
                    UseHttp = protocol.Equals("http")
                };

                var credentials = new BasicAWSCredentials(strUserName, strPassword);
                _s3Client = new AmazonS3Client(credentials, config);

                return true;
            }
            catch (Exception exp)
            {
                this.strErrorDes = "NILE_Agent: ERROR - " + exp.ToString(); // Changed to exp.ToString() for more detailed info
                return false;
            }
        }




        // Function to upload a file to Object Storage
        public bool UploadFileToObjectStorage(string localFilePath, string bucketName, string objectName)
        {
            try
            {
                using (var fileStream = new FileStream(localFilePath, FileMode.Open))
                {
                    var fileTransferUtility = new TransferUtility(_s3Client);
                    fileTransferUtility.Upload(fileStream, bucketName, objectName);
                }

                Console.WriteLine($"File '{localFilePath}' uploaded to Object Storage successfully.");
                return true;
            }
            catch (Exception exp)
            {
                this.strErrorDes = "NILE_Agent: ERROR - " + exp.Message;
                return false;
            }
        }


        // Function to disconnect from Object Storage
        public void DisconnectFromObjectStorage()
        {
            try
            {
                // Dispose the S3 client to release resources
                this._s3Client.Dispose();
                this._s3Client = null; // Set to null to indicate that the client is no longer valid

            }
            catch (Exception exp)
            {
                this.strErrorDes = "NILE_Agent: ERROR - " + exp.Message;
            }
        }


        //Get ERROR
        public String getErrorDes()
        {
            return this.strErrorDes;
        }





    }

}
