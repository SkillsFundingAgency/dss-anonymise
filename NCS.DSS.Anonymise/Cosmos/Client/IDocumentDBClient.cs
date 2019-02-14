using Microsoft.Azure.Documents.Client;

namespace NCS.DSS.Anonymise.Cosmos.Client
{
    public interface IDocumentDBClient
    {
        DocumentClient CreateSourceDocumentClient(string endPoint, string key);
        DocumentClient CreateDestinationDocumentClient( string endPoint, string key);
    }
}