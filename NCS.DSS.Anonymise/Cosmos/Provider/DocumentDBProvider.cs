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
using NCS.DSS.Anonymise.Utils;

namespace NCS.DSS.Anonymise.Cosmos.Provider
{
    public class DocumentDBProvider : IDocumentDBProvider
    {
        private readonly DocumentDBHelper _documentDbHelper;
        private readonly DocumentDBClient _databaseClient;
        private RandomUtils _utils;
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
            _utils = new RandomUtils();
        }

        private async Task<List<T>> GetAllDocuments<T>(string collection, string database)
        {
            var collectionUri = _documentDbHelper.GetUri(database, collection);
            var client = _databaseClient.CreateDocumentClient(sourceEndPoint, sourceKey);
         //   var client = _databaseClient.CreateSourceDocumentClient();
            if (client == null)
                return null;

            var queryCust = client.CreateDocumentQuery<T>(collectionUri).AsDocumentQuery();
            var list = new List<T>();
            int i = 0;
            while (queryCust.HasMoreResults && i < 10)
            {
                i++;
                var response = await queryCust.ExecuteNextAsync<T>();
                list.AddRange(response);
            }
            return list.Any() ? list : null;
        }

        public async Task AnonymiseCollectionData<T>(string database, string collection) where T : Models.IAnonymise
        {
            string destinationCollection = collection + TargetPostFix;

            var sourceCollection = await GetAllDocuments<T>(collection, database);

            var collectionUri = _documentDbHelper.GetUri(database, destinationCollection);
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);
            //var client = _databaseClient.CreateSourceDocumentClient();


            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(database),
                    new DocumentCollection { Id = destinationCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var item in sourceCollection)
            {
                // nothing to anon ???
                item.Anonymise();
                var response = await client.CreateDocumentAsync(collectionUri, item);
            }
        }


        /*    private async Task<List<Models.Customer>> GetAllCustomers()
            {
                var collectionUri = _documentDbHelper.GetUri(CosmosConstants.CustomerCol, CosmosConstants.CustomerDB);
                var client = _databaseClient.CreateDocumentClient(sourceEndPoint, sourceKey);

                if (client == null)
                    return null;

                var queryCust = client.CreateDocumentQuery<Models.Customer>(collectionUri).AsDocumentQuery();
                var customers = new List<Models.Customer>();

                while (queryCust.HasMoreResults)
                {
                    var response = await queryCust.ExecuteNextAsync<Models.Customer>();
                    customers.AddRange(response);
                }

                return customers.Any() ? customers : null;
            }
          */
        public async Task AnonymiseCustomerData()
        {
            var customers = await GetAllDocuments<Models.Customer>(CosmosConstants.CustomerCol, CosmosConstants.CustomerDB);

            var collectionUri = _documentDbHelper.GetUri(CosmosConstants.CustomerCol, CosmosConstants.CustomerDB);
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.CustomerDB;
            var databaseCollection = CosmosConstants.CustomerCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var cust in customers)
            {
                cust.Anonymise();
                cust.FamilyName = _utils.RandomString() + cust.FamilyName + _utils.RandomString();
                cust.GivenName = _utils.RandomString() + cust.GivenName + _utils.RandomString();
                cust.DateofBirth = _utils.RandomDate();
                var response = await client.CreateDocumentAsync(collectionUri, cust);
            }

        }
        /*

        private async Task<List<Models.Address>> GetAllAddresses()
        {
            var collectionUri = _documentDbHelper.CreateSourceAddressDocumentCollectionUri();
            var client = _databaseClient.CreateSourceDocumentClient();

            if (client == null)
                return null;

            var queryCust = client.CreateDocumentQuery<Models.Address>(collectionUri).AsDocumentQuery();
            var addresses = new List<Models.Address>();

            while (queryCust.HasMoreResults)
            {
                var response = await queryCust.ExecuteNextAsync<Models.Address>();
                addresses.AddRange(response);
            }

            return addresses.Any() ? addresses : null;
        }
        */

        public async Task AnonymiseAddressData()
        {
            var addresses = await GetAllDocuments<Models.Address>(CosmosConstants.AddressCol, CosmosConstants.AddressDB);

            var collectionUri = _documentDbHelper.GetUri(CosmosConstants.AddressCol, CosmosConstants.AddressDB);
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.AddressDB;
            var databaseCollection = CosmosConstants.AddressCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var addr in addresses)
            {

                if (addr.Address1 !=null)
                    addr.Address1 = addr.Address1.Replace(" ", _utils.RandomString()) + _utils.RandomString();
                if (addr.Address2 != null)
                    addr.Address2 = addr.Address2.Replace(" ", _utils.RandomString()) + _utils.RandomString();
                if (addr.Address3 != null)
                    addr.Address3 = addr.Address3.Replace(" ", _utils.RandomString()) + _utils.RandomString();
                if (addr.Address4 != null)
                    addr.Address4 = addr.Address4.Replace(" ", _utils.RandomString()) + _utils.RandomString();
                if (addr.Address5 != null)
                    addr.Address5 = addr.Address5.Replace(" ", _utils.RandomString()) + _utils.RandomString();
                if (addr.PostCode != null)
                    addr.PostCode = _utils.GenPostCode();

                var response = await client.CreateDocumentAsync(collectionUri, addr);
            }

        }



