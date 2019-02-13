using System.Threading.Tasks;
using NCS.DSS.Anonymise.Models;

namespace NCS.DSS.Anonymise.PostAnonymiseHttpTrigger.Service
{
    public interface IPostAnonymiseHttpTriggerService
    {
        Task Anonymise();
        Task Anonymise(RequestOptions r);
    }
}