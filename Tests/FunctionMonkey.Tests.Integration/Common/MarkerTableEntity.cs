using Microsoft.Azure.Storage.Table;

internal class MarkerTableEntity : TableEntity
{
    public int? Value { get; set; }
}