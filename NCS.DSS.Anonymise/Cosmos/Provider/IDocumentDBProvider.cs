using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace NCS.DSS.Anonymise.Cosmos.Provider
{
    public interface IDocumentDBProvider
    {
       Task<List<T>> GetAllDocuments<T>(string database, string collection);
       Task AnonymiseCollectionData<T>(string database, string collection) where T : Models.IAnonymise;
    }
}