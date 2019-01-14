using Microsoft.Azure.Documents.Client;

namespace NCS.DSS.Anonymise.Cosmos.Client
{
    public interface IDocumentDBClient
    {
        DocumentClient CreateSourceDocumentClient();
        DocumentClient CreateDestinationDocumentClient();
    }
}