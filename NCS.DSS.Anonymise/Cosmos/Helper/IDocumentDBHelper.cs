using System;

namespace NCS.DSS.Anonymise.Cosmos.Helper
{
    public interface IDocumentDBHelper
    {
        Uri CreateSourceCustomerDocumentCollectionUri();
        Uri CreateSourceAddressDocumentCollectionUri();
        Uri CreateSourceContactDocumentCollectionUri();

        Uri CreateDestinationCustomerDocumentCollectionUri();
        Uri CreateDestinationAddressDocumentCollectionUri();
        Uri CreateDestinationContactDocumentCollectionUri();
    }
}