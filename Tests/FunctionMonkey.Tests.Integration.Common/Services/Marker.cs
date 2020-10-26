using System;
using System.Threading.Tasks;
using FunctionMonkey.Tests.Integration.Common.Model;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Storage;

namespace FunctionMonkey.Tests.Integration.Common.Services
{
    public class Marker : IMarker
    {
        public async Task RecordMarker(Guid markerId)
        {
            Microsoft.Azure.Cosmos.Table.CloudStorageAccount storageAccount = Microsoft.Azure.Cosmos.Table.CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("storageConnectionString"));
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(Constants.Storage.Table.Markers);

            await table.ExecuteAsync(TableOperation.InsertOrReplace(new MarkerTableEntity
            {
                PartitionKey = markerId.ToString(),
                RowKey = string.Empty
            }));
        }
    }
}