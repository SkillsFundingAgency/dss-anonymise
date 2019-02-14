using System;
using System.Configuration;
using Microsoft.Azure.Documents.Client;

namespace NCS.DSS.Anonymise.Cosmos.Client
{
    public class DocumentDBClient : IDocumentDBClient
    {
        private DocumentClient _documentClient_Source;
        private DocumentClient _documentClient_Destination;

       /* public DocumentClient CreateDocumentClient(string endPoint, string key)
        {
            if (_documentClient_Source != null)
                return _documentClient_Source;

            _documentClient_Source = new DocumentClient(new Uri( endPoint), key );
            return _documentClient_Source;
        }*/

        public DocumentClient CreateSourceDocumentClient(string endPoint, string key)
        {
            if (_documentClient_Source != null)
                return _documentClient_Source;

            _documentClient_Source = new DocumentClient(new Uri(endPoint), key);
            return _documentClient_Source;
        }
        
        public DocumentClient CreateDestinationDocumentClient(string endPoint, string key)
        {
            if (_documentClient_Destination != null)
                return _documentClient_Destination;

            _documentClient_Destination = new DocumentClient(new Uri(endPoint), key);
            
            return _documentClient_Destination;
        }
    }
}
