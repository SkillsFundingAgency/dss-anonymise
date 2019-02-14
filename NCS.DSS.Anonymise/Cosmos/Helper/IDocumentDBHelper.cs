using System;

namespace NCS.DSS.Anonymise.Cosmos.Helper
{
    public interface IDocumentDBHelper
    {
        string GetCollectionName(string resource);
        Uri GetUri(string database, string collection);
    }
}