/*
        private async Task<List<Models.ContactDetails>> GetAllContacts()
        {
            var collectionUri = _documentDbHelper.CreateSourceContactDocumentCollectionUri();
            var client = _databaseClient.CreateSourceDocumentClient();

            if (client == null)
                return null;

            var queryCont = client.CreateDocumentQuery<Models.ContactDetails>(collectionUri).AsDocumentQuery();
            var contacts = new List<Models.ContactDetails>();

            while (queryCont.HasMoreResults)
            {
                var response = await queryCont.ExecuteNextAsync<Models.ContactDetails>();
                contacts.AddRange(response);
            }

            return contacts.Any() ? contacts : null;
        }
        */

        public async Task AnonymiseContactDetailsData()
        {
            var contacts = await GetAllDocuments<Models.ContactDetails>(CosmosConstants.ContactCol,CosmosConstants.ContactDB);

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.ContactDB;
            var databaseCollection = CosmosConstants.ContactCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var cont in contacts)
            {
                cont.EmailAddress = _utils.RandomEmail();
                cont.MobileNumber = _utils.RandomMobile();
                cont.HomeNumber = _utils.RandomPhoneNumber();
                cont.AlternativeNumber = _utils.RandomPhoneNumber();
                
                var response = await client.CreateDocumentAsync(collectionUri, cont);
            }

        }

        public async Task AnonymiseActionPlanData()
        {
            var actionplans = await GetAllDocuments<Models.ActionPlan>(CosmosConstants.ActionPlanCol, CosmosConstants.ActionPlanDB);

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.ActionPlanDB;
            var databaseCollection = CosmosConstants.ActionPlanCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var ap in actionplans)
            {
                // nothing to anon ???
                 var response = await client.CreateDocumentAsync(collectionUri, ap);
            }
        }

        public async Task AnonymiseActionData()
        {
            var actions = await GetAllDocuments<Models.ActionPlan>(CosmosConstants.ActionCol, CosmosConstants.ActionDB);

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.ActionDB;
            var databaseCollection = CosmosConstants.ActionCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var a in actions)
            {
                // nothing to anon ???
                var response = await client.CreateDocumentAsync(collectionUri, a);
            }
        }

        public async Task AnonymiseAdviserDetailData()
        {
            var advisers = await GetAllDocuments<Models.AdviserDetail>(CosmosConstants.AdviserDetailsCol, CosmosConstants.AdviserDetailsCol);

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.AdviserDetailDB;
            var databaseCollection = CosmosConstants.AdviserDetailsCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var a in advisers)
            {
                // nothing to anon ???
                var response = await client.CreateDocumentAsync(collectionUri, a);
            }
        }

        public async Task AnonymiseGoalData()
        {
            var goals = await GetAllDocuments<Models.Goal>(CosmosConstants.GoalCol, CosmosConstants.GoalDB);

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.GoalDB;
            var databaseCollection = CosmosConstants.GoalCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var goal in goals)
            {
                // nothing to anon ???
                var response = await client.CreateDocumentAsync(collectionUri, goal);
            }
        }
        public async Task AnonymiseOutcomeData()
        {
            var outcomes = await GetAllDocuments<Models.Outcome>(CosmosConstants.OutcomeCol, CosmosConstants.OutcomeDB);

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.OutcomeDB;
            var databaseCollection = CosmosConstants.OutcomeCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var outcome in outcomes)
            {
                // nothing to anon ???
                var response = await client.CreateDocumentAsync(collectionUri, outcomes);
            }
        }

        public async Task AnonymiseInteractionData()
        {
            var interactions = await GetAllDocuments<Models.ActionPlan>(CosmosConstants.InteractionCol, CosmosConstants.InteractionDB);

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.InteractionDB;
            var databaseCollection = CosmosConstants.InteractionCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var i in interactions)
            {
                // nothing to anon ???
                var response = await client.CreateDocumentAsync(collectionUri, i);
            }
        }

        public async Task AnonymiseSessionData()
        {
            var sessions = await GetAllDocuments<Models.Session>(CosmosConstants.SessionCol, CosmosConstants.SessionDB);

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.ActionCol;
            var databaseCollection = CosmosConstants.ActionDB + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var s in sessions)
            {
                // nothing to anon ???
                var response = await client.CreateDocumentAsync(collectionUri, s);
            }
        }


        


        public async Task AnonymiseWebChatData()
        {
            var databaseName = CosmosConstants.WebChatDB;
            var databaseCollection = CosmosConstants.WebChatCol + TargetPostFix;

            var webchats = await GetAllDocuments<Models.WebChat>(CosmosConstants.WebChatCol, databaseName);

            var collectionUri = _documentDbHelper.GetUri(databaseName, databaseCollection);
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);
            //var client = _databaseClient.CreateSourceDocumentClient();


            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var chat in webchats)
            {
                // nothing to anon ???
                var response = await client.CreateDocumentAsync(collectionUri, chat);
            }
        }
        public async Task AnonymiseTransferData()
        {
            var transfers = await GetAllDocuments<Models.Transfer>(CosmosConstants.TransferCol, CosmosConstants.TransferDB);

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.TransferDB;
            var databaseCollection = CosmosConstants.TransferCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var t in transfers)
            {
                // nothing to anon ???
                var response = await client.CreateDocumentAsync(collectionUri, t);
            }
        }
        public async Task AnonymiseSubscriptionData()
        {
            var subscriptions = await GetAllDocuments<Models.Interaction>(CosmosConstants.InteractionCol, CosmosConstants.InteractionDB);

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDocumentClient(targetEndPoint, targetKey);

            var databaseName = CosmosConstants.InteractionDB;
            var databaseCollection = CosmosConstants.InteractionCol + TargetPostFix;

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var s in subscriptions)
            {
                // nothing to anon ???
                var response = await client.CreateDocumentAsync(collectionUri, s);
            }
        }

        /*      
        public string CopyDiversityDetails { get; set; }
           */

    }
}