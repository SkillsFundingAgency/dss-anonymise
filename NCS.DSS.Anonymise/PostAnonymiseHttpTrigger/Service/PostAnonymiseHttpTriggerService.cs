using NCS.DSS.Anonymise.Cosmos.Provider;
using System.Net;
using System.Threading.Tasks;
using NCS.DSS.Anonymise.Models;
using NCS.DSS.Anonymise.ReferenceData;

namespace NCS.DSS.Anonymise.PostAnonymiseHttpTrigger.Service
{
    public class PostAnonymiseHttpTriggerService : IPostAnonymiseHttpTriggerService
    {


      /*  public async Task Anonymise()
        {
            //var documentDbProvider = new DocumentDBProvider();

           /* await documentDbProvider.AnonymiseCustomerData();
            await documentDbProvider.AnonymiseAddressData();
            await documentDbProvider.AnonymiseContactDetailsData();*/
        //}*/

        public async Task Anonymise(RequestOptions requestOptions)
        {
            var documentDbProvider = new DocumentDBProvider();

            documentDbProvider.SetSourceEndPoint(requestOptions.SourceEndPoint);
            documentDbProvider.SetTargetEndPoint(requestOptions.TargetEndPoint);
            documentDbProvider.SetSourceKey(requestOptions.SourceKey);
            documentDbProvider.SetTargetKey(requestOptions.TargetKey);
            documentDbProvider.TargetPostFix = requestOptions.TargetPostfix;

            if (requestOptions.CopyCustomer.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.Customer>(CosmosConstants.CustomerDB, CosmosConstants.CustomerCol);
            }
            if (requestOptions.CopyAddress.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.Address>(CosmosConstants.AddressDB, CosmosConstants.AddressCol);
            }
            if (requestOptions.CopyContacts.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.ContactDetails>(CosmosConstants.ContactDB, CosmosConstants.ContactCol);
            }
            if (requestOptions.CopyActionPlans.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.ActionPlan>(CosmosConstants.ActionPlanDB, CosmosConstants.ActionPlanCol);
            }
            if (requestOptions.CopyActions.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.Action>(CosmosConstants.ActionDB, CosmosConstants.ActionCol);
            }
            if (requestOptions.CopyInteractions.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.Interaction>(CosmosConstants.InteractionDB, CosmosConstants.InteractionCol);
            }
            if (requestOptions.CopySessions.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.Session>(CosmosConstants.SessionDB, CosmosConstants.SessionCol);
            }
            if (requestOptions.CopyGoals.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.Goal>(CosmosConstants.GoalDB, CosmosConstants.GoalCol);
            }
            if (requestOptions.CopyOutcomes.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.Outcome>(CosmosConstants.OutcomeDB, CosmosConstants.OutcomeCol);
            }
            if (requestOptions.CopyTransfers.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.Transfer>(CosmosConstants.TransferDB, CosmosConstants.TransferCol);
            }
            if (requestOptions.CopyWebChats.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.WebChat>(CosmosConstants.WebChatDB, CosmosConstants.WebChatCol);
             }
            if (requestOptions.CopySubscriptions.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.Subscription>(CosmosConstants.SubscriptionDB, CosmosConstants.SubscriptionCol);
            }
            if (requestOptions.CopyAdviserDetails.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.AdviserDetail>(CosmosConstants.AdviserDetailDB, CosmosConstants.AdviserDetailCol);
            }
            if (requestOptions.CopyDiversityDetails.ToLower() == "true")
            {
                await documentDbProvider.AnonymiseCollectionData<Models.DiverstityDetails>(CosmosConstants.DiversityDetailDB, CosmosConstants.DiversityDetailCol);
            }
        }
    }
}