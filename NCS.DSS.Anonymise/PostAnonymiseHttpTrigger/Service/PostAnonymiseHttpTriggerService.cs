using NCS.DSS.Anonymise.Cosmos.Provider;
using System.Net;
using System.Threading.Tasks;
using NCS.DSS.Anonymise.Models;
using NCS.DSS.Anonymise.ReferenceData;

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

        public async Task Anonymise(RequestOptions requestOptions)
        {
            var documentDbProvider = new DocumentDBProvider();

            documentDbProvider.SetSourceEndPoint(requestOptions.SourceEndPoint);
            documentDbProvider.SetTargetEndPoint(requestOptions.TargetEndPoint);
            documentDbProvider.SetSourceKey(requestOptions.SourceKey);
            documentDbProvider.SetTargetKey(requestOptions.TargetKey);

            if (requestOptions.CopyCustomer.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCustomerData();
            }
            if (requestOptions.CopyAddress.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseAddressData();
            }
            if (requestOptions.CopyContacts.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseContactDetailsData();
            }
            if (requestOptions.CopyActionPlans.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseActionPlanData();
            }
            if (requestOptions.CopyActions.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseActionData();
            }
            if (requestOptions.CopyInteractions.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseInteractionData();
            }
            if (requestOptions.CopySessions.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseSessionData();
            }
            if (requestOptions.CopyGoals.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseGoalData();
            }
            if (requestOptions.CopyOutcomes.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseOutcomeData();
            }
            if (requestOptions.CopyTransfers.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseTransferData();
            }
            if (requestOptions.CopyWebChats.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.WebChat>(CosmosConstants.WebChatDB, CosmosConstants.WebChatCol);
               // await documentDbProvider.AnonymiseWebChatData();
            }
            if (requestOptions.CopySubscriptions.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseSubscriptionData();
            }
            if (requestOptions.CopyAdviserDetails.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseAdviserDetailData();
            }
            // diversity
        }
    }
}