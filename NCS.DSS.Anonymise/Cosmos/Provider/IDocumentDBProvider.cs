using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace NCS.DSS.Anonymise.Cosmos.Provider
{
    public interface IDocumentDBProvider
    {
        Task AnonymiseCustomerData();
        Task AnonymiseAddressData();
        Task AnonymiseContactDetailsData();
    }
}