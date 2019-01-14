using System.Threading.Tasks;

namespace NCS.DSS.Anonymise.PostAnonymiseHttpTrigger.Service
{
    public interface IPostAnonymiseHttpTriggerService
    {
        Task Anonymise();
    }
}