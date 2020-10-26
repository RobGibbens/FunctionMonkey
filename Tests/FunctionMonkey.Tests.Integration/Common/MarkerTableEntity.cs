using Microsoft.Azure.Cosmos.Table;

internal class MarkerTableEntity : TableEntity
{
    public int? Value { get; set; }
}