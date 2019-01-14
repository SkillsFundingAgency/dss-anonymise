
using System;
using System.Configuration;
using Microsoft.Azure.Documents.Client;

namespace NCS.DSS.Anonymise.Cosmos.Helper
{
    public class DocumentDBHelper : IDocumentDBHelper
    {
        private Uri _customerSourceDocumentCollectionUri;
        private readonly string _customerSourceDatabaseId = ConfigurationManager.AppSettings["CustomerSourceDatabaseId"];
        private readonly string _customerSourceCollectionId = ConfigurationManager.AppSettings["CustomerSourceCollectionId"];

        private Uri _addressSourceDocumentCollectionUri;
        private readonly string _addressSourceDatabaseId = ConfigurationManager.AppSettings["AddressSourceDatabaseId"];
        private readonly string _addressSourceCollectionId = ConfigurationManager.AppSettings["AddressSourceCollectionId"];

        private Uri _contactSourceDocumentCollectionUri;
        private readonly string _contactSourceDatabaseId = ConfigurationManager.AppSettings["ContactSourceDatabaseId"];
        private readonly string _contactSourceCollectionId = ConfigurationManager.AppSettings["ContactSourceCollectionId"];

        
        private Uri _customerDestinationDocumentCollectionUri;
        private readonly string _customerDestinationDatabaseId = ConfigurationManager.AppSettings["CustomerDestinationDatabaseId"];
        private readonly string _customerDestinationCollectionId = ConfigurationManager.AppSettings["CustomerDestinationCollectionId"];

        private Uri _addressDestinationDocumentCollectionUri;
        private readonly string _addressDestinationDatabaseId = ConfigurationManager.AppSettings["AddressDestinationDatabaseId"];
        private readonly string _addressDestinationCollectionId = ConfigurationManager.AppSettings["AddressDestinationCollectionId"];

        private Uri _contactDestinationDocumentCollectionUri;
        private readonly string _contactDestinationDatabaseId = ConfigurationManager.AppSettings["ContactDestinationDatabaseId"];
        private readonly string _contactDestinationCollectionId = ConfigurationManager.AppSettings["ContactDestinationCollectionId"];



               
        #region CustomerDB_Source

        public Uri CreateSourceCustomerDocumentCollectionUri()
        {
            if (_customerSourceDocumentCollectionUri != null)
                return _customerSourceDocumentCollectionUri;

            _customerSourceDocumentCollectionUri = UriFactory.CreateDocumentCollectionUri(
                _customerSourceDatabaseId, _customerSourceCollectionId);

            return _customerSourceDocumentCollectionUri;
        }

        #endregion

        #region AddressDB_Source

        public Uri CreateSourceAddressDocumentCollectionUri()
        {
            if (_addressSourceDocumentCollectionUri != null)
                return _addressSourceDocumentCollectionUri;

            _addressSourceDocumentCollectionUri = UriFactory.CreateDocumentCollectionUri(
                _addressSourceDatabaseId, _addressSourceCollectionId);

            return _addressSourceDocumentCollectionUri;
        }

        #endregion

        #region ContactDB_Source

        public Uri CreateSourceContactDocumentCollectionUri()
        {
            if (_contactSourceDocumentCollectionUri != null)
                return _contactSourceDocumentCollectionUri;

            _contactSourceDocumentCollectionUri = UriFactory.CreateDocumentCollectionUri(
                _contactSourceDatabaseId, _contactSourceCollectionId);

            return _contactSourceDocumentCollectionUri;
        }

        #endregion

        #region CustomerDB_Destination

        public Uri CreateDestinationCustomerDocumentCollectionUri()
        {
            if (_customerDestinationDocumentCollectionUri != null)
                return _customerDestinationDocumentCollectionUri;

            _customerDestinationDocumentCollectionUri = UriFactory.CreateDocumentCollectionUri(
                _customerDestinationDatabaseId, _customerDestinationCollectionId);

            return _customerDestinationDocumentCollectionUri;
        }

        #endregion

        #region AddressDB_Destination

        public Uri CreateDestinationAddressDocumentCollectionUri()
        {
            if (_addressDestinationDocumentCollectionUri != null)
                return _addressDestinationDocumentCollectionUri;

            _addressDestinationDocumentCollectionUri = UriFactory.CreateDocumentCollectionUri(
                _addressDestinationDatabaseId, _addressDestinationCollectionId);

            return _addressDestinationDocumentCollectionUri;
        }

        #endregion

        #region ContactDB_Destination

        public Uri CreateDestinationContactDocumentCollectionUri()
        {
            if (_contactDestinationDocumentCollectionUri != null)
                return _contactDestinationDocumentCollectionUri;

            _contactDestinationDocumentCollectionUri = UriFactory.CreateDocumentCollectionUri(
                _contactDestinationDatabaseId, _contactDestinationCollectionId);

            return _contactDestinationDocumentCollectionUri;
        }

        #endregion   

    }
}
