using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NCS.DSS.Anonymise.Helpers
{
    public interface IHttpRequestMessageHelper
    {
        Task<T> GetAnonymiseFromRequest<T>(HttpRequestMessage req);
        string GetTouchpointId(HttpRequestMessage req);
        string GetApimURL(HttpRequestMessage req);
    }
}