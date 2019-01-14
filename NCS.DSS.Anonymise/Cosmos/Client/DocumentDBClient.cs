using System;
using System.Configuration;
using Microsoft.Azure.Documents.Client;

namespace NCS.DSS.Anonymise.Cosmos.Client
{
    public class DocumentDBClient : IDocumentDBClient
    {
        private DocumentClient _documentClient_Source;
        private DocumentClient _documentClient_Destination;

        public DocumentClient CreateSourceDocumentClient()
        {
            if (_documentClient_Source != null)
                return _documentClient_Source;

            _documentClient_Source = new DocumentClient(new Uri(
                ConfigurationManager.AppSettings["TESTEndpoint"]),
                ConfigurationManager.AppSettings["TESTKey"]);

            return _documentClient_Source;
        }
        
        public DocumentClient CreateDestinationDocumentClient()
        {
            if (_documentClient_Destination != null)
                return _documentClient_Destination;

            _documentClient_Destination = new DocumentClient(new Uri(
                ConfigurationManager.AppSettings["ATEndpoint"]),
                ConfigurationManager.AppSettings["ATKey"]);

            return _documentClient_Destination;
        }
    }
}
