using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace FunctionMonkey.Tests.Integration.Common.Model
{
    public class MarkerTableEntity : TableEntity
    {
        public static Task<MarkerTableEntity> Success(Guid markerId)
        {
            return Task.FromResult(new MarkerTableEntity
            {
                PartitionKey = markerId.ToString(),
                RowKey = string.Empty
            });
        }
    }
}
