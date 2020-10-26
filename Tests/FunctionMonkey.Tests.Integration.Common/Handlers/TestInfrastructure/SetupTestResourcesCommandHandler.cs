using System;
using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Tests.Integration.Common.Commands.TestInfrastructure;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Queue;

namespace FunctionMonkey.Tests.Integration.Common.Handlers.TestInfrastructure
{
    internal class SetupTestResourcesCommandHandler : ICommandHandler<SetupTestResourcesCommand>
    {
        public async Task ExecuteAsync(SetupTestResourcesCommand command)
        {
            // Storage
            var cosmosStorageAccount = Microsoft.Azure.Cosmos.Table.CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("storageConnectionString"));

            CloudTableClient tableClient = cosmosStorageAccount.CreateCloudTableClient();
            CloudTable markerTable = tableClient.GetTableReference(Constants.Storage.Table.Markers);
            await markerTable.CreateIfNotExistsAsync();

            var storageAccount = Microsoft.Azure.Storage.CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("storageConnectionString"));
            var queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue testQueue = queueClient.GetQueueReference(Constants.Storage.Queue.TestQueue);
            await testQueue.CreateIfNotExistsAsync();
            CloudQueue markerQueue = queueClient.GetQueueReference(Constants.Storage.Queue.MarkerQueue);
            await markerQueue.CreateIfNotExistsAsync();
            
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobCommandsContainer = blobClient.GetContainerReference(Constants.Storage.Blob.BlobCommandContainer);
            await blobCommandsContainer.CreateIfNotExistsAsync();
            CloudBlobContainer streamBlobCommandsContainer = blobClient.GetContainerReference(Constants.Storage.Blob.StreamBlobCommandContainer);
            await streamBlobCommandsContainer.CreateIfNotExistsAsync();
            CloudBlobContainer outputBlobContainer = blobClient.GetContainerReference(Constants.Storage.Blob.OutputBlobContainer);
            await outputBlobContainer.CreateIfNotExistsAsync();
            CloudBlobContainer outputBindingContainer =
                blobClient.GetContainerReference(Constants.Storage.Blob.BlobOutputCommandContainer);
            await outputBindingContainer.CreateIfNotExistsAsync();

            // Cosmos and Service Bus
            // Created through provisioning
        }
    }
}
