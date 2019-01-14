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
using NCS.DSS.Anonymise.Utils;

namespace NCS.DSS.Anonymise.Cosmos.Provider
{
    public class DocumentDBProvider : IDocumentDBProvider
    {
        private readonly DocumentDBHelper _documentDbHelper;
        private readonly DocumentDBClient _databaseClient;
        private RandomUtils _utils;

        public DocumentDBProvider()
        {
            _documentDbHelper = new DocumentDBHelper();
            _databaseClient = new DocumentDBClient();
            _utils = new RandomUtils();
        }
        
        private async Task<List<Models.Customer>> GetAllCustomers()
        {
            var collectionUri = _documentDbHelper.CreateSourceCustomerDocumentCollectionUri();
            var client = _databaseClient.CreateSourceDocumentClient();

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
        
        public async Task AnonymiseCustomerData()
        {
            var customers = await GetAllCustomers();

            var collectionUri = _documentDbHelper.CreateDestinationCustomerDocumentCollectionUri();
            var client = _databaseClient.CreateDestinationDocumentClient();

            var databaseName = "customers";
            var databaseCollection = "customers-anonymised";

            client.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = databaseCollection }).
                    GetAwaiter()
                    .GetResult();

            foreach (var cust in customers)
            {
                cust.FamilyName = _utils.RandomString() + cust.FamilyName + _utils.RandomString();
                cust.GivenName = _utils.RandomString() + cust.GivenName + _utils.RandomString();
                cust.DateofBirth = _utils.RandomDate();
                var response = await client.CreateDocumentAsync(collectionUri, cust);
            }

        }


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


        public async Task AnonymiseAddressData()
        {
            var addresses = await GetAllAddresses();

            var collectionUri = _documentDbHelper.CreateDestinationAddressDocumentCollectionUri();
            var client = _databaseClient.CreateDestinationDocumentClient();

            var databaseName = "addresses";
            var databaseCollection = "addresses-anonymised";

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


        public async Task AnonymiseContactDetailsData()
        {
            var contacts = await GetAllContacts();

            var collectionUri = _documentDbHelper.CreateDestinationContactDocumentCollectionUri();
            var client = _databaseClient.CreateDestinationDocumentClient();

            var databaseName = "contacts";
            var databaseCollection = "contacts-anonymised";

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

    }
}