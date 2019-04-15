using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using NCS.DSS.Anonymise.Cosmos.Client;
using NCS.DSS.Anonymise.Cosmos.Helper;
using NCS.DSS.Anonymise.ReferenceData;

namespace NCS.DSS.Anonymise.Cosmos.Provider
{
    public class DocumentDBProvider  : IDocumentDBProvider
    {
        private readonly DocumentDBHelper _documentDbHelper;
        private readonly DocumentDBClient _databaseClient;
        private Random RandomSeed = new Random();
       // private RandomUtils _utils;
        private string sourceEndPoint;
        public string TargetPostFix { get; set;} = "-anonymised";

        public void SetSourceEndPoint(string endPoint)
        {
            sourceEndPoint = endPoint;
        }

        private string targetEndPoint;
        public void SetTargetEndPoint(string endPoint)
        {
            targetEndPoint = endPoint;
        }
        private string sourceKey;
        public void SetSourceKey(string key)
        {
            sourceKey = key;
        }

        private string targetKey;
        public void SetTargetKey(string key)
        {
            targetKey = key;
        }

        public DocumentDBProvider()
        {
            _documentDbHelper = new DocumentDBHelper();
            _databaseClient = new DocumentDBClient();
            // = new RandomUtils();
        }

        public async Task<List<T>> GetAllDocuments<T>(string database, string collection)
        {
            var collectionUri = _documentDbHelper.GetUri(database, collection);
            var client = _databaseClient.CreateSourceDocumentClient(sourceEndPoint, sourceKey);
         //   var client = _databaseClient.CreateSourceDocumentClient();
            if (client == null)
                return null;

            var queryCust = client.CreateDocumentQuery<T>(collectionUri).AsDocumentQuery();
            var list = new List<T>();
            int i = 0;
            while (queryCust.HasMoreResults )// && i <= 1)
            {
                i++;
                var response = await queryCust.ExecuteNextAsync<T>();
                list.AddRange(response);
            }
            return list.Any() ? list : null;
        }

        public async Task AnonymiseCollectionData<T>(string database, string collection) where T : Models.IAnonymise
        {
            Console.WriteLine("Starting Anonymise Process for" + typeof(T) + " DB: " + database + " Collection: " + collection);
            string destinationCollection = collection + TargetPostFix;

            var sourceCollection = await GetAllDocuments<T>(database, collection);

            var collectionUri = _documentDbHelper.GetUri(database, destinationCollection);
            var client = _databaseClient.CreateDestinationDocumentClient(targetEndPoint, targetKey);

            await client.CreateDatabaseIfNotExistsAsync(new Database { Id = database });
            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(database),
                    new DocumentCollection { Id = destinationCollection }).
                    GetAwaiter()
                    .GetResult();
            int iCount = 0;
            foreach (var item in sourceCollection.Where( x => Convert.ToInt64(x.LastModifiedTouchpointId) < 9000000000))
            {
                iCount++;
                Console.WriteLine(typeof(T) + " item " + iCount);
                item.SetRandomSeed(RandomSeed);
                item.Anonymise();
                try
                {
                    var response = await client.CreateDocumentAsync(collectionUri, item);
                }
                catch( Exception e)
                {
                    Console.WriteLine(e.Message + e.InnerException);
                }
            }
        }

    }
}