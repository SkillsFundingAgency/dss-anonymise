using NCS.DSS.Anonymise.Cosmos.Provider;
using System.Net;
using System.Threading.Tasks;

namespace NCS.DSS.Anonymise.PostAnonymiseHttpTrigger.Service
{
    public class PostAnonymiseHttpTriggerService : IPostAnonymiseHttpTriggerService
    {


        public async Task Anonymise()
        {
            var documentDbProvider = new DocumentDBProvider();
            
            await documentDbProvider.AnonymiseCustomerData();
            await documentDbProvider.AnonymiseAddressData();
            await documentDbProvider.AnonymiseContactDetailsData();
        }

    }
